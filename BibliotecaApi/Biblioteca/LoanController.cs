using BibliotecaDLL.Loans;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca
{
    [Route("loan")]
    public class LoanController : Controller
    {

        [HttpPost()]
        public ActionResult Post([FromBody] Loan loan)
        {
            try
            {
               loan= new LoanDAO().InsertLoan(loan);
            }
            catch (Exception ex)
            {
                Problem(ex.Message);
            }
            return Ok(loan);
        }

        [HttpPut()]
        public ActionResult Put([FromBody] Loan loan)
        {
            try
            {
                loan =new LoanDAO().UpdateLoan(loan);
            }
            catch (Exception ex)
            {
                Problem(ex.Message);
            }
            return Ok(loan);
        }
    }
}
