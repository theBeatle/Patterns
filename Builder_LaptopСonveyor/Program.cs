
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_LaptopСonveyor
{
    public abstract class Part
    {
        public Vendor Vendor { get; set; }
        public int SerialNumber { get; set; }

        public override string ToString() => $"{Vendor} Sn: {SerialNumber}";

    }

    public class Vendor
    {
        public string Name { get;  set; }

        public override string ToString() => $"Vendor Name {Name}";

    }

    public class Processor : Part
    {
        public override string ToString() => base.ToString();
    }

    public class Laptop
    {
        public string MonitorResolution { get; set; }
        public Processor Processor { get; set; }
        public string Memory { get; set; }
        public string HDD { get; set; }
        public string Battery { get; set; }
        public override string ToString()
            => $"{MonitorResolution } {Processor} { Memory} {HDD} {Battery}";
    }

     
    //Builder
    public abstract class LaptopBuilder
    {
        protected Laptop Laptop { get; private set; }
        public void CreateNewLaptop()
        {
            Laptop = new Laptop();
        }
        public Laptop GetMyLaptop()
        {
            return Laptop;
        }

        public abstract void SetMonitorResolution();
        public abstract void SetProcessor();
        public abstract void SetMemory();
        public abstract void SetHDD();
        public abstract void SetBattery();
    }

    //concrete Bulder
    public class GamingLaptopBuilder : LaptopBuilder
    {
        public override void SetMonitorResolution()
        {

            Laptop.MonitorResolution = "1900X1200";
        }
        public override void SetProcessor()
        {
            Laptop.Processor = new Processor()
            {
                Vendor = new Vendor() { Name = "Cyrix" },
                SerialNumber = 999
            };
        }
        public override void SetMemory()
        {
            Laptop.Memory = "8192 Mb";
        }
        public override void SetHDD()
        {
            Laptop.HDD = "500 Gb";
        }
        public override void SetBattery()
        {
            Laptop.Battery = "6 lbs";
        }
    }

    public class TripLaptopBuilder : LaptopBuilder
    {
        public override void SetMonitorResolution()
        {
            Laptop.MonitorResolution = "1280X800";
        }
        public override void SetProcessor()
        {
            Laptop.Processor = new Processor()
            {
                Vendor = new Vendor() { Name = "AMD" },
                SerialNumber = 666
            }; 
        }
        public override void SetMemory()
        {
            Laptop.Memory = "2048 Mb";
        }
        public override void SetHDD()
        {
            Laptop.HDD = "320 Gb";
        }
        public override void SetBattery()
        {
            Laptop.Battery = "90 lbs";
        }
    }

    public class KTC

    {
        private LaptopBuilder _laptopBuilder;
        public void SetLaptopBuilder(LaptopBuilder lBuilder)
        {
            _laptopBuilder = lBuilder;
        }

        public Laptop GetLaptop()
        {
            return _laptopBuilder.GetMyLaptop();
        }

        public void ConstructLaptop()
        {
            if (_laptopBuilder != null)
            {
                _laptopBuilder?.CreateNewLaptop();
                _laptopBuilder?.SetMonitorResolution();
                _laptopBuilder?.SetProcessor();
                _laptopBuilder?.SetMemory();
                _laptopBuilder?.SetHDD();
                _laptopBuilder?.SetBattery();
            }
        }
    }




    class Program
    {
        static void Main(string[] args)
        {


            var tripBuilder = new TripLaptopBuilder();
            var gamingBuilder = new GamingLaptopBuilder();

            var shopForYou = new KTC();

            shopForYou.SetLaptopBuilder(tripBuilder);
            shopForYou.ConstructLaptop();
            Laptop laptop = shopForYou.GetLaptop();
            Console.WriteLine(laptop);
            Console.WriteLine("----------------------");

            shopForYou.SetLaptopBuilder(gamingBuilder);
            shopForYou.ConstructLaptop();
            laptop = shopForYou.GetLaptop();
            Console.WriteLine(laptop);


        }
    }
}
