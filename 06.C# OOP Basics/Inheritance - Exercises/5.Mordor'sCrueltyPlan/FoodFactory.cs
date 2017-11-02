namespace _5.Mordor_sCrueltyPlan
{
    using System.Collections;
    using _5.Mordor_sCrueltyPlan.FoodModels;

    public class FoodFactory
    {
        public static Food CreateFood(string nameFood)
        {
            switch (nameFood.ToLower())
            {
                case "cram":
                    return new Cram();
                case "lembas":
                    return new Lembas();
                case "apple":
                    return new Apple();
                case "melon":
                    return new Melon();
                case "honeycake":
                    return new HoneyCake();
                case "mushrooms":
                    return new Mushrooms();
                default:
                    return new Other();
            }
        }
    }
}
