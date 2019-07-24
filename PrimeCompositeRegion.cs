using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class Solution
    {
        static int[,] array = new int[100, 100];
        static int m, n;
        public static void Main()
        {
            int number = System.Convert.ToInt32(Console.ReadLine());
            string ans = "";

            for (var i = 0; i < number; i++)
            {

                var mnValues = Console.ReadLine();
                string[] mn = mnValues.Split(' ');
                m = Convert.ToInt32(mn[0]);
                n = Convert.ToInt32(mn[1]);
                for (var r = 0; r < m; r++)
                {
                    var Values = Console.ReadLine();
                    string[] val = Values.Split(' ');
                    var c = 0;
                    foreach (var v in val)
                    {
                        array[r, c++] = Convert.ToInt32(v);
                    }
                }
                int pcounter = 0;
                int counter = 0;
                for (int r = 0; r < m; r++)
                {
                    for (int c = 0; c < n; c++)
                    {
                        if (array[r, c] != -1)
                        {
                            bool is_prime = isPrime(array[r, c]);
                            if (is_prime)
                                pcounter++;
                            else counter++;
                            Traverse(r, c, is_prime);
                        }
                    }

                }
                ans = ans + pcounter.ToString() + " " + counter.ToString() + "\n";
            }
            Console.WriteLine(ans);
        }
        static public bool isPrime(int number)
        {
            for (var i = 2; i <= number / 2; i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
        static public void Traverse(int r, int c, bool is_prime)
        {
            bool currentTraversePrime = isPrime(array[r, c]);
            if (array[r, c] == -1) return;
            else if (is_prime && !currentTraversePrime) return;
            else if (!is_prime && currentTraversePrime) return;
            array[r, c] = -1;
            if (r > 0) Traverse(r - 1, c, is_prime);
            if (r < m - 1) Traverse(r + 1, c, is_prime);
            if (c > 0) Traverse(r, c - 1, is_prime);
            if (c < n - 1) Traverse(r, c + 1, is_prime);
        }

    }
}
