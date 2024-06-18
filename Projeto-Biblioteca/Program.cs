using _240401_01.Models;
using _240401_01.Views;
bool aux = true;
do {
    Console.WriteLine("*******************");
    Console.WriteLine("Locação de Livros");
    Console.WriteLine("*******************");
    Console.WriteLine();

    Console.WriteLine("1 - Clientes");
    Console.WriteLine("2 - Livros");
    Console.WriteLine("0 - Sair");

    int menu = 0;

    menu = Convert.ToInt32(Console.ReadLine());
    switch(menu) {
        case 1:
            CustomerView customerView = new CustomerView();
        break;
        case 2:
            BookView bookView = new BookView();
        break;
        case 0:
            aux = false;
        break;
        default:
            Console.WriteLine("Opção inválida.");
        break;
    }

    Console.WriteLine("Sistema encerrado!");
        
} while(aux);