using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1000000; i++)
            {
               if(check(i)) Console.WriteLine(i);
            }
        }

       static bool check(int v)
        {
            return (v % 2 == 1 &&
                    v % 3 == 0 &&
                    v % 4 == 1 &&
                    v % 5 == 4 &&
                    v % 6 == 3 &&
                    v % 7 == 0 &&
                    v % 8 == 1 &&
                    v % 9 == 0 
                    );
        }
    }
}
