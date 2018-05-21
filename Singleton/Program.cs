using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            //UsefullClass.getInstance();

            Console.WriteLine(SingletonLazyFull.Instance.ToString());
            SingletonLazyFull.Instance.MyProperty = 4567890;
            Console.WriteLine(SingletonLazyFull.Instance.MyProperty);


        }
    }
}
