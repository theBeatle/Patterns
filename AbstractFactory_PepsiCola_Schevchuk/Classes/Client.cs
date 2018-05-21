using System;

namespace AbstractFactory
{
    class Client
    {

        private AbstractFactory factory;
        private AbstractWater water;
        private AbstractBottle bottle;

        public Client(AbstractFactory factory)
        {
            this.factory = factory;
            water = factory.CreateWater();
            bottle = factory.CreateBottle();
        }


        public string GetFactoryInfo() => factory.GetType().FullName;



        public void ChangeFactory(AbstractFactory factory)
        {
            this.factory = factory;
            water = factory.CreateWater();
            bottle = factory.CreateBottle();
        }

        public void Run()
        {
            bottle.Interact(water);
        }
    }
}
