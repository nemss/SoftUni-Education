namespace _1.Logger.Factories
{
    using _1.Logger.Interfaces;
    using _1.Logger.Models.LayoutModels;
    using System;

    public class FactoryLayout
    {
        public ILayout Create(string layoutType)
        {
            if (layoutType == "SimpleLayout")
            {
                return new SimpleLayout();
            }
            else if (layoutType == "XmlLayout")
            {
                return new XmlLayout();
            }

            throw new ArgumentException("The type is not valid!");
        }
    }
}