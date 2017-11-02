namespace _2.WildFarm.Models
{
    public abstract class Food
    {
        public int Quantity { get; set; }

        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }
    }
}
