using System;
using System.Linq;

namespace PN9
{
    class Program
    {
        static void Main(string[] args)
        {
            var pn9 = new PN9();
            var series = Enumerable.Range(1, 511)
                        .Select(i => pn9.GetNext())
                        .ToArray();

            var output = series.Aggregate("", (acc,el) => $"{acc}{bits(el, 8)}  {el}\n");
            Console.Write(output);
            Console.ReadKey();
        }

        static string bits(int b, int length = 8)
        {
            return new string(Enumerable.Range(0, length)
                                  .Select(i => ((b >> i) & 1) == 0 ? '0' : '1')
                                  .Reverse()
                                  .ToArray());
        }
    }
}
