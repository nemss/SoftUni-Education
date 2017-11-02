using System.Collections.Generic;

public interface IItemFactory
{
    IItem Crete(IList<string> arguments);
}