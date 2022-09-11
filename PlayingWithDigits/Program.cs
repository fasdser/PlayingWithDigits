using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingWithDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(digPow(89, 1));
            Console.ReadLine();
        }

        public static long digPow(int n, int p)
        {
            Console.WriteLine(n);
            Console.WriteLine(p);
            char[] array = n.ToString().ToCharArray();
            int[] result = new int[array.Length];
            double endValue = 0;
            double c = p;
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = int.Parse(array[i].ToString());
            }

            for (int j = 0; j < result.Length; j++)
            {
                double d = result[j];
                endValue += Math.Pow(d, c);
                c++;
            }
            double k = endValue/n;
            if (Convert.ToInt32(k)!=k)
            {
                return -1;
            }
            if (endValue != n * k)
            {
                return -1;
            }


            return (long)k;
        }

        public static long digPow1(int n, int p)
        {
            var sum = Convert.ToInt64(n.ToString().Select(s => Math.Pow(int.Parse(s.ToString()), p++)).Sum());
            return sum % n == 0 ? sum / n : -1;
        }

        public static long digPow2(int n, int p)
        {
            var value = n.ToString()
                     .ToCharArray()
                     .Select(c => int.Parse(c.ToString()))
                     .Select((d, idx) => Math.Pow(d, idx + p))
                     .Sum();


            if ((value % n) != 0) return -1;
            return (long)value / n;
        }

        public static long digPow3(int n, int p)
        {
            int countOfDigitsMinusOne = (int)Math.Log10(n);
            p = p + countOfDigitsMinusOne;
            int nk = 0;
            int N = n;
            while (N != 0)
            {
                int digit = N % 10;
                nk += (int)Math.Pow(digit, p);
                N /= 10;
                p--;
            }
            if (nk % n == 0)
                return nk / n;
            return -1;
        }
    }
}
