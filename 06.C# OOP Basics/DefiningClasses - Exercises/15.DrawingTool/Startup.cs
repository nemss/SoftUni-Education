using System.Diagnostics.Eventing.Reader;

namespace _15.DrawingTool
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var command = Console.ReadLine();

            if (command == "Square")
            {
                var size = int.Parse(Console.ReadLine());
                var cor = new CorDraw(new Square(size));            
                cor.Square.Draw();
            }
            else if (command == "Rectangle")
            {
                var width = int.Parse(Console.ReadLine());
                var height = int.Parse(Console.ReadLine());
                var cor = new CorDraw(new Rectangle(width, height));
                cor.Rectangle.Draw();
            }
        }
    } 
}
