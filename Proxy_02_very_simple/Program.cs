using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proxy_02_very_simple
{
    public class Subject
    {
        public virtual void Print()
        {
            Console.WriteLine("this is a print");
        }
    }

    public class SubjectProxy : Subject
    {
        public override void Print()
        {
            Console.Write("Before calling base.Print()\n");
            if (DateTime.Now.Second > 30 )
            {
                base.Print();
            }
            else
            {
                Console.WriteLine("Access denied!!!");
            }

            Console.Write("After calling base.Print()\n");
        }
    }
    public class Helper
    {
        public static Subject GetSubject()
        {
            return (Subject)new SubjectProxy();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Subject subject = Helper.GetSubject();

            for (int i = 0; i < 100; i++)
            {
                subject.Print();
                Thread.Sleep(1000);
            }
            subject.Print(); // would use the proxied method
        }
    }
}
