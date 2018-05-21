using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = null;

            AbstractFactory factory = new CocaColaFactory();
            client = new Client(factory);
            client.Run();

            factory = new PepsiFactory();

            client.ChangeFactory(factory);   // = new Client(factory);
            Console.WriteLine(client.GetFactoryInfo());
            client.Run();
        }
    }
}
