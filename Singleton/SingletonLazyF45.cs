using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public sealed class SingletonLazyF45
    {
        private static readonly Lazy<SingletonLazyF45> lazy = new Lazy<SingletonLazyF45>();
        //real init while Lazy<T>.Value - first call occured
        public static SingletonLazyF45 Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private SingletonLazyF45()
        {
        }
        
    }

   //public class NewSinglenon : SingletonLazyF45
   //{
   //    public NewSinglenon() : base()
   //    {
   //
   //    }
   //
   //}


}
