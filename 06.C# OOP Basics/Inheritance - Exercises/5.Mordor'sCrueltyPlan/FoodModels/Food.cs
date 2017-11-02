namespace _5.Mordor_sCrueltyPlan.FoodModels
{
    public class Food
    {
        public Food(int pointOfHappiness)
        {
            this.PointOfHappiness = pointOfHappiness;
        }

        private int pointOfHappiness;

        public int PointOfHappiness
        {
            get { return this.pointOfHappiness; }
            set { this.pointOfHappiness = value; }
        }
    }
}

