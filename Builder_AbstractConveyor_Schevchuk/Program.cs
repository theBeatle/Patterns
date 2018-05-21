using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        public static void Main()
        {
            Builder builder = new ConcreteBuilder();
            Director director = new Director(builder);
            director.Construct();

            Product product = builder.GetResult();
            product.Show();
        }
    }
}
