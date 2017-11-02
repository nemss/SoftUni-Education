using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

[TestFixture]
public class HeroInventoryTests
{
    private IInventory sut;

    [SetUp]
    public void TestInit()
    {
        this.sut = new HeroInventory();
    }

    [Test]
    public void AddCommonItem()
    {
        //Arrange
        var item = new CommonItem("item", 1, 2, 3, 4, 5);

        //Act
        this.sut.AddCommonItem(item);
        Type clazz = typeof(HeroInventory);
        var field = clazz.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .FirstOrDefault(f => f.GetCustomAttributes(typeof(ItemAttribute)) != null);
        var collection = (Dictionary<string, IItem>)field.GetValue(this.sut);

        //Assert
        Assert.AreEqual(1, collection.Count);
    }

    [Test]
    public void AddRecipeItem()
    {
        //Arrange
        var item = new RecipeItem("item", 1, 2, 3, 4, 5, new List<string>());

        //Act
        this.sut.AddRecipeItem(item);
        Type clazz = typeof(HeroInventory);
        var field = clazz.GetField("recipeItems", BindingFlags.Instance | BindingFlags.NonPublic);
        var collection = (Dictionary<string, IRecipe>)field.GetValue(this.sut);

        //Assert
        Assert.AreEqual(1, collection.Count);
    }

    [Test]
    public void StrengthBonusFromItems()
    {
        //Arrange
        var item = new CommonItem("Item", 1, 2, 3, 4, 5);

        //Act
        this.sut.AddCommonItem(item);

        //Assert
        Assert.AreEqual(1, this.sut.TotalStrengthBonus);
    }

    [Test]
    public void AgilityBonusFromItems()
    {
        //Arrange
        var item = new CommonItem("Item", 1, 2, 3, 4, 5);

        //Act
        this.sut.AddCommonItem(item);

        //Assert
        Assert.AreEqual(2, this.sut.TotalAgilityBonus);
    }

    [Test]
    public void IntelligenceBonusFromItems()
    {
        //Arrange
        CommonItem item = new CommonItem("Item", 1, 2, 3, 4, 5);

        //Act
        this.sut.AddCommonItem(item);

        //Assert
        Assert.AreEqual(3, this.sut.TotalIntelligenceBonus);
    }

    [Test]
    public void HitPointsBonusFromItems()
    {
        //Arrange
        CommonItem item = new CommonItem("Item", 1, 2, 3, 4, 5);

        //Act
        this.sut.AddCommonItem(item);

        //Assert
        Assert.AreEqual(4, this.sut.TotalHitPointsBonus);
    }

    [Test]
    public void DamageBonusFromItems()
    {
        //Arrange
        CommonItem item = new CommonItem("Item", 1, 2, 3, 4, 5);

        //Act
        this.sut.AddCommonItem(item);

        //Assert
        Assert.AreEqual(5, this.sut.TotalDamageBonus);
    }

    [Test]
    public void TestStatsBonus()
    {
        //Arrange
        var item = new CommonItem("Item", 1, 2, 3, 4, 5);

        //Act
        this.sut.AddCommonItem(item);
        long totalStatsBonus = sut.TotalAgilityBonus +
                               sut.TotalDamageBonus +
                               sut.TotalHitPointsBonus +
                               sut.TotalIntelligenceBonus +
                               sut.TotalStrengthBonus;

        //Assert
        Assert.AreEqual(15, totalStatsBonus);
    }
}