using System;

namespace Patterns_Structural_Adapter
{
    // Система яку будемо адаптовувати
    class OldElectricitySystem
    {
        public string MatchThinSocket()
        {
            return "127";
        }
    }
    // Широковикористовуваний інтерфейс нової системи (специфікація до квартири) 
    interface INewElectricitySystem
    {
        int MatchWideSocket();
    }
    // Ну і власне сама розетка у новій квартирі 
    class NewElectricitySystem : INewElectricitySystem
    {
        public int MatchWideSocket()
        {
            return 220;
        }
    }

    class Adapter : INewElectricitySystem
    {
        // Але всередині він таки знає, що коїлося в СРСР     
        private readonly OldElectricitySystem _adaptee;
        public Adapter(OldElectricitySystem adaptee)
        {
            _adaptee = adaptee;
        }
        // А тут відбувається вся магія -     
        // наш адаптер «перекладає»     
        // функціональність із нового стандарту на старий
        public int MatchWideSocket()
        {
            // Якщо б була різниця в напрузі (не 220V)
            // то тут ми б помістили трансформатор
            return Int32.Parse(_adaptee.MatchThinSocket())*2;
        }

    }

    class ElectricityConsumer
    {
        // Зарядний пристрій розуміє тільки нову систему     
        public static void ChargeNotebook(INewElectricitySystem electricitySystem)
        {
            Console.WriteLine(electricitySystem.MatchWideSocket());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1)         
            // Ми можемо користуватися новою системою без проблем
            var newElectricitySystem = new NewElectricitySystem();

            ElectricityConsumer.ChargeNotebook(newElectricitySystem);

            // 2)   
            // Ми повинні адаптуватися до старої системи, використовуючи адаптер         
            var oldElectricitySystem = new OldElectricitySystem();
            var adapter = new Adapter(oldElectricitySystem);

            ElectricityConsumer.ChargeNotebook(adapter); 
        }
    }
}
