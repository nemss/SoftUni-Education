namespace AbstractFactory.PizzaPlaces
{
    public class OnlineDeliveryCompany
    {
        private PizzaFactory factory;

        public OnlineDeliveryCompany(PizzaFactory pizzaFactory)
        {
            factory = pizzaFactory;
        }

        public CheesePizza DeliverCheesePizza()
        {
            return factory.MakeCheesePizza();
        }

        public Calzone DeliverCalzone()
        {
            return factory.MakeCalzone();
        }

        public PepperoniPizza DeliverPepperoniPizza()
        {
            return factory.MakePepperoniPizza();
        }
    }
}