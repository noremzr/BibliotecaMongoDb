using BibliotecaDLL.Contexts;
using BibliotecaDLL.Books;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca
{
    [Route("book")]
    public class BookController : Controller { 

        [HttpGet()]
        public ActionResult Get()
        {
            List<BookWithLoans> books = new List<BookWithLoans>();
            try
            {
                books = new BookDAO().GetBooks().OrderByDescending(x=>x.ListLoan.Count).ToList();
            }
            catch (Exception ex)
            {
                Problem(ex.Message);
            }
            return Ok(books);
        }

        [HttpPost()]
        public ActionResult Post([FromBody] Book book)
        {
            try
            {
                BookDAO bookDAO = new BookDAO();
                if (book.BookId == 0)
                {
                    book = bookDAO.InsertBook(book);
                }
                else { 
                book= bookDAO.UpdateBook(book);
                }
            }
            catch (Exception ex)
            {
                Problem(ex.Message);
            }
            return Ok(book);
        }

        [HttpDelete()]
        [Route("{bookId}")]
        public ActionResult Delete(int bookId)
        {
            try
            {
                Book book = new Book(bookId,string.Empty,string.Empty);
                new BookDAO().DeleteBook(book);
            }
            catch (Exception ex)
            {
                Problem(ex.Message);
            }
            return Ok();
        }
    }
}
