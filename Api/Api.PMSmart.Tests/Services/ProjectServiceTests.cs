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
    public class ProjectServiceTests
    {
        [Test]
        public void GetProjectItems_should_return_valid_items()
        {
            // Arrange
            var mockProjectRepository = Substitute.For<IProjectRepository>();
            mockProjectRepository.GetProjects().Returns(new List<ProjectItem> { new ProjectItem() });
            var service = new ProjectService(mockProjectRepository);

            // Act
            var result = service.GetProjectItems();

            // Assert
            mockProjectRepository.Received(1).GetProjects();
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(List<ProjectItem>), result.GetType());
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void GetAssignationDetails_should_return_valid_items()
        {
            // Arrange
            var mockProjectRepository = Substitute.For<IProjectRepository>();
            mockProjectRepository.GetAssignationDetails().Returns(new List<ProjectItem> { new ProjectItem() });
            var service = new ProjectService(mockProjectRepository);

            // Act
            var result = service.GetAssignationDetails();

            // Assert
            mockProjectRepository.Received(1).GetAssignationDetails();
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(List<ProjectItem>), result.GetType());
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void Create_should_return_item_id()
        {
            // Arrange
            var expectedOutput = 1;
            var mockProjectRepository = Substitute.For<IProjectRepository>();
            mockProjectRepository.Create(Arg.Any<ProjectItem>()).Returns(expectedOutput);
            var service = new ProjectService(mockProjectRepository);

            // Act
            var result = service.Create(new ProjectItem());

            // Assert
            mockProjectRepository.Received(1).Create(Arg.Any<ProjectItem>());
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void Update_should_return_item_id()
        {
            // Arrange
            var expectedOutput = 1;
            var mockProjectRepository = Substitute.For<IProjectRepository>();
            mockProjectRepository.Update(Arg.Any<ProjectItem>()).Returns(expectedOutput);
            var service = new ProjectService(mockProjectRepository);

            // Act
            var result = service.Update(new ProjectItem());

            // Assert
            mockProjectRepository.Received(1).Update(Arg.Any<ProjectItem>());
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedOutput, result);
        }
    }
}