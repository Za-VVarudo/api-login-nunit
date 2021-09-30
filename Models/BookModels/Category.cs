using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Models.BookModels
{
    public class Category
    {
        public string CategoryID { get; init; }
        public string CategoryName { get; set; }
        public Category()
        {
        }
    }
}
