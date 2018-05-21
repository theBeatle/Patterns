using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricMethod_02
{
    public interface IAbstractVehicle
    {
        void Drive(int miles);
    }

    public class Scooter : IAbstractVehicle
    {
        public void Drive(int miles)
        {
            Console.WriteLine($"Drive the {this.GetType().Name }  : { miles } miles");
        }
    }

    public class Bike : IAbstractVehicle
    {
        public void Drive(int miles)
        {
            Console.WriteLine($"Drive the {this.GetType().Name }  : { miles } miles");
        }
    }

    public class Airplane : IAbstractVehicle
    {
        public void Drive(int miles)
        {
            Console.WriteLine($"Fly the {this.GetType().Name }  : { miles * miles } miles");
        }
    }

    public abstract class VehicleFactory
    {
        public virtual IAbstractVehicle GetVehicle(string Vehicle)
        {
            return new Scooter();
        }


    }

    public class AirPlaneBuilder : VehicleFactory
    {
        public override IAbstractVehicle GetVehicle(string Vehicle)
        {
            if (Vehicle == "Boing")
            {
                return new Airplane();
            }
            return null;
        }
    }



    public class ConcreteVehicleFactory : VehicleFactory
    {
        public override IAbstractVehicle GetVehicle(string Vehicle)
        {
            switch (Vehicle)
            {
                case "Scooter":
                    return new Scooter();
                case "Bike":
                    return new Bike();
                default:
                    throw new ApplicationException($"Vehicle '{Vehicle}' cannot be created");
            }
        }

    }

    public class NewFactory : VehicleFactory
    {
        public override IAbstractVehicle GetVehicle(string Vehicle)
        {
            if (DateTime.Now.Second > 30) return new Bike();
            return new Scooter();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //VehicleFactory factory = new NewFactory();
            ICollection<VehicleFactory> storage = new List<VehicleFactory>
            {
                new NewFactory(),
                new AirPlaneBuilder()
            };
            ICollection<IAbstractVehicle> autoPark = new List<IAbstractVehicle>
            {
                storage.ElementAt(0).GetVehicle("Scooter"),
                storage.ElementAt(1).GetVehicle("Lockhead")
            };
            //IAbstractVehicle scooter = storage.ElementAt(0).GetVehicle("Scooter");
            //scooter.Drive(10);
            //IAbstractVehicle bike = storage.ElementAt(0).GetVehicle("Bike");
            //bike.Drive(20);
            foreach (var item in autoPark)
            {
                Console.WriteLine($"{item}");

            }
            Console.ReadKey();
        }
    }
}
