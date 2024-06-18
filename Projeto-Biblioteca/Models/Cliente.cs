using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using _240401_01.Models;

namespace _240401_01.Models
{
    public class Cliente
    {
        public int cpf { get;set; }
        public string? name { get;set; }
        public string? email { get;set; }
        public Livro locado { get;set; }
    }
}