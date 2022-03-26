using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDLL.Loans
{
    [BsonIgnoreExtraElements]
    public class Loan
    {
        public string UserId { get; set; }
        public int BookId { get; set; }
        public DateTime Borrowed { get; set; }
        public DateTime? Returned { get; set; }

        public Loan(string userId, int bookId, DateTime borrowed, DateTime? returned) {
            this.UserId = userId;
            this.BookId = bookId;
            this.Borrowed = borrowed;
            this.Returned = returned;
        }

    }
}
