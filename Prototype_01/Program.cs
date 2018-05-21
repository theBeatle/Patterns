using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_01
{
    abstract class Prototype
    {
        public int MyProperty { get; set; }

        public Prototype()
        {

        }


        public Prototype(int id)
        {
            MyProperty = id;
        }

        public abstract Prototype Clone();
    }

    class ConcretePrototype1 : Prototype
    {

        public ConcretePrototype1(int id) : base(id) { }

        //shallow copy
        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }

    class ConcretePrototype2 : Prototype
    {
        public ConcretePrototype2()
        {

        }
        public int MyProperty { get; set; }

        public ConcretePrototype2(int id) : base(id) { }

        //shallow copy
        public override Prototype Clone()
        {
           // return (Prototype)this.MemberwiseClone();
            //return new ConcretePrototype2(this.Id);
            return new ConcretePrototype2() { MyProperty = this.MyProperty };

        }
    }

    class ConcretePrototype3 : ICloneable
    {
        private string _id;

        public ConcretePrototype3(string id) { this._id = id; }

        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }

        //shallow copy

    }

    class MainApp
    {

        static void Main()
        {
            // Create two instances and clone each




            ConcretePrototype1 p1 = new ConcretePrototype1("I");
            var c1 = p1.Clone();
            Console.WriteLine($"Cloned: {(c1 as ConcretePrototype1).Id}");

            ConcretePrototype2 p2 = new ConcretePrototype2("II");
            //ConcretePrototype2 c2 = (ConcretePrototype2)p1.Clone();
            ConcretePrototype2 c3 = (p1.Clone()) as ConcretePrototype2;
            Console.WriteLine($"Cloned: {c3?.Id}");
        }
    }
}
