using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class SingletonLazyFull
    {
        private SingletonLazyFull()
        {
        }

        public static SingletonLazyFull Instance
        {
            get
            {
                return Nested.instance;
            }
        }

        private class Nested
        {
            //to invoke before all other
            static Nested()
            {
            }

            public static readonly SingletonLazyFull instance = new SingletonLazyFull();
        }
    }
}
