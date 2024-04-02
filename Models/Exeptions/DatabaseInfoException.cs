using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace www.Boss.org.az.Models.Exeptions
{
    class DatabaseInfoException : ApplicationException
    {
        public DatabaseInfoException(string message) : base(message) { }
    }
}
