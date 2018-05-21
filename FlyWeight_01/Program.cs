using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeight_01
{
    class Image
    {
        private List<string> _imitatesHugeImage = new List<string>();
        public static Image Load(string fileName)
        {
            var img = new Image();
            for (int i = 0; i < 100000; i++)
            {
                img._imitatesHugeImage.Add(string.Format("1234567890:{0}", i));
            }
            return img;
        }
    }
    abstract class Unit
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public Image Picture { get; protected set; }
    }
    class Goblin : Unit
    {
        public Goblin()
        {
            Name = "Goblin";
            Health = 8;
            //old
            // Picture = Image.Load("Goblin.jpg");
            //new
            Picture = UnitImagesFactory.CreateGoblinImage();
        }
    }
    class Dragon : Unit
    {
        public Dragon()
        {
            Name = "Dragon";
            Health = 50;
            //old
            // Picture = Image.Load("Dragon.jpg");
            //new
            Picture = UnitImagesFactory.CreateDragonImage();
        }
    }

    class UnitImagesFactory
    {
        public static Dictionary<Type, Image> Images = new Dictionary<Type, Image>();
        public static Image CreateDragonImage()
        {
            if (!Images.ContainsKey(typeof(Dragon)))
            {
                Images.Add(typeof(Dragon), Image.Load("Dragon.jpg"));
            }
            return Images[typeof(Dragon)];
        }
        public static Image CreateGoblinImage()
        {
            if (!Images.ContainsKey(typeof(Goblin)))
            {
                Images.Add(typeof(Goblin), Image.Load("Goblin.jpg"));
            }
            return Images[typeof(Goblin)];
        }
    }

    class Parser
    {
        public List<Unit> ParseHTML(int dragonCount, int goblinCount)
        {
            var units = new List<Unit>();
            for (int i = 0; i < dragonCount; i++)
                units.Add(new Dragon());
            for (int i = 0; i < goblinCount; i++)
                units.Add(new Goblin());
            Console.WriteLine("Dragons and Goblins are parsed from HTML page.");
            return units;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var units = new Parser().ParseHTML(150, 500);
            Console.ReadKey();
        }
    }
}
