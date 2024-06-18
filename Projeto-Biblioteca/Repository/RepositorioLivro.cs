using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _240401_01.Models;
using _240401_01.Data;
using System.ComponentModel;

namespace _240401_01.Repository
{
    public class RepositorioLivro
    {

        // Salva novo Livro
        public void Save(Livro livro) {
            DataSet.Acervo.Add(livro);
        }


        // Pesquisa os livros pelo ID
        public Livro? Retrieve(int id) {
            foreach (Livro l in DataSet.Acervo) {
                if (l.bookID == id) {
                    return l;
                }
            }
            return null;
        }

        
        // Pesquisa os Livros pelo nome
        public List<Livro> RetrieveByName(string name) {
            List<Livro> retorno = new List<Livro>();
            foreach (var l in DataSet.Acervo) {
                if(l.bookName.Contains(name)) {
                    retorno.Add(l);
                }
            }
            return retorno;
        }


        // Pesquisa a lista de livros inteira
        public List<Livro> RetrieveAll() {
            return DataSet.Acervo;
        }

        // Edita livros
        public void EditaLivros(int id, string nome, int preco){
            foreach (var l in DataSet.Acervo) {
                if (l.bookID == id) {
                    l.bookName = nome;
                    l.bookPrice = preco;
                    }
                }
        }

             // Remove livros
            public void RemoveLivros(int id){
                
                List<Livro> burnerList = new List<Livro>();
                    foreach (var l in DataSet.Acervo) {
                        if (l.bookID == id) {
                            burnerList.Add(l);
                        }
                    }
                foreach (Livro l in burnerList)
                {
                    DataSet.Acervo.Remove(l);
                }
            }

            public void LocaLivrosrepo(int id, int cpf){
                foreach (Livro l in DataSet.Acervo) {
                    if (l.bookID == id) {
                        foreach (Cliente c in DataSet.Clientes) {
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
                    foreach (var c in DataSet.Clientes) {
                        if (c.cpf == cpf) {
                            c.locado = null;
                            l.rentedBy = null;
                        }
                    }
                }


        }
            }
    }
}