using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{

    //classical realization
    class UsefullClass //implements Singleton pattern
    {
        private static UsefullClass instance; // = new UsefullClass();
        private UsefullClass()
        { }

        public static UsefullClass getInstance()
        {
            if (instance == null)
                instance = new UsefullClass();
            return instance;
        }



    }
}
