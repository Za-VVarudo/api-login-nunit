using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Models.BookModels
{
    public class Book
    {
        public string ProductID { get; init; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string CategoryName{ get; set; }
        public int Quantity { set; get; } = 1;
        public Book()
        {
        }
    }
}
