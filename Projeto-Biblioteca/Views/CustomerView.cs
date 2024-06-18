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
    public class CustomerView
    {
        private ClienteController clienteController;

        public CustomerView() {
            clienteController = new ClienteController();
            this.Init();
        }

        public void Init() {
            Console.WriteLine("MENU CLIENTE");
            Console.WriteLine("*************");
            Console.WriteLine("");

            bool aux = true;
            do {
                Console.WriteLine("Escolha uma opção: ");
                Console.WriteLine("1 - Inserir Cliente");
                Console.WriteLine("2 - Pesquisar Cliente");
                Console.WriteLine("3 - Editar Cliente");
                Console.WriteLine("4 - Remover Cliente");
                Console.WriteLine("0 - Sair");

                int menu = 0;
                try {
                    menu = Convert.ToInt32(Console.ReadLine());
                    switch(menu) {
                        case 0: // caso a pessoa escolha a opção 0
                            aux = false;
                        break;
                        case 1:
                            InsertCustomer();
                        break;
                        case 2:
                            SearchCustomer();
                        break;
                        case 3:
                            EditByCPF();
                        break;
                        case 4:
                            RemoveByCPF();
                        break;
                        default:
                            Console.WriteLine("Opção Inválida.....");
                            aux = true;
                        break;
                    }
                }                
                catch (Exception ex){
                    Console.WriteLine($"Opção inválida");                    
                    menu = -1; // caso a pessoa digite algo inválido
                }
            }

            while(aux);
        }

        private void InsertCustomer() {
            Console.WriteLine("***********************");
            Console.WriteLine("INSERIR NOVO CLIENTE");
            Console.WriteLine("***********************");

                Cliente cliente = new Cliente();
                Console.Write("Nome: ");
                cliente.name = Console.ReadLine();
                Console.Write("CPF: ");
                cliente.cpf = Convert.ToInt32(Console.ReadLine());
                Console.Write("Email: ");
                cliente.email = Console.ReadLine();
                Console.WriteLine("");

                
                try {
                    clienteController.Insert(cliente);
                    Console.WriteLine("Cliente inserido com sucesso!");
                }

                catch {
                    Console.WriteLine("Ops! Ocorreu um erro.");
                }
        }

        private void SearchCustomer() {

            int aux = -1;
            do {
                Console.WriteLine("PESQUISAR CLIENTE");
                Console.WriteLine("*****************");
                Console.WriteLine("1 - Buscar por CPF");
                Console.WriteLine("2 - Buscar por nome");
                Console.WriteLine("3 - Listar Todos");
                Console.WriteLine("0 - Sair");

                string? menuOpt = Console.ReadLine();
                aux = Convert.ToInt16(menuOpt);
                switch(aux) {
                    case 1:
                        Console.WriteLine("Informe o CPF: ");
                        int cpf = Convert.ToInt32(Console.ReadLine());
                        ShowCustomerByCPF(cpf);
                    break;
                    case 2:
                        Console.WriteLine("Informe o nome: ");
                        string? name = Console.ReadLine();
                        ShowCustomerByName(name);
                    break;
                    case 3:
                        ShowAll();
                    break;
                    case 0:
                    break;
                    default:
                        aux = -1;
                        Console.WriteLine("Opção Inválida!");
                    break;
                }
            }
            while (aux != 0);
        }

        private void ShowAll()
        {
            List<Cliente> result = clienteController.GetAll();
            foreach (Cliente cliente in result) {
                Console.WriteLine("Nome do Cliente: " + cliente?.name?.ToString());
                Console.WriteLine("CPF do Cliente: " + cliente?.cpf.ToString());
                Console.WriteLine("Email do Cliente: " + cliente?.email?.ToString());
                if(cliente?.locado != null)
                {
                    Console.WriteLine("Livro locado: " + cliente?.locado.bookName);
                }                
            }
        }
        private void ShowCustomerByCPF(int cpf) {
            Cliente cliente = clienteController.Get(cpf);
            if (cliente != null) {
                Console.WriteLine("Nome do Cliente: " + cliente?.name?.ToString());
                Console.WriteLine("CPF do Cliente: " + cliente?.cpf.ToString());
                Console.WriteLine("Email do Cliente: " + cliente?.email?.ToString());
                if(cliente?.locado != null)
                {
                    Console.WriteLine("Livro locado: " + cliente?.locado.bookName);
                }
            }
            else {
                Console.WriteLine($"Cliente de CPF {cpf} não encontrado!");
            }
        }

        public void EditByCPF(){
            Console.WriteLine("Informe o CPF: ");
            int cpf = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Informe o NOVO nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe o NOVO email: ");
            string email = Console.ReadLine();

            clienteController.Edit(cpf, nome, email);
        }

         public void RemoveByCPF(){
            Console.WriteLine("Informe o CPF: ");
            int cpf = Convert.ToInt32(Console.ReadLine());

            if( clienteController.Remove(cpf) )
                Console.WriteLine("Cliente removido com sucesso.");
            else
                Console.WriteLine("Não foi possível remover, verifique o id.");
        }

        private void ShowCustomerByName(string name) {
            List<Cliente> result = clienteController.GetByName(name);
            if (result == null) {
                Console.WriteLine("Não encontrado!");
                return;
            }

            if (result.Count == 0) {
                Console.WriteLine("Não encontrado!");
                return;
            }

            foreach (Cliente cliente in result) {
                Console.WriteLine("Nome do Cliente: " + cliente?.name?.ToString());
                Console.WriteLine("CPF do Cliente: " + cliente?.cpf.ToString());
                Console.WriteLine("Email do Cliente: " + cliente?.email?.ToString());
                if(cliente?.locado != null)
                {
                    Console.WriteLine("Livro locado: " + cliente?.locado.bookName);
                }       
                }
            }
        }
    }