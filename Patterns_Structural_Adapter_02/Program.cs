using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Structural_Adapter_02
{

    interface ITransport
    {
        void Drive();
    }
    class Auto : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("Car drives on the road");
        }
    }
    class Driver
    {
        public void Travel(ITransport transport)
        {
            transport.Drive();
        }
    }
 
    interface IAnimal
    {
        void Move();
    }
    class Camel : IAnimal
    {
        public void Move()
        {
            Console.WriteLine("Camel travels trought desert");
        }
    }

    // Adapter 
    class CamelToTransportAdapter : ITransport
    {
        private Camel camel;
        public CamelToTransportAdapter(Camel c)
        {
            camel = c;
        }

        public void Drive()
        {
            camel.Move();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //consummer code
            Driver driver = new Driver();

            Auto auto = new Auto();
            driver.Travel(auto);


            Camel camel = new Camel();
            
            // use adapter
            ITransport camelTransport = new CamelToTransportAdapter(camel);
            driver.Travel(camelTransport);

            Console.Read();
        }
    }
}
