using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Structural_Composite_02
{
    class Program
    {
        abstract class Component
        {
            protected string name;
            protected Component(string name)
            {
                this.name = name;
            }

            public abstract void Display(int depth);
        }

        class Composite : Component
        {
            private readonly List<Component> children = new List<Component>();
            public Composite(string name) : base(name)
            {
            }
            public void Add(Component component)
            {
                children.Add(component);
            }
            public void Remove(Component component)
            {
                children.Remove(component);
            }
            public override void Display(int depth)
            {
                Console.WriteLine(new String('-', depth) + name);
                foreach (Component component in children)
                {
                    component.Display(depth + 3);
                }
            }
        }

        class Leaf : Component
        {
            public Leaf(string name) : base(name)
            {
            }

            public override void Display(int depth)
            {
                Console.WriteLine(new String('-', depth) + name);
            }
        }

        static void Main()
        {

            Composite root = new Composite("root");

            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            Composite comp = new Composite("Composite X");

            comp.Add(new Leaf("Leaf XA"));
            comp.Add(new Leaf("Leaf XB"));

            root.Add(comp);

            root.Add(new Leaf("Leaf C"));

            Leaf leaf = new Leaf("Leaf D");
           // root.Display(9);
            root.Add(leaf);
            //root.Display(9);
            //root.Remove(leaf);
            root.Display(6);
            // Recursively display tree
            //root.Display(9);
           root.Remove(comp);
            Console.WriteLine();
            root.Display(6);
            Console.Read();
        }
    }
}
