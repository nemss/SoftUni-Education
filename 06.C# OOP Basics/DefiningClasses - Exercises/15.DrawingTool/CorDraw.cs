namespace _15.DrawingTool
{
    public class CorDraw
    {
        public Rectangle Rectangle { get; set; }
        public Square Square { get; set; }

        public CorDraw(Rectangle rectangle)
        {
            this.Rectangle = rectangle;
        }

        public CorDraw(Square square)
        {
            this.Square = square;
        }
    }
}
