using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_5
{
    public class MPI<T> : MatrixOperation<T>, Selection
    {
        public void Method()
        {
        }

        public object Result()
        {
            object r = new T[9, 9];
            return r;
        }

        public void Something()
        {
        }
    }
}
