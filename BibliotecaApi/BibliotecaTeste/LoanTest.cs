using BibliotecaDLL.Loans;
using System;
using Xunit;

namespace BibliotecaTeste
{
    public class LoanTest { 
    [Fact]
    public void ValidacaoLoan()
    {
        Loan loan = new Loan("Pedro",1, DateTime.Now,null);
        Assert.NotEqual(string.Empty, loan.UserId);
        Assert.NotEqual(DateTime.MinValue, loan.Borrowed);
        Assert.NotEqual(0, loan.BookId);
    }
    }
}
