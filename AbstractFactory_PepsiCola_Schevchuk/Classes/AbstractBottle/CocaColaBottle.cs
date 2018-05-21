using System;

namespace AbstractFactory
{
    class CocaColaBottle : AbstractBottle
    {
        public override void Interact(AbstractWater water)
        {
            Console.WriteLine(this.GetType().FullName + " interacts with " + water);
        }
    }
}
