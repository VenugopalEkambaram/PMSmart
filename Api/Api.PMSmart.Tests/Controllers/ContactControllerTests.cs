using Api.PMSmart.Controllers;
using Api.PMSmart.Models;
using Api.PMSmart.Services;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http.Results;
using Api.PMSmart.Models.DTOS;

namespace Api.PMSmart.Tests.Controllers
{
    [TestFixture]
    public class ContactControllerTests
    {
        [Test]
        public void Get_should_return_valid_result()
        {
            // Arrange
            var mockContactService = Substitute.For<IContactService>();
            mockContactService.GetContactItems().Returns(new List<ContactItem> { new ContactItem() });
            var controller = new ContactController(mockContactService);

            // Act
            var result = (OkNegotiatedContentResult<List<ContactItem>>)controller.Get();

            // Assert
            mockContactService.Received(1).GetContactItems();
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(List<ContactItem>), result.Content.GetType());
            Assert.AreEqual(1, result.Content.Count());
        }

        [Test]
        public void Get_should_return_notfound_result()
        {
            // Arrange
            var mockContactService = Substitute.For<IContactService>();
            mockContactService.GetContactItems().Returns(new List<ContactItem>());
            var controller = new ContactController(mockContactService);

            // Act
            var result = (NotFoundResult)controller.Get();

            // Assert
            mockContactService.Received(1).GetContactItems();
            Assert.IsNotNull(result);
        }

        [Test]
        public void ContactsForAssignation_should_return_valid_result()
        {
            // Arrange
            var mockProjectId = 1;
            var mockContactService = Substitute.For<IContactService>();
            mockContactService.GetContactsForAssignation(mockProjectId).Returns(new List<ContactItem> { new ContactItem() });
            var controller = new ContactController(mockContactService);

            // Act
            var result = (OkNegotiatedContentResult<List<ContactItem>>)controller.ContactsForAssignation(mockProjectId);

            // Assert
            mockContactService.Received(1).GetContactsForAssignation(mockProjectId);
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(List<ContactItem>), result.Content.GetType());
            Assert.AreEqual(1, result.Content.Count());
        }

        [Test]
        public void ContactsForAssignation_should_return_notfound_result()
        {
            // Arrange
            var mockInput = 1;
            var mockContactService = Substitute.For<IContactService>();
            mockContactService.GetContactsForAssignation(mockInput).Returns(new List<ContactItem>());
            var controller = new ContactController(mockContactService);

            // Act
            var result = (NotFoundResult)controller.ContactsForAssignation(mockInput);

            // Assert
            mockContactService.Received(1).GetContactsForAssignation(mockInput);
            Assert.IsNotNull(result);
        }

        [Test]
        public void Post_should_return_created_statuscode()
        {
            //Arrange
            var expectedOutput = 1;
            var mockContactService = Substitute.For<IContactService>();
            mockContactService.Create(Arg.Any<ContactItem>()).Returns(expectedOutput);
            var controller = new ContactController(mockContactService)
            {
                Request = new HttpRequestMessage(HttpMethod.Get, "http://test")
            };

            // Act
            var result = (CreatedNegotiatedContentResult<int>)controller.Post(new ContactItem());

            // Assert
            mockContactService.Received(1).Create(Arg.Any<ContactItem>());
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedOutput, result.Content);
            Assert.AreEqual("http://test/1", result.Location.ToString());
        }

        [Test]
        public void Post_should_return_badrequest_result()
        {
            // Arrange
            var mockContactService = Substitute.For<IContactService>();
            mockContactService.Create(Arg.Any<ContactItem>()).Returns(0);
            var controller = new ContactController(mockContactService);

            // Act
            var result = (BadRequestResult)controller.Post(new ContactItem());

            // Assert
            mockContactService.Received(1).Create(Arg.Any<ContactItem>());
            Assert.IsNotNull(result);
        }

        [Test]
        public void Put_should_return_valid_result()
        {
            // Arrange
            var expectedOutput = 1;
            var mockContactService = Substitute.For<IContactService>();
            mockContactService.Update(Arg.Any<ContactItem>()).Returns(expectedOutput);
            var controller = new ContactController(mockContactService);

            // Act
            var result = (OkNegotiatedContentResult<int>)controller.Put(new ContactItem());

            // Assert
            mockContactService.Received(1).Update(Arg.Any<ContactItem>());
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedOutput, result.Content);
        }

        [Test]
        public void Put_should_return_notfound_result()
        {
            // Arrange
            var mockContactService = Substitute.For<IContactService>();
            mockContactService.Update(Arg.Any<ContactItem>()).Returns(0);
            var controller = new ContactController(mockContactService);

            // Act
            var result = (NotFoundResult)controller.Put(new ContactItem());

            // Assert
            mockContactService.Received(1).Update(Arg.Any<ContactItem>());
            Assert.IsNotNull(result);
        }
    }
}