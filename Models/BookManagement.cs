using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using BookAPI.Models.BookModels;

namespace BookAPI.Models
{
    public class BookManagement
    {
        static readonly string _dbConString = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                               .AddJsonFile("appsettings.json", true, true)
                                                               .Build()["ConnectionString:DbConString"];
        public List<Book> SearchBooks(string searchKey, string categoryID)
        {
            List<Book> books = null;
            using (var con = new SqlConnection(_dbConString))
            {
                if (con!= null)
                {
                    string queryText = @" SELECT productID, productName, price, author, publisher, c.categoryName " +
                    " FROM tblProduct p join tblCategory c on p.categoryID = c.categoryID " +
                    " WHERE (productID = @id OR productName LIKE @name OR author like @name  OR publisher = @name) ";
                    if (categoryID != null)
                    {
                        queryText += $" AND p.categoryID = '{categoryID}' ";
                    }
                    books = con.Query<Book>(queryText, new {id = searchKey, name = $"%{searchKey}%" }).ToList<Book>();
                }
            }
            return books;
        }

        public Book GetBook(string bookID)
        {
            Book book = null;
            using (var con = new SqlConnection(_dbConString))
            {
                if (con!=null)
                {
                    string queryText = @" SELECT productID, productName, price, author, publisher, c.categoryName " +
                    " FROM tblProduct p join tblCategory c on p.categoryID = c.categoryID " +
                    " WHERE productID = @id";
                    book = con.Query<Book>(queryText, new { id = bookID }).FirstOrDefault();
                }
            }
            return book;
        }

        public List<Category> Categories()
        {
            List<Category> categories = new();
            using (var con = new SqlConnection(_dbConString))
            {
                if (con != null)
                {
                    string queryText = " SELECT categoryID, categoryName " +
                    " FROM tblCategory ";
                    categories = con.Query<Category>(queryText).ToList<Category>();
                }
            }
            return categories;
        }
    }
}
