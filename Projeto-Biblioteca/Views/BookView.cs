using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;
using _240401_01.Controllers;
using _240401_01.Models;
using _240401_01.Data;

namespace _240401_01.Views
{
    public class BookView
    {
        private LivroController livroController;

        public BookView() {
            livroController = new LivroController();
            this.Init();
        }

        public void Init() {
            Console.WriteLine("MENU LIVRO");
            Console.WriteLine("*************");
            Console.WriteLine("");

            bool aux = true;
            do {
                Console.WriteLine("Escolha uma opção: ");
                Console.WriteLine("1 - Inserir Livro");
                Console.WriteLine("2 - Pesquisar Livro");
                Console.WriteLine("3 - Editar Livro");
                Console.WriteLine("4 - Remover Livro");
                Console.WriteLine("5 - Locar Livro");
                Console.WriteLine("6 - Devolver Livro");
                Console.WriteLine("0 - Sair");

                int menu = 0;
                    menu = Convert.ToInt32(Console.ReadLine());
                    switch(menu) {
                        case 0: // caso a pessoa escolha a opção 0
                            aux = false;
                        break;
                        case 1:
                            InsertLivro();
                        break;
                        case 2:
                            SearchLivro();
                        break;
                        case 3:
                            EditByID();
                        break;
                        case 4:
                            RemoveByID();
                        break;
                        case 5:
                            LocaLivro();
                            break;
                        case 6:
                            DevolveLivro();
                            break;
                        default:
                            Console.WriteLine("Opção Inválida.");
                            aux = true;
                        break;
                    }
                }
                

            while(aux);
        }

            private void InsertLivro() {
                Console.WriteLine("***********************");
                Console.WriteLine("INSERIR NOVO LIVRO");
                Console.WriteLine("***********************");

                Livro livro = new Livro();

                Console.Write("Nome: ");
                livro.bookName = Console.ReadLine();

                Console.Write("ID: ");
                livro.bookID = Convert.ToInt32(Console.ReadLine());

                Console.Write("Preço: ");
                decimal preco = Convert.ToDecimal(Console.ReadLine());
                livro.bookPrice = (int)preco; // Trunca para o inteiro, removendo a parte decimal

                Console.WriteLine("");

                livroController.Insert(livro);
                Console.WriteLine("Livro inserido com sucesso!");
            }

            private void LocaLivro() {
                Console.WriteLine("***********************");
                Console.WriteLine("LOCAÇÃO DE LIVRO");
                Console.WriteLine("***********************");

                Console.Write("ID: ");
                int ID = Convert.ToInt32(Console.ReadLine());

                Console.Write("CPF: ");
                int CPF = Convert.ToInt32(Console.ReadLine());

                bool clienteEncontrado = false;

                foreach (Cliente cliente in DataSet.Clientes) {
                    if (cliente.cpf == CPF) {
                        livroController.LocaLivros(ID, CPF);
                        clienteEncontrado = true;
                        break; // interrompe o loop assim que encontrar o cliente
                    }
                }

                if (clienteEncontrado) {
                    Console.Write("Locado");
                    Console.WriteLine("");
                } else {
                    Console.Write("Cliente não encontrado");
                    Console.WriteLine("");
                }

            }

             private void DevolveLivro() {
                Console.WriteLine("***********************");
                Console.WriteLine("DEVOLUÇÃO DE LIVRO");
                Console.WriteLine("***********************");

                Console.Write("ID: ");
                int ID = Convert.ToInt32(Console.ReadLine());

                Console.Write("CPF: ");
                int CPF = Convert.ToInt32(Console.ReadLine());

                bool clienteEncontrado = false;

                // Localiza o livro para o cliente com o CPF especificado
                foreach (Cliente cliente in DataSet.Clientes) {
                    if (cliente.cpf == CPF) {
                        livroController.LocaLivros(ID, CPF); // Loca o livro
                        clienteEncontrado = true;
                        break; // Interrompe o loop assim que encontrar o cliente
                    }
                }

                if (clienteEncontrado) {
                    // Aqui o livro foi locado com sucesso, agora vamos devolvê-lo
                    livroController.DevolveLivro(ID, CPF); // Devolve o livro
                    Console.WriteLine("Devolvido");
                } else {
                    Console.WriteLine("Cliente não encontrado");
                }
            }

        private void SearchLivro() {

            int aux2 = -1;
            do {
                Console.WriteLine("PESQUISAR LIVRO");
                Console.WriteLine("*****************");
                Console.WriteLine("1 - Buscar por ID");
                Console.WriteLine("2 - Buscar por nome");
                Console.WriteLine("3 - Listar Todos");
                Console.WriteLine("0 - Sair");

                string menuOpt = Console.ReadLine();
                aux2 = Convert.ToInt16(menuOpt);
                Console.WriteLine(aux2);
                switch(aux2) {
                    case 1:
                        Console.WriteLine("Informe o ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        ShowBookByID(id);
                    break;
                    case 2:
                        Console.WriteLine("Informe o nome: ");
                        string name = Console.ReadLine();
                        ShowBookByName(name);
                    break;
                    case 3:
                        ShowAll();
                    break;
                    case 0:
                    break;
                    default:
                        aux2 = -1;
                        Console.WriteLine("Opção Inválida!");
                    break;
                }
            }

            while (aux2 != 0);
        }

        private void ShowAll(){
            List<Livro> result = livroController.GetAll();
            foreach (Livro l in result) {
                Console.WriteLine("ID do Livro: " + l.bookID.ToString());
                Console.WriteLine("Nome do Livro: " + l.bookName.ToString());
                Console.WriteLine("Preço: " + l.bookPrice.ToString());

                if(l.rentedBy != null)
                    Console.WriteLine($"Locado pelo cliente: {l?.rentedBy?.name}");
            }
        }

        private void ShowBookByID(int id) {
            Livro l = livroController.Get(id);
            if (id != null) {
                Console.WriteLine("ID do Livro: " + l.bookID.ToString());
                Console.WriteLine("Nome do Livro: " + l.bookName.ToString());
                Console.WriteLine("Preço: " + l.bookPrice.ToString());
               try {Console.WriteLine("Locado pelo cliente: " + l.rentedBy.name.ToString());} catch { Console.WriteLine(""); }
            }
            else {
                Console.WriteLine($"Consumidor de id {id} não encontrado!");
            }
        }

        public void EditByID(){
            Console.WriteLine("Informe o id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Informe o NOVO nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe o NOVO preco: ");
                int preco = Convert.ToInt32(Console.ReadLine());
            livroController.Edit(id, nome, preco);
        }

         public void RemoveByID(){
            Console.WriteLine("Informe o ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            livroController.Remove(id);
        }

        private void ShowBookByName(string name) {
            List<Livro> result = livroController.GetByName(name);
            if (result == null) {
                Console.WriteLine("Não encontrado!");
                return;
            }

            if (result.Count == 0) {
                Console.WriteLine("Não encontrado!");
                return;
            }

            foreach (Livro l in result) {
                Console.WriteLine("ID do Livro: " + l.bookID.ToString());
                Console.WriteLine("Nome do Livro: " + l.bookName.ToString());
                Console.WriteLine("Preço: " + l.bookPrice.ToString());
                try {Console.WriteLine("Locado pelo cliente: " + l.rentedBy.name.ToString());} catch { Console.WriteLine(""); }
            }
        }
    }
}