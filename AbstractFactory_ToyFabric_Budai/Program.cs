using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_ToyFabric_Budai
{
    public abstract class AnimalToy
    {
        public string Name { get; private set; }

        protected AnimalToy(string name) => this.Name = name;

        protected AnimalToy()
        {

        }
    }
    public abstract class Cat : AnimalToy
    {
        protected Cat(string name) : base(name) { }
    }
    public abstract class Bear : AnimalToy
    {
        protected Bear(string name) : base(name) { }
    }
    public abstract class Rabbit : AnimalToy
    {
        protected Rabbit(string name) : base(name) { }
    }
    class WoodenCat : Cat
    {
        public WoodenCat() : base("Wooden Cat") { }
    }
    class TeddyCat : Cat
    {
        public TeddyCat() : base("Teddy Cat") { }
    }
    class WoodenBear : Bear 
    {
        public WoodenBear() : base("Wooden Bear") { }
    }
    class TeddyBear : Bear
    {
        public TeddyBear() : base("Teddy Bear") { }
    }
    class WoodenRabbit : Rabbit
    {
        public WoodenRabbit() : base("Wooden Rabbit") {}
    }
    class TeddyRabbit : Rabbit
    {
        public TeddyRabbit() : base("Teddy Rabbit") { }
    }
    // abstract factory
    public interface IToyFactory
    {
        Bear GetBear();
        Cat GetCat();
        Rabbit GetRabbit();
    }
    // concrete factory
    public class TeddyToysFactory : IToyFactory
    {
        public Bear GetBear()
        {
            return new TeddyBear();
        }
        public Cat GetCat()
        {
            return new TeddyCat();
        }
        public Rabbit GetRabbit()
        {
            return new TeddyRabbit();
        }
    }
    public class WoodenToysFactory : IToyFactory
    {
        public Bear GetBear()
        {
            return new WoodenBear();
        }
        public Cat GetCat()
        {
            return new WoodenCat();
        }

        public Rabbit GetRabbit()
        {
            return new WoodenRabbit();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IToyFactory toyFactory = new WoodenToysFactory();
            ICollection<AnimalToy> toys = new List<AnimalToy>
            {
                //Bear bear = toyFactory.GetBear();
                //Cat cat = toyFactory.GetCat();
                //Rabbit rabbit = toyFactory.GetRabbit();
                //Console.WriteLine($"I've got { bear.Name } and {cat.Name} and {rabbit.Name}");
                toyFactory.GetBear(),
                toyFactory.GetCat(),
                toyFactory.GetRabbit()
            };

            toyFactory = new TeddyToysFactory();

            toys.Add(toyFactory.GetBear());
            toys.Add(toyFactory.GetCat());
            toys.Add(toyFactory.GetRabbit());

            foreach (var item in toys)
            {
                Console.WriteLine($"{item.Name}");
            }


            //bear = toyFactory.GetBear();
            //cat = toyFactory.GetCat();
            //rabbit = toyFactory.GetRabbit();
            //Console.WriteLine($"I've got { bear.Name } and {cat.Name} and {rabbit.Name}");
        }
    }
}
