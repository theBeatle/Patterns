using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> {2, 3, 4, 5, 7, 10, 11, 12, 13, 14, 15};
            var result = new List<int>();
            var rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                bool flag = false;
                while (!flag)
                {
                    var number = rnd.Next(0, list.Count);
                    if (list[number] != 0)
                    {
                        result.Add(list[number]);
                        list[number] = 0;
                        flag = true;
                    }
                }
            }

            foreach (var item in result)
            {
                Console.WriteLine($"The lucky Winner is number {item}");
            }


        }
    }
}
