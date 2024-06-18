using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _240401_01.Models;

namespace _240401_01.Data
{
    public static class DataSet
    {
        public static List<Cliente> Clientes { get; set; } = new List<Cliente>();
        public static List<Livro> Acervo { get; set; } = new List<Livro>();
    }
}