using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_02
{
    class MainApp
    {
        static void Main()
        {
            ColorManager colormanager = new ColorManager();

            colormanager["red"] = new Color(255, 0, 0);
            colormanager["green"] = new Color(0, 255, 0);
            colormanager["blue"] = new Color(0, 0, 255);

            colormanager["angry"] = new Color(255, 54, 0);
            colormanager["peace"] = new Color(128, 211, 128);
            colormanager["flame"] = new Color(211, 34, 20);

            Color color1 = colormanager["red"].Clone() as Color;
            Color color2 = colormanager["peace"].Clone() as Color;
            Color color3 = colormanager["flame"].Clone() as Color;


            Console.WriteLine(color1);

        }
    }


    abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }

    class Color : ColorPrototype
    {
        private int _red;
        private int _green;
        private int _blue;


        public Color(int red, int green, int blue)
        {
            this._red = red;
            this._green = green;
            this._blue = blue;
        }

        // Create a shallow copy
        public override ColorPrototype Clone()
        {
            Console.WriteLine($"Cloning color RGB: {_red,3},{_green,3},{_blue,3}");
            //return this.MemberwiseClone() as ColorPrototype;
            return (ColorPrototype)this.MemberwiseClone();
        }

        public override string ToString()
        {
            return String.Format("Cloned color RGB: {0,3} {1,3} {2,3}", _red,_green,_blue);
        }
    }


    class ColorManager
    {
        private Dictionary<string, ColorPrototype> _colors =
          new Dictionary<string, ColorPrototype>();


        public ColorPrototype this[string key]
        {
            get { return _colors[key]; }
            set { _colors.Add(key, value); }
        }
    }
}
