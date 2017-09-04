using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoCharacters
{
    class Program
    {
        static void Main(String[] args)
        {
            //int len = Convert.ToInt32(Console.ReadLine());
            string s = "beabeefeab";


            var h = new HashSet<char>(s);

            int count = 0;
            if (h.Count <= 2)
                count = GetLength(s);
            else
            {
                var l = GetPerm(h.ToArray());

                foreach (var c in l)
                {
                    string r = new String(s.Where(sc => sc == c[0] || sc == c[1]).ToArray());
                    var t = GetLength(r);

                    //Console.WriteLine($"{c[0]}:{c[1]} {r} = {t}");
                    count = Math.Max(count, t);
                }
            }

            Console.Write(count);
            Console.ReadKey();
        }

        private static IEnumerable<char[]> GetPerm(char[] h)
        {
            for (int i = 0; i < h.Length; i++)
            {
                for (int j = i + 1; j < h.Length; j++)
                    yield return new char[] { h[i], h[j] };
            }
        }

        static int GetLength(string s)
        {

            if (s.Length < 2)
                return 0;

            char l1 = s[0];
            char l2 = s[1];

            if (l1 == l2)
                return 0;

            for (int i = 2; i < s.Length; i++)
            {
                if (i % 2 == 0 && s[i] == l1)
                    continue;

                if (i % 2 != 0 && s[i] == l2)
                    continue;

                return 0;
            }

            return s.Length;

        }
    }



}
