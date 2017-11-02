namespace _2.ClassBoxDataValidation
{
    using System;

    public class Box
    {
        public Box(double lenght, double width, double height)
        {
            this.Length = lenght;
            this.Width = width;
            this.Height = height;
        }

        private double lenght;
        private double width;
        private double height;

        public double Length
        {
            get { return this.lenght; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Length)} cannot be zero or negative.");
                }
                this.lenght = value;
            }
        }

        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Width)} cannot be zero or negative.");
                }
                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Height)} cannot be zero or negative.");
                }
                this.height = value;
            }
        }

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
