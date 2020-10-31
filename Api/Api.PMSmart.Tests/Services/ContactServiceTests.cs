using System.Collections.Generic;
using System.Linq;
using Api.PMSmart.Models;
using Api.PMSmart.Models.DTOS;
using Api.PMSmart.Repositories;
using Api.PMSmart.Services;
using NSubstitute;
using NUnit.Framework;

namespace Api.PMSmart.Tests.Services
{
    [TestFixture]
    public class ContactServiceTests
    {
        [Test]
        public void GetContactItems_should_return_valid_items()
        {
            // Arrange
            var mockContactRepository = Substitute.For<IContactRepository>();
            mockContactRepository.GetContacts().Returns(new List<ContactItem> { new ContactItem() });
            var service = new ContactService(mockContactRepository);

            // Act
            var result = service.GetContactItems();

            // Assert
            mockContactRepository.Received(1).GetContacts();
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(List<ContactItem>), result.GetType());
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void GetContactsForAssignation_should_return_valid_items()
        {
            // Arrange
            var mockInput = 1;
            var mockContactRepository = Substitute.For<IContactRepository>();
            mockContactRepository.GetContactsForAssignation(mockInput).Returns(new List<ContactItem> { new ContactItem() });
            var service = new ContactService(mockContactRepository);

            // Act
            var result = service.GetContactsForAssignation(mockInput);

            // Assert
            mockContactRepository.Received(1).GetContactsForAssignation(mockInput);
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(List<ContactItem>), result.GetType());
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void Create_should_return_item_id()
        {
            // Arrange
            var expectedOutput = 1;
            var mockContactRepository = Substitute.For<IContactRepository>();
            mockContactRepository.Create(Arg.Any<ContactItem>()).Returns(expectedOutput);
            var service = new ContactService(mockContactRepository);

            // Act
            var result = service.Create(new ContactItem());

            // Assert
            mockContactRepository.Received(1).Create(Arg.Any<ContactItem>());
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void Update_should_return_item_id()
        {
            // Arrange
            var expectedOutput = 1;
            var mockContactRepository = Substitute.For<IContactRepository>();
            mockContactRepository.Update(Arg.Any<ContactItem>()).Returns(expectedOutput);
            var service = new ContactService(mockContactRepository);

            // Act
            var result = service.Update(new ContactItem());

            // Assert
            mockContactRepository.Received(1).Update(Arg.Any<ContactItem>());
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedOutput, result);
        }
    }
}