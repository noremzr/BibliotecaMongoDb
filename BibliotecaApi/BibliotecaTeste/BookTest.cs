using BibliotecaDLL.Books;
using Xunit;

namespace BibliotecaTeste
{
    public class BookTest
    {
        [Fact]
        public void ValidacaoAutor()
        {
            Book book = new Book(0,"Harry Potter","João");
            Assert.NotEqual(string.Empty, book.Autor);
            Assert.NotEqual(string.Empty, book.Title);
        }
    }
}