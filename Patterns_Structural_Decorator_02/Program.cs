using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Structural_Decorator_02
{
    public interface IVehicle
    {
        string Make { get; }
        string Model { get; }
        double Price { get; }
    }
    public class HondaCity : IVehicle
    {
        public string Make => "HondaCity";

        public string Model => "Civic";

        public double Price => 20000;
    }
    public class VehicleDecorator : IVehicle
    {
        private IVehicle _vehicle;
        public VehicleDecorator(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }
        public string Make => _vehicle.Make;
        public string Model => _vehicle.Model;
        public virtual double Price => _vehicle.Price;
    }

    public class SpecialOffer : VehicleDecorator
    {
        public SpecialOffer(IVehicle vehicle) : base(vehicle) { }
        public int DiscountPercentage { get; set; }
        public string Offer { get; set; }
        public override double Price
        {
            get
            {
                double price = base.Price;
                int percentage = 100 - DiscountPercentage;
                return Math.Round((price * percentage) / 100, 2);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Basic vehicle
            HondaCity car = new HondaCity();
            Console.WriteLine($"Honda City base price are : {car.Price}");
            SpecialOffer offer = new SpecialOffer(car)
            {
                DiscountPercentage = 20
            };
            offer.Offer = $"{offer.DiscountPercentage}% discount";
            Console.WriteLine($"{offer.Offer} @ Diwali Special Offer and price are : {offer.Price}");
            Console.ReadKey();
        }
    }
}
