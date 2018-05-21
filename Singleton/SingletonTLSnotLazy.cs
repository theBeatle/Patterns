using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    //non-lazy Thread Safe WITHOUT lock inheritable 
    class SingletonTLSnotLazy
    {
        private static readonly SingletonTLSnotLazy instance; // = new SingletonTLSnotLazy();

        public static SingletonTLSnotLazy Instance { get => instance; }

        //to invoke init before all other 
        static SingletonTLSnotLazy()
        {
            instance = new SingletonTLSnotLazy();
        }

        private SingletonTLSnotLazy()
        {
        }

    }
}
