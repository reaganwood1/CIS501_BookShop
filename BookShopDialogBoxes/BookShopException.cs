using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.ksu.cis.masaaki
{
    public class BookShopException: Exception
    {
        public string ErrorMessage { get; private set; }
        public BookShopException(string msg)
        {
            ErrorMessage = msg;
        }
    }
}
