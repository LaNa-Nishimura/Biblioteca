using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _240401_01.Models;
using _240401_01.Data;
using System.ComponentModel;

namespace _240401_01.Repository
{

    
    public class RepositorioCliente
    {

        // Salva novo cliente
        public void Save(Cliente cliente) {
            DataSet.Clientes.Add(cliente);
        }


        // Pesquisa os clientes pelo CPF
        public Cliente? Retrieve(int cpf) {
            foreach (var c in DataSet.Clientes) {
                if (c.cpf == cpf) {
                    return c;
                }
            }
            return null;
        }

        
        // Pesquisa os clientes pelo nome
        public List<Cliente> RetrieveByName(string name) {
            List<Cliente> retorno = new List<Cliente>();
            foreach (var c in DataSet.Clientes) {
                if(c.name.Contains(name)) {
                    retorno.Add(c);
                }
            }
            return retorno;
        }


        // Pesquisa a lista de clientes inteira
        public List<Cliente> RetrieveAll() {
            return DataSet.Clientes;
        }

        // Edita clientes
        public void EditaClientes(int cpf, string nome, string email){
            foreach (var c in DataSet.Clientes) {
                if (c.cpf == cpf) {
                    c.name = nome;
                    c.email = email;
                }
            }
        }

        // Remove clientes
        public bool RemoveClientes(int cpf)
        {
            return DataSet.Clientes.Remove( this.Retrieve(cpf) );
        }

        public void LocaLivros(int id, int cpf){

                foreach (Livro l in DataSet.Acervo) {
                if (l.bookID == id) {
                    foreach (var c in DataSet.Clientes) {
                        if (c.cpf == cpf) {
                            c.locado = l;
                            l.rentedBy = c;
                        }
                    }
                }
            }
        }

        public void DevolveLivro(int id, int cpf){

                foreach (Livro l in DataSet.Acervo) {
                if (l.bookID == id) {
                    Livro livro = l;
                    foreach (var c in DataSet.Clientes) {
                        if (c.cpf == cpf) {
                            c.locado= null;
                            l.rentedBy = null;
                        }
                    }
                }


        }


    }
}
}