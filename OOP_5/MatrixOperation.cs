using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_5
{
    public class MatrixOperation<T>: Mysystem
    {
        public T Norm1(T[,] koef)
        {
            int n = koef.GetLength(0);
            T[] a = new T[n];
            for (int i = 0; i < n; i++)
            {
                //for (int j = 0; j < n; j++) a[i] += //Math.Abs(koef[i, j]);
            }
            return a.Max();
        }
        public T Norm2(T[,] koef)
        {
            int n = koef.GetLength(0);
            T[] a = new T[n];
            for (int i = 0; i < n; i++)
            {
                //for (int j = 0; j < n; j++) a[i] += Math.Abs(koef[j, i]);
            }
            return a.Max();
        }
        public T Norm(T[] result, T[] res)
        {
            T[] a = new T[result.Length];
            for (int i = 0; i < result.Length; i++)
            {
                //a[i] = Math.Abs(result[i] - res[i]);
            }
            return a.Max();
        }
        public T Determinant(T[,] koef)
        {
            T det = koef[0,0];
            int n = koef.GetLength(0);
            if (n == 1) det = koef[0, 0];
            //else if (n == 2) det = koef[0, 0] * koef[1, 1] - koef[0, 1] * koef[1, 0];
            //else det = koef[0, 0] * (koef[1, 1] * koef[2, 2] - koef[1, 2] * koef[2, 1]) - koef[0, 1] * (koef[1, 0] * koef[2, 2] - koef[1, 2] * koef[2, 0]) + koef[0, 2] * (koef[1, 0] * koef[2, 1] - koef[1, 1] * koef[2, 0]);
            return det;
        }
        public T[] Sum(T[] one, T[] two)
        {
            T[] three = new T[one.Length];
            return three;
        }
        public T[,] Sum(T[,] one, T[,] two)
        {
            T[,] three = new T[one.GetLength(0),one.GetLength(1)];
            return three;
        }
        public T[] Decr(T[] one, T[] two)
        {
            T[] three = new T[one.Length];
            return three;
        }
        public T[,] Decr(T[,] one, T[,] two)
        {
            T[,] three = new T[one.GetLength(0), one.GetLength(1)];
            return three;
        }
    }
}
