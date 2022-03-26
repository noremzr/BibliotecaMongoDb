using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDLL.Contexts
{
    public static class Connection
    {
        public static readonly string ConnectionString = "mongodb+srv://sa:sa12345@cluster0.iptzd.mongodb.net/test";
        public static readonly string DatabaseName = "Biblioteca";
    }
}
