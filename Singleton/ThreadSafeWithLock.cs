using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    //lazy Thread Safe with lock non-inherited 
    public sealed class SingletonTSL
    {
        private static SingletonTSL instance = null;
        private static readonly object padlock = new object();

        private SingletonTSL()
        {
        }

        public static SingletonTSL Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SingletonTSL();
                    }
                    return instance;
                }
            }
        }
    }
}
