using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_5
{
    public class Equation: Mysystem
    {
        public object equation;
        public void Deriviate() { }
        public void TwoDeriviate() { }
        public double Func() { throw new NotApplicableExeption(); }
    }
}
