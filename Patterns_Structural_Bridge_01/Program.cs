using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Structural_Bridge_01
{
    interface IBuldingCompany
    {
        void BuildFoundation();
        void BuildRoom();
        void BuildRoof();
        IWallCreator WallCreator { get; set; }
    }

    class BuldingCompany : IBuldingCompany
    {
        public void BuildFoundation()
        {
            Console.WriteLine("Foundation is built.\n");
        } 
        public void BuildRoom()
        {
            WallCreator.BuildWallWithDoor();
            WallCreator.BuildWall();
            WallCreator.BuildWallWithWindow();
            WallCreator.BuildWall();
            
            Console.WriteLine("Room finished.\n");
            //WallCreator.BuildGrage();

        }
        public void BuildRoof()
        {
            Console.WriteLine("Roof is done.\n");
        }
        public IWallCreator WallCreator { get; set; }
    }

    public interface IWallCreator
    {
        void BuildWall();
        void BuildWallWithDoor();
        void BuildWallWithWindow();
        void BuildGrage();
    }

    internal class BrickWallCreator : IWallCreator
    {
        public BrickWallCreator()
        {
        }

        public void BuildGrage()
        {
            Console.WriteLine("Brick garage created!");
        }

        public void BuildWall()
        {
            Console.WriteLine("Brick wall created!");
        }

        public void BuildWallWithDoor()
        {
            Console.WriteLine("Brick wall with door created!");
        }

        public void BuildWallWithWindow()
        {
            Console.WriteLine("Brick wall with window created!");
        }
    }

    internal class ConcreteSlabWallCreator : IWallCreator
    {
        public ConcreteSlabWallCreator()
        {
        }

        public void BuildGrage()
        {
            Console.WriteLine("Concrete garage created!");
        }

        public void BuildWall()
        {
            Console.WriteLine("Concrete wall created!");
        }

        public void BuildWallWithDoor()
        {
            Console.WriteLine("Concrete wall with door created!");

        }

        public void BuildWallWithWindow()
        {
            Console.WriteLine("Concrete wall with window created!");

        }
    }

    class WoodenWallCreator : IWallCreator
    {
        public void BuildGrage()
        {
            Console.WriteLine("Wooden garage created!");
        }

        public void BuildWall()
        {
            Console.WriteLine("Wooden wall created!");
        }

        public void BuildWallWithDoor()
        {
            Console.WriteLine("Wooden wall with door created!");
        }

        public void BuildWallWithWindow()
        {
            Console.WriteLine("Wooden wall with window created!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            IBuldingCompany buildingCompany = new BuldingCompany();
            buildingCompany.BuildFoundation();

            IWallCreator brickComand = new BrickWallCreator();
            buildingCompany.WallCreator = brickComand;

            buildingCompany.BuildRoom();
            buildingCompany.WallCreator = new ConcreteSlabWallCreator();
            buildingCompany.BuildRoom();
            buildingCompany.WallCreator = new WoodenWallCreator();
            buildingCompany.BuildRoom();

            buildingCompany.WallCreator = brickComand;
            buildingCompany.BuildRoom();

            buildingCompany.BuildRoof();
            
        }
    }

    
}
