using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_5
{
    /*class NonlinearEquations<T>
    {
        private double a, b;
        private double[] arr;
        public NonlinearEquations(T begin,T end, T[] equation)
        {
            a = Convert.ToDouble(begin);
            b = Convert.ToDouble(end);
            arr = new double[equation.Length];
            Array.Copy(equation, arr, equation.Length);
        }
        public double Derivative(double x, Func<double, double> Function)
        {
            double dx = 1E-7, result = (Function(x + dx) - Function(x)) / dx;
            return result;
        }
        public double TwoDerivative(double x, Func<double, double> Function)
        {
            double dx = 1E-6, result = (Derivative(x + dx, Function) - Derivative(x, Function)) / dx;
            return result;
        }
        public double Function(double x)
        {
            double y = 0;
            int n = arr.Length;
            for (int i = 0; i < n; i++) y += arr[i] * Math.Pow(x, n - 1 - i);
            return y;
        }
        public void AccurateMethod()
        {
            double x = a, c = 0;
            if (Derivative(a, Function) * Derivative(b, Function) > 0 && TwoDerivative(a, Function) * TwoDerivative(b, Function) > 0 && Function(a) * Function(b) < 0)
            {
                if (Function(a) * TwoDerivative(a, Function) > 0) { x = a; }
                else if (Function(b) * TwoDerivative(b, Function) > 0) { x = b; }
                else
                {
                    Random rnd = new Random();
                    while (Function(x) * TwoDerivative(x, Function) <= 0)
                    {
                        x = a + rnd.Next(Convert.ToInt32(a), Convert.ToInt32(b)) / 10;
                    }
                }
                if (Function(x) != 0)
                {
                    while (Math.Abs(x - Math.Pow(10, -4)) > Math.Abs(Function(x)) / Math.Min(Derivative(a, Function), Derivative(b, Function)))
                    {
                        c = x;
                        x = x - Function(x) / Derivative(x, Function);
                        if (Function(x) == 0 || Math.Abs(x - c) < 1E-12) { break; }
                    }
                }
            }
            else { throw new NotApplicableException("Newton"); }
        }
        public void ApproximateMethod()
        {
            double x, k = 0, c = 0;
            if (Derivative(a, Function) * Derivative(b, Function) > 0 && TwoDerivative(a, Function) * TwoDerivative(b, Function) > 0 && Function(a) * Function(b) < 0)
            {
                if (Derivative(a, Function) > 0) { k = 2 / (Math.Abs(Derivative(a, Function)) + Math.Abs(Derivative(b, Function))); }
                else { k = -2 / (Math.Abs(Derivative(a, Function)) + Math.Abs(Derivative(b, Function))); }
                x = (b + a) / 2;
                if (Function(x) != 0)
                {
                    while (Math.Abs(x - Math.Pow(10, -3)) > Math.Abs(Function(x)) / Math.Min(Derivative(a, Function), Derivative(a, Function)))
                    {
                        c = x;
                        x = x - k * Function(x);
                        if (Function(x) == 0 || Math.Abs(x - c) < 1E-12) { break; }
                    }
                }
            }
            else { throw new NotApplicableException("Iteration"); }
        }
        public void EasyMethod()
        {
            double x;
            if (Function(a) * Function(b) < 0)
            {
                x = (b + a) / 2;
                if (Function(x) * Function(b) < 0) { a = x; }
                else { b = x; }
                while ((b - a) > 2 * Math.Pow(10, -3))
                {
                    x = (b + a) / 2;
                    if (Function(x) == 0) { break; }
                    if (Function(x) * Function(b) < 0) { a = x; }
                    else { b = x; }
                }
            }
            else { throw new NotApplicableException("Bisection method");}
        }
    }
    class SLAU
    {
        private double[,] matrix; private double[] result;
        public SLAU(double[,] matr)
        {
            matrix = new double[matr.GetLength(0), matr.GetLength(1)];
            result = new double[matr.GetLength(0)];
            Array.Copy(matr, matrix, matr.GetLength(1) * matr.GetLength(1));
        }
        public void AccurateMethod()
        {
            if (Determinant(koef) != 0)
            {
                int n = koef.GetLength(0);
                double[,] c = new double[n, n];
                double[,] b = new double[n, n];
                for (int i = 0; i < n; i++)
                {
                    c[i, 0] = koef[0, i];
                    b[0, i] = koef[0, i] / c[0, 0];
                    b[i, i] = 1;
                }
                for (int i = 1; i < n; i++)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        c[i, j] = koef[i, j];
                        b[j, i] = koef[j, i];
                        for (int k = 0; k <= j - 1; k++)
                        {
                            c[i, j] -= c[i, k] * b[k, j];
                            b[j, i] -= c[i, k] * b[k, j];
                        }
                        b[j, i] /= c[j, j];
                    }
                }
                double[] y = new double[n];
                for (int i = 0; i < n; i++)
                {
                    y[i] = koef[i, n];
                    for (int j = 0; j < i; j++) y[i] -= c[i, j] * y[j];
                    y[i] /= c[i, i];
                }
                for (int i = n - 1; i >= 0; i--)
                {
                    result[i] = y[i];
                    for (int j = i + 1; j < n; j++) result[i] -= b[i, j] * result[j];
                }
            }
            else throw new NotApplicableException("Cholesky");
        }
        public void ApproximateMethod()
        {
            if (Determinant(koef) != 0)
            {
                int n = koef.GetLength(0), count = 1;
                double[,] at = new double[n, n];
                double[,] two = new double[n, n];
                double tmp;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                        at[i, j] = koef[j, i];
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        for (int k = 0; k < n; k++)
                            two[i, j] += at[i, k] * koef[k, j];
                    }
                }
                if (Norm1(two) > Norm2(two)) tmp = 1 / Norm1(two);
                else tmp = 1 / Norm2(two);
                double[] g = new double[n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        g[i] += tmp * at[i, j] * koef[j, n];
                    }
                }
                Array.Clear(at, 0, n * n);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (j == i) at[i, j] = 1 - tmp * two[i, j];
                        else at[i, j] = 0 - tmp * two[i, j];
                    }
                }
                double[] res = new double[n];
                Array.Copy(g, res, 3);
                while (true)
                {
                    Array.Clear(result, 0, 3);
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            result[i] += at[i, j] * res[j];
                        }
                        result[i] += g[i];
                    }
                    count++;
                    if (Norm(result, res) <= 0.0001) break;
                    Array.Copy(result, res, 3);
                }
                Console.WriteLine("Number of steps: {0}", count);
            }
            else throw new NotApplicableException("Iteration");
        }
        public void EasyMethod()
        {
            double tmp;
            int n = matrix.GetLength(1);
            if (Determinant(koef) != 0)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    tmp = koef[i, i];
                    for (int j = i; j < n; j++)
                        koef[i, j] /= tmp;
                    for (int j = i + 1; j < n - 1; j++)
                    {
                        tmp = koef[j, i];
                        for (int k = i; k < n; k++)
                            koef[j, k] -= tmp * koef[i, k];
                    }
                }
                result[n - 2] = koef[n - 2, n - 1];
                for (int i = n - 3; i >= 0; i--)
                {
                    result[i] = koef[i, n - 1];
                    for (int j = i + 1; j < n - 1; j++) result[i] -= koef[i, j] * result[j];
                }
            }
            else throw new NotApplicableException("Gauss");
        }
    }*/
    class Program
    {
        static void Main(string[] args)
        {
            //double[,] matr = { { 1, 2 }, { 3, 4 } };
            //NonlinearEquations<double> one = new NonlinearEquations<double>(2, 3);
            Console.ReadKey();
        }
    }
}
