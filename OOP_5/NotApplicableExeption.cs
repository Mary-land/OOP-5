using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_5
{
    public class NotApplicableExeption : ApplicationException
    {
        public NotApplicableExeption() { }

        public NotApplicableExeption(string message) : base(message) { }

        public NotApplicableExeption(string message, Exception inner) : base(message, inner) { }

    }
}
