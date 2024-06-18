using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using _240401_01.Models;
using _240401_01.Repository;
using _240401_01.Utils;

namespace _240401_01.Controllers
{
    public class ClienteController
    {
        private RepositorioCliente repositorioCliente;

        public ClienteController() {
            repositorioCliente = new RepositorioCliente();
        }
        public void Insert(Cliente cliente) {
            repositorioCliente.Save(cliente);
        }

        public void Edit(int cpf, string nome, string email) {
            repositorioCliente.EditaClientes(cpf, nome, email);
        }

        public bool Remove(int cpf){
            return repositorioCliente.RemoveClientes(cpf);
        }

        public Cliente Get(int cpf) {
            return repositorioCliente.Retrieve(cpf);
        }

        public List<Cliente> GetAll() {
            return repositorioCliente.RetrieveAll();
        }

        public List<Cliente> GetByName(string name) {
            return repositorioCliente.RetrieveByName(name);
        }

        public void LocaLivros(int id, int cpf) {
            repositorioCliente.LocaLivros(id, cpf);
        }

        public void DevolveLivro(int id, int cpf) {
            repositorioCliente.DevolveLivro(id, cpf);
        }
    }
}