using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.Models.bookStore
{
    public class Book
    {

        public int Id { get; set; }

        public string name { get; set; }

        public string author { get; set; }

        public int price { get; set; }
    }
}