using System;
using System.Collections.Generic;

namespace Hell.Factories
{
    public class ItemFactory : IItemFactory
    {
        public IItem Crete(IList<string> arguments)
        {
            var itemName = arguments[0];
            var strengthBonus = int.Parse(arguments[2]);
            var agiliryBonus = int.Parse(arguments[3]);
            var intelligenceBonus = int.Parse(arguments[4]);
            var hitPointsBonus = int.Parse(arguments[5]);
            var damageBonus = int.Parse(arguments[6]);

            var type = typeof(CommonItem);
            var commonItem = (IItem)Activator.CreateInstance(type, itemName, strengthBonus, agiliryBonus, intelligenceBonus,
                hitPointsBonus, damageBonus);

            return commonItem;
        }
    }
}