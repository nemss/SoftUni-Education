using _2.ExtendedDatabase.Interfaces;
using _2.ExtendedDatabase.Models;
using Moq;
using System;

namespace _2.ExtendedDatabase.Test
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void TheDatabaseMustBeEmptyCreated()
        {
            // Arrange
            var db = new Database();

            // Assert
            Assert.AreEqual(0, db.Count());
        }

        [Test]
        public void DatabaseShouldAddOnePerson()
        {
            // Arrange
            var personStub = new Mock<IPeople>();
            var db = new Database();

            // Act
            db.Add(personStub.Object);

            // Assert
            Assert.AreEqual(1, db.Count());
        }

        [Test]
        public void DatabaseShouldAddManyPersons()
        {
            // Arrange
            var firstPersonStub = new Mock<IPeople>();
            firstPersonStub.Setup(p => p.Name).Returns("Valentin");
            firstPersonStub.Setup(p => p.Id).Returns(1);
            var secondPersonStub = new Mock<IPeople>();
            secondPersonStub.Setup(p => p.Name).Returns("Gosho");
            secondPersonStub.Setup(p => p.Id).Returns(2);
            var db = new Database();

            // Act
            db.Add(firstPersonStub.Object);
            db.Add(secondPersonStub.Object);

            // Assert
            Assert.AreEqual(2, db.Count());
        }

        [Test]
        public void IfAddUsetWithNameAlreadyExistInDatabase()
        {
            // Arrange
            var firstPersonStub = new Mock<IPeople>();
            firstPersonStub.Setup(p => p.Name).Returns("Valentin");
            firstPersonStub.Setup(p => p.Id).Returns(1);
            var secondPersonStub = new Mock<IPeople>();
            secondPersonStub.Setup(p => p.Name).Returns("Valentin");
            secondPersonStub.Setup(p => p.Id).Returns(2);
            var db = new Database();

            // Act
            db.Add(firstPersonStub.Object);

            //Assert
            Assert.Throws<InvalidOperationException>(() => db.Add(secondPersonStub.Object));
        }

        [Test]
        public void RemoveOnePeople()
        {
            // Arrange
            var firstPersonStub = new Mock<IPeople>();
            firstPersonStub.Setup(p => p.Name).Returns("Valentin");
            firstPersonStub.Setup(p => p.Id).Returns(1);
            var secondPersonStub = new Mock<IPeople>();
            secondPersonStub.Setup(p => p.Name).Returns("Gosho");
            secondPersonStub.Setup(p => p.Id).Returns(2);
            var db = new Database();

            // Act
            db.Add(firstPersonStub.Object);
            db.Add(secondPersonStub.Object);
            db.Remove();

            // Assert
            Assert.AreEqual(1, db.Count());
        }
    }
}