using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public abstract class AbstractHero : IHero, IComparable<AbstractHero>
{
    private readonly IInventory inventory;
    private long strength;
    private long agility;
    private long intelligence;
    private long hitPoints;
    private long damage;

    protected AbstractHero(string name, int strength, int agility, int intelligence, int hitPoints, int damage)
    {
        this.Name = name;
        this.strength = strength;
        this.agility = agility;
        this.intelligence = intelligence;
        this.hitPoints = hitPoints;
        this.damage = damage;
        this.inventory = new HeroInventory();
    }

    public string Name { get; private set; }

    public long Strength
    {
        get { return this.strength + this.inventory.TotalStrengthBonus; }
        set { this.strength = value; }
    }

    public long Agility
    {
        get { return this.agility + this.inventory.TotalAgilityBonus; }
        set { this.agility = value; }
    }

    public long Intelligence
    {
        get { return this.intelligence + this.inventory.TotalIntelligenceBonus; }
        set { this.intelligence = value; }
    }

    public long HitPoints
    {
        get { return this.hitPoints + this.inventory.TotalHitPointsBonus; }
        set { this.hitPoints = value; }
    }

    public long Damage
    {
        get { return this.damage + this.inventory.TotalDamageBonus; }
        set { this.damage = value; }
    }

    public long PrimaryStats
    {
        get { return this.Strength + this.Agility + this.Intelligence; }
    }

    public long SecondaryStats
    {
        get { return this.HitPoints + this.Damage; }
    }

    public IInventory Inventory
    {
        get { return this.inventory; }
    }

    //REFLECTION
    public ICollection<IItem> Items
    {
        get
        {
            var typeOfIventory = typeof(HeroInventory);
            var getField = typeOfIventory.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            var getCommonItems = getField.First(i => i.GetCustomAttributes(typeof(ItemAttribute)) != null);
            var items = (IDictionary<string, IItem>)getCommonItems.GetValue(this.inventory);

            return items.Values.ToList();
        }
    }

    public void AddItem(IItem item)
    {
        this.inventory.AddCommonItem(item);
    }

    public void AddRecipe(IRecipe recipe)
    {
        this.inventory.AddRecipeItem(recipe);
    }

    public int CompareTo(AbstractHero other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }
        if (ReferenceEquals(null, other))
        {
            return 1;
        }
        var primary = this.PrimaryStats.CompareTo(other.PrimaryStats);
        if (primary != 0)
        {
            return primary;
        }

        return this.SecondaryStats.CompareTo(other.SecondaryStats);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"Hero: {this.Name}, Class: {GetType().Name}");
        sb.AppendLine($"HitPoints: {this.HitPoints}, Damage: {this.Damage}");
        sb.AppendLine($"Strength: {this.Strength}");
        sb.AppendLine($"Agility: {this.Agility}");
        sb.AppendLine($"Intelligence: {this.Intelligence}");
        if (this.Items.Count > 0)
        {
            sb.AppendLine("Items:");
            foreach (var item in this.Items)
            {
                sb.AppendLine(item.ToString());
            }
        }
        else
        {
            sb.AppendLine($"Items: None");
        }

        return sb.ToString().Trim();
    }
}