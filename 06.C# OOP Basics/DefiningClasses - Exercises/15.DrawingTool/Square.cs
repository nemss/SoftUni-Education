namespace _15.DrawingTool
{
    using System;

    public class Square
    {
        public Square(int size)
        {
            this.Size = size;
        }

        public int Size { get; set; }

        public void Draw()
        {
            for (int i = 0; i < this.Size; i++)
            {
                if (i == 0 || i == this.Size - 1)
                {
                    Console.WriteLine("|" + new string('-', this.Size) + "|");
                }
                else
                {
                    Console.WriteLine("|" + new string(' ', this.Size) + "|");
                }
            }
        }
    }
}
