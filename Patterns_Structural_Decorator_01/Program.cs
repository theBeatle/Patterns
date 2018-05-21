using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Structural_Decorator_01
{
    abstract class Car
    {
        protected String BrandName { get; set; }
        public virtual void Go()
        {
            Console.WriteLine($"I'm {BrandName} and I'm on my way...");
        }
    }
    // Конкретна реалізація класу Car 
    class Mercedes : Car
    {
        public Mercedes()
        {
            BrandName = "Mercedes";
        }
    }

    abstract class DecoratorCar : Car
    {
        protected Car DecoratedCar { get; set; }
        public DecoratorCar(Car decoratedCar)
        {
            DecoratedCar = decoratedCar;
        }
        public override void Go()
        {
            Console.WriteLine($"My code is : {DecoratedCar.GetHashCode()}");
            DecoratedCar.Go();
        }
    }

    class AmbulanceCar : DecoratorCar //decorator class
    {
        public AmbulanceCar(Car decoratedCar) : base(decoratedCar) { }

        private string BipBip() => "Bip - bip - bip !!!";
        public override void Go()
        {
            base.Go();
            Console.WriteLine("... beep-beep-beeeeeep ...");
            Console.WriteLine(BipBip());
        }
    }

    class PoliceCar : DecoratorCar
    {
        public PoliceCar(Car decoratedCar) : base(decoratedCar) { }

        private string BlinkingLights() => "Blink blink !!!";

        public override void Go()
        {
            base.Go();
            Console.WriteLine(BlinkingLights());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Mercedes();
            myCar.Go();
            Console.WriteLine();

            Console.WriteLine("Decorated Medical car:");
            DecoratorCar doctorsDream = new AmbulanceCar(myCar);

            Console.WriteLine("DD2");
            var doctorsDream2 = new AmbulanceCar(myCar);
            //doctorsDream2 = new PoliceCar(myCar);
            new AmbulanceCar(myCar);
            doctorsDream2.Go();
            Console.WriteLine("DD2");

            doctorsDream.Go();

            Console.WriteLine();
            Console.WriteLine("Decorated Police car:");
            DecoratorCar policeDream = new PoliceCar(myCar);
            policeDream.Go();


            IEnumerable<DecoratorCar> dlist = new List<DecoratorCar> {doctorsDream, policeDream, doctorsDream2};


        }
    }
}
