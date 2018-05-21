using System;

namespace Builder
{
    class Director
    {
        readonly Builder builder;

        public Director(Builder builder)
        {
            this.builder = builder;
        }

        public void Construct()
        {
            builder.BuildPartA();
            builder.BuildPartB();
            builder.BuildPartA();
            builder.BuildPartB();
            builder.BuildPartA();
            builder.BuildPartA();
            builder.BuildPartB();
            builder.BuildPartA();
            builder.BuildPartB();
            builder.BuildPartA();
            builder.BuildPartA();
            builder.BuildPartA();
            builder.BuildPartB();
            builder.BuildPartA();
            builder.BuildPartB();
            builder.BuildPartC();
        }
    }
}
