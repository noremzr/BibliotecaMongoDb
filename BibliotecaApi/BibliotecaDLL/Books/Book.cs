using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using BibliotecaDLL.Loans;
using MongoDB.Bson.Serialization.Attributes;

namespace BibliotecaDLL.Books
{
    [BsonIgnoreExtraElements]
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Autor { get; set; }

        public Book(int bookId, string title, string autor)
        {
            this.BookId= bookId;
            this.Title= title;
            this.Autor = autor;
        }
    }
    [BsonIgnoreExtraElements]
    public class BookWithLoans : Book
    {
        public BookWithLoans(int bookId, string title, string autor,List<Loan> listLoans) :base(bookId,title,autor)
        {
            this.ListLoan = listLoans;
        }
       
        public List<Loan> ListLoan { get; set; } = new List<Loan>();

        public Loan? LastLoan
        {
            get {
                return ListLoan.OrderByDescending(loan => loan.Borrowed).FirstOrDefault();
            }
        }

    }
}
