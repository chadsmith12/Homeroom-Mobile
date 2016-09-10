using System.Threading.Tasks;
using HomeRoom_Mobile.Interfaces;
using HomeRoom_Mobile.Models.Api;
using HomeRoom_Mobile.ViewModels;
using Moq;
using NUnit.Framework;

namespace HomeRoomMobile.Tests
{
    [TestFixture]
    public class DetailViewModelTests
    {
        private CourseDetailViewModel _viewModel;

        [SetUp]
        public void Setup()
        {
            var navMoc = new Mock<INavigationService>().Object;
            _viewModel = new CourseDetailViewModel(navMoc);

        }

        [Test]
        public async Task InitParameterProvidedCourseIsSet()
        {
            // Arrange
            // Create a new mock object to test
            var mockCourse = new Mock<CourseDto>().Object;

            // Act
            await _viewModel.Init(mockCourse);

            // Assert
            Assert.IsNotNull(_viewModel.Course, "Course is null after initialized with a valid Course object");
        }
    }
}

