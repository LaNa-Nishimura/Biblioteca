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
    public class LivroController
    {
        private  RepositorioLivro repositorioLivro = new RepositorioLivro();

        public LivroController() {
            repositorioLivro = new RepositorioLivro();
        }
        public void Insert(Livro livro) {
            repositorioLivro.Save(livro);
        }

        public void Edit(int id, string nome, int preco) {
            repositorioLivro.EditaLivros(id, nome, preco);
        }

        public void Remove(int id){
            repositorioLivro.RemoveLivros(id);
        }

        public Livro Get(int id) {
            return repositorioLivro.Retrieve(id);
        }

        public List<Livro> GetAll() {
            return repositorioLivro.RetrieveAll();
        }

        public List<Livro> GetByName(string name) {
            return repositorioLivro.RetrieveByName(name);
        }

        public void LocaLivros(int id, int cpf) {
            repositorioLivro.LocaLivrosrepo(id, cpf);
        }

        public void DevolveLivro(int id, int cpf) {
            repositorioLivro.DevolveLivro(id, cpf);
        }
    }
}