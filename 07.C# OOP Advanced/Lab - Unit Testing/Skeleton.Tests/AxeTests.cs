using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    public const int AxeAttack = 1;
    private const int AxeDurabily = 1;
    private const int DummyHealth = 15;
    private const int DummyXP = 15;

    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void TestInit()
    {
        // Arrange
        this.axe = new Axe(AxeAttack, AxeDurabily);
        this.dummy = new Dummy(DummyHealth, DummyXP);
    }

    [Test]
    public void AxeLosesDurabilyAfterAttack()
    {
        // Act
        this.axe.Attack(dummy);

        // Assert
        Assert.AreEqual(0, this.axe.DurabilityPoints, "Axe Durability doesn\'t change after attack");
    }

    [Test]
    public void BrokenAxeCantAttack()
    {
        // Act
        this.axe.Attack(dummy);

        // Assert
        var ex = Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        Assert.That(ex.Message, Is.EqualTo("Axe is broken."));
    }
}