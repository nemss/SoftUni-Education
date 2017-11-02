namespace _03BarracksFactory.Core.Factories
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var getType = Assembly.GetExecutingAssembly().DefinedTypes.First(x => x.Name == unitType);
            var unit = (IUnit)Activator.CreateInstance(getType);
            return unit;
        }
    }
}