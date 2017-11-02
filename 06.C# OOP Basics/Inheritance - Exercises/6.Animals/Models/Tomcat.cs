namespace _6.Animals.Models
{
    public class Tomcat : Animal
    {
        public Tomcat(string name, int age, string gender)
            : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "Give me one million b***h";
        }
    }
}
