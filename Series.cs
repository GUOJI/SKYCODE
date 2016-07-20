using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyCode
{
    class Series
    {
        public static int[] Fibonacci(int S, int E)
        {
            Func<int, int> fib = null;
            fib = n => n > 1 ? fib(n - 1) + fib(n - 2) : n;
            int start = S;
            int end = E;
            return Enumerable.Range(start, end).Select(fib).ToArray();
        }
    }
}
