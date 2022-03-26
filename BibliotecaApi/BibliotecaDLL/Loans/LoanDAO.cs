using BibliotecaDLL.Books;
using BibliotecaDLL.Contexts;
using BibliotecaDLL.Loans;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDLL.Loans
{
    public class LoanDAO
    {
        public Loan InsertLoan(Loan loan)
        {
            MongoDbContext dbContext = new MongoDbContext();
            dbContext.Loans.InsertOne(loan);
            return loan;
        }

        public Loan UpdateLoan(Loan loan)
        {
            MongoDbContext dbContext = new MongoDbContext();
            var filter = Builders<Loan>.Filter.Where(e => e.BookId==loan.BookId && e.Returned ==null);
            var update = Builders<Loan>.Update.Set(x => x.Returned,loan.Returned);
            dbContext.Loans.UpdateOne(filter,update);
            return loan;
        }

        public void DeleteLoansByBook(Book book)
        {
            MongoDbContext dbContext = new MongoDbContext();
            var filter = Builders<Loan>.Filter.Where(e => e.BookId == book.BookId);
            dbContext.Loans.DeleteMany(filter);
        }
    }
}
