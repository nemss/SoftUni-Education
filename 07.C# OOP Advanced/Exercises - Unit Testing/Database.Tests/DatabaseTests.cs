namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void TestingCtorWithCollection()
        {
            // Arange
            var database = new _1.Database.Models.Database(1, 2, 3, 4);

            // Assert
            Assert.AreEqual(4, database.Count());
        }

        [Test]
        public void CtorShouldWorkWithCollectionWithZeroElement()
        {
            // Arange
            var database = new _1.Database.Models.Database();

            // Assert
            Assert.AreEqual(0, database.Count());
        }

        [Test]
        public void CtorShuldNotAcceptMoreThan16Elements()
        {
            // Arange
            var array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            // Assert
            Assert.Throws<InvalidOperationException>(() => new _1.Database.Models.Database(array));
        }

        [Test]
        public void AddMethodShouldAddOneElement()
        {
            // Arrange
            var database = new _1.Database.Models.Database(1);

            // Act
            database.Add(1);

            // Assert
            Assert.AreEqual(2, database.Count());
        }

        [Test]
        public void RemoveMethodShoulRemoveOneElement()
        {
            // Arrange
            var database = new _1.Database.Models.Database(1, 2);

            // Act
            database.Remove();

            // Assert
            Assert.AreEqual(1, database.Count());
        }

        [Test]
        public void MethodCount()
        {
            // Arrange
            var database = new _1.Database.Models.Database(1, 2, 3);

            // Act
            database.Add(1);
            database.Remove();
            database.Add(3);

            // Assert
            Assert.AreEqual(4, database.Count());
        }

        [Test]
        public void RemoveMethodTestRemoveElementWithEmptyCollection()
        {
            // Arrange
            var database = new _1.Database.Models.Database();

            //Assert
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void AddMethodTest()
        {
            // Arrange
            var database = new _1.Database.Models.Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            // Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(30));
        }
    }
}