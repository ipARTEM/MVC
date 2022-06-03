using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC07Strategy
{
    public abstract class Shape
    {
        public abstract void Area();
        public abstract void Draw();

    }

    public class Circle : Shape
    {
        public double X { get; init; }
        public double Y { get; init; }
        public double R { get; init; }

        public Circle(double x, double y, double r)
        {

        }

        public override void Area()
        {
            Console.WriteLine();
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
        

}
