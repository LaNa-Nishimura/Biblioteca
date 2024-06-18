using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _240401_01.Models;

namespace _240401_01.Models
{
    public class Livro
    {
        public int bookID { get;set;}
        public string bookName { get;set; }
        public int bookPrice { get;set; }
        public Cliente rentedBy { get;set; }
    }
}