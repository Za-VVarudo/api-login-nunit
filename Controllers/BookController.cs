using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using BookAPI.Models.BookModels;
using BookAPI.Models;


namespace BookAPI.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class BookController : Controller
    {       
        [HttpGet("Search")]
        public IActionResult GetBooks(string searchKey, string categoryID)
        {
            if (searchKey == null) searchKey = "";
            var bookList = new BookManagement().SearchBooks(searchKey, categoryID);
            var categoryList = new BookManagement().Categories();
            Tuple<List<Book>, List<Category>> tuple = new(bookList, categoryList);
            return Json(tuple);
        }

        [HttpGet("Get")]
        public IActionResult GetBook(string bookID)
        {
            if (bookID == null) bookID = "";
            var book = new BookManagement().GetBook(bookID);
            return Json(book);
        }
    }
}
