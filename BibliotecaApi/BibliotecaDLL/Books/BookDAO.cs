using BibliotecaDLL.Contexts;
using BibliotecaDLL.Loans;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB;


namespace BibliotecaDLL.Books
{
    public class BookDAO
    {
        public List<BookWithLoans> GetBooks() {
            //Busca Livros Com Emprestimos
            MongoDbContext dbContext = new MongoDbContext();
            FilterDefinition<Book> filter = new BsonDocument();
            //Cria com o join dos tipos Book e Loan o tipo Que possui Books com loans para ter como lista no objeto
            return dbContext.Books.Aggregate().Lookup<Book, Loan, BookWithLoans>(
                dbContext.Loans,
                book => book.BookId,
                loan => loan.BookId,
                bookWithLoan => bookWithLoan.ListLoan
                ).ToList();
        }

        public Book InsertBook(Book book)
        {
            //InsereLivro
            ValidateBook(book);
            MongoDbContext dbContext = new MongoDbContext();
            Book bookBase = dbContext.Books.Aggregate().SortByDescending(x => x.BookId).FirstOrDefault();
            if (bookBase!=null) { 
            book.BookId = bookBase.BookId + 1;
            }
            else
            {
                book.BookId = 1;
            }
            dbContext.Books.InsertOne(book);
            return book;
        }

        public Book UpdateBook(Book book)
        {
            //Atualizo campos autor e titulo
            ValidateBook(book);
            MongoDbContext dbContext = new MongoDbContext();
            var filter = Builders<Book>.Filter.Where(e => e.BookId == book.BookId);
            var update = Builders<Book>.Update.Set(x => x.Title, book.Title).Set(x => x.Autor, book.Autor);
            dbContext.Books.UpdateOne(filter, update);
            return book;
        }


        public void DeleteBook(Book book)
        {
            //Deleta Livros
            MongoDbContext dbContext = new MongoDbContext();
            var filter = Builders<Book>.Filter.Where(e => e.BookId == book.BookId);
            dbContext.Books.DeleteOne(filter);

            //Deleta Empréstimo de Livros
            LoanDAO loanDAO = new LoanDAO();
            loanDAO.DeleteLoansByBook(book);
        }

        public void ValidateBook(Book book) {
            if (string.IsNullOrEmpty(book.Title)) {
                throw new ArgumentNullException(nameof(book.Title));
            }
            else if (string.IsNullOrEmpty(book.Autor))
            {
                throw new ArgumentNullException(nameof(book.Autor));
            }
        }
    }
}
