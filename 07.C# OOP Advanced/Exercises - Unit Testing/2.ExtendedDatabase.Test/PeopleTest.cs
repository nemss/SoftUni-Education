using _2.ExtendedDatabase.Models;

namespace _2.ExtendedDatabase.Test
{
    using NUnit.Framework;

    [TestFixture]
    public class PeopleTest
    {
        [Test]
        public void PeopleCtorShouldAcceptNameAndId()
        {
            // Arrange
            var people = new People(1, "Valentin");

            // Assert
            Assert.AreEqual(1, people.Id);
            Assert.AreEqual("Valentin", people.Name);
        }
    }
}