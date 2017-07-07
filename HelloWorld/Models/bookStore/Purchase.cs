using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.Models.bookStore
{
    public class Purchase
    {
        public int PurchaseId { get; set; }

        public string person { get; set; }

        public string address { get; set; }

        public int BookId { get; set; }

        public DateTime datePurchased{get; set;}
    }
}