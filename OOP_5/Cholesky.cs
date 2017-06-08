using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_5
{
    public class Cholesky<T> : MatrixOperation<T>, Selection
    {
        public void Method()
        {
        }
        public object Result()
        {
            object r = new T[3, 3];
            return r;
        }
        public void Something()
        {
        }
        public object Result(T[] newfunc)
        {
            object d = new T[3, 3];
            return d;
        }
    }
}
