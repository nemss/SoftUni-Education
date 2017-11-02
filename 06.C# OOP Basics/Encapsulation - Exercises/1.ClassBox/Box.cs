namespace _1.ClassBox
{
    using System;

    public class Box
    {
        public Box(double lenght, double width, double height)
        {
            this.lenght = lenght;
            this.width = width;
            this.height = height;
        }

        private double lenght;
        private double width;
        private double height;


        public void SurfaceArea()
        {
            var result = 2 * this.lenght * this.width + 2 * this.lenght * this.height + 2 * this.width * this.height;
            Console.WriteLine($"Surface Area - {result:f2}");
        }

        public void LateralSurfaceArea()
        {
            var result = 2 * this.lenght * this.height + 2 * this.width * this.height;
            Console.WriteLine($"Lateral Surface Area - {result:f2}");
        }

        public void Volume()
        {
            var result = this.lenght * this.width * this.height;
            Console.WriteLine($"Volume - {result:f2}");
        }
    }
}
