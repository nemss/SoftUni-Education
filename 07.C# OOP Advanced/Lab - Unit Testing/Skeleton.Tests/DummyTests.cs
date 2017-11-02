using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    private const int DummyHealth = 15;
    private const int DummyXP = 10;
    private const int AxeAttack = 15;
    private const int AxeDurability = 10;

    private Dummy dummy;
    private Axe axe;

    [SetUp]
    public void TestInit()
    {
        // Arange
        this.dummy = new Dummy(DummyHealth, DummyXP);
        this.axe = new Axe(AxeAttack, AxeDurability);
    }

    [Test]
    public void DummyLosesHelthAfterAttack()
    {
        // Act
        this.dummy.TakeAttack(5);

        // Assert
        Assert.AreEqual(10, this.dummy.Health, "Dummy is not loosing health when attacked!");
    }

    [Test]
    public void DeadDummyThrowsException()
    {
        // Act
        this.axe.Attack(this.dummy);

        // Assert
        var ex = Assert.Throws<InvalidOperationException>(() => this.axe.Attack(dummy));
        Assert.AreEqual("Dummy is dead.", ex.Message);
    }

    [Test]
    public void DeadDummyCanGivenXp()
    {
        // Act
        this.axe.Attack(dummy);

        // Assert
        Assert.That(this.dummy.GiveExperience(), Is.EqualTo(this.dummy.GiveExperience()));
    }

    [Test]
    public void AliveDummyCanGivenEp()
    {
        // Assert
        var ex = Assert.Throws<InvalidOperationException>(() => this.dummy.GiveExperience());
        Assert.AreEqual("Target is not dead.", ex.Message);
    }
}