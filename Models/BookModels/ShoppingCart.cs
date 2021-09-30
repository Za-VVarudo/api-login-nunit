using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Models.BookModels
{
    public class ShoppingCart : Dictionary<string, Book>
    {
        public ShoppingCart() { }

        public ShoppingCart(int capacity) : base(capacity) {}

        public bool AddToCart(Book book)
        {
            if (book == null) return false;
            string key = book.ProductID;
            if (this.ContainsKey(key))
            {
                this.TryGetValue(key, out Book b);
                b.Quantity++;
            } else
            {
                this.Add(key, book);
            }
            return true;
        }

    }
}
