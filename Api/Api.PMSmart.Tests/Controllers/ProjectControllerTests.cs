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
    public class ProjectControllerTests
    {
        [Test]
        public void GetProjectItems_should_return_valid_result()
        {
            // Arrange
            var mockProjectService = Substitute.For<IProjectService>();
            mockProjectService.GetProjectItems().Returns(new List<ProjectItem> { new ProjectItem() });
            var controller = new ProjectController(mockProjectService);

            // Act
            var result = (OkNegotiatedContentResult<List<ProjectItem>>)controller.Get();

            // Assert
            mockProjectService.Received(1).GetProjectItems();
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(List<ProjectItem>), result.Content.GetType());
            Assert.AreEqual(1, result.Content.Count());
        }

        [Test]
        public void GetProjectItems_should_return_notfound_result()
        {
            // Arrange
            var mockProjectService = Substitute.For<IProjectService>();
            mockProjectService.GetProjectItems().Returns(new List<ProjectItem>());
            var controller = new ProjectController(mockProjectService);

            // Act
            var result = (NotFoundResult)controller.Get();

            // Assert
            mockProjectService.Received(1).GetProjectItems();
            Assert.IsNotNull(result);
        }

        [Test]
        public void AssignationDetails_should_return_valid_result()
        {
            // Arrange
            var mockProjectService = Substitute.For<IProjectService>();
            mockProjectService.GetAssignationDetails().Returns(new List<ProjectItem> { new ProjectItem() });
            var controller = new ProjectController(mockProjectService);

            // Act
            var result = (OkNegotiatedContentResult<List<ProjectItem>>)controller.AssignationDetails();

            // Assert
            mockProjectService.Received(1).GetAssignationDetails();
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(List<ProjectItem>), result.Content.GetType());
            Assert.AreEqual(1, result.Content.Count());
        }

        [Test]
        public void AssignationDetails_should_return_notfound_result()
        {
            // Arrange
            var mockProjectService = Substitute.For<IProjectService>();
            mockProjectService.GetAssignationDetails().Returns(new List<ProjectItem>());
            var controller = new ProjectController(mockProjectService);

            // Act
            var result = (NotFoundResult)controller.AssignationDetails();

            // Assert
            mockProjectService.Received(1).GetAssignationDetails();
            Assert.IsNotNull(result);
        }

        [Test]
        public void Post_should_return_created_statuscode()
        {
            //Arrange
            var expectedOutput = 1;
            var mockProjectService = Substitute.For<IProjectService>();
            mockProjectService.Create(Arg.Any<ProjectItem>()).Returns(expectedOutput);
            var controller = new ProjectController(mockProjectService)
            {
                Request = new HttpRequestMessage(HttpMethod.Get, "http://test")
            };

            // Act
            var result = (CreatedNegotiatedContentResult<int>)controller.Post(new ProjectItem());

            // Assert
            mockProjectService.Received(1).Create(Arg.Any<ProjectItem>());
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedOutput, result.Content);
            Assert.AreEqual("http://test/1", result.Location.ToString());
        }

        [Test]
        public void Post_should_return_badrequest_result()
        {
            // Arrange
            var mockProjectService = Substitute.For<IProjectService>();
            mockProjectService.Create(Arg.Any<ProjectItem>()).Returns(0);
            var controller = new ProjectController(mockProjectService);

            // Act
            var result = (BadRequestResult)controller.Post(new ProjectItem());

            // Assert
            mockProjectService.Received(1).Create(Arg.Any<ProjectItem>());
            Assert.IsNotNull(result);
        }
    }
}