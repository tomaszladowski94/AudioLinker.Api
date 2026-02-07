using AudioLinker.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using AudioLinker.Api.Models.Requests;
using AudioLinker.Api.Models.Responses;

namespace AudioLinker.Api.Tests
{
    public class AnalyzeControllerTests
    {
        [Fact]
        public void Post_ValidYouTubeLink_ReturnsVideoId()
        {
            // Arrange
            var controller = new AnalyzeController();
            var request = new AnalyzeRequest
            {
                Url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ"
            };

            // Act
            var result = controller.Post(request) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var response = result.Value as AnalyzeResponse;
            Assert.NotNull(response);
            Assert.True(response.IsYouTubeLink);
            Assert.Equal("dQw4w9WgXcQ", response.VideoId);
        }

        [Fact]
        public void Post_YouTubeLinkWithoutVideoId_ReturnsIncorrectMessage()
        {
            // Arrange
            var controller = new AnalyzeController();
            var request = new AnalyzeRequest
            {
                Url = "https://www.youtube.com/watch?dQw4w9WgXcQ"
            };

            // Act
            var result = controller.Post(request) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var response = result.Value as AnalyzeResponse;
            Assert.NotNull(response);
            Assert.True(response.IsYouTubeLink);
            Assert.Null(response.VideoId);
            Assert.Equal("Incorrect YouTube link", response.Message);
        }

        [Fact]
        public void Post_NonYouTubeLink_ReturnsFalse()
        {
            // Arrange
            var controller = new AnalyzeController();
            var request = new AnalyzeRequest
            {
                Url = "https://example.com/video"
            };

            // Act
            var result = controller.Post(request) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var response = result.Value as AnalyzeResponse;
            Assert.NotNull(response);
            Assert.False(response.IsYouTubeLink);
            Assert.Null(response.VideoId);
        }

        [Fact]
        public void Post_EmptyUrl_ReturnsBadRequest()
        {
            // Arrange
            var controller = new AnalyzeController();
            var request = new AnalyzeRequest
            {
                Url = ""
            };

            // Act
            var result = controller.Post(request);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
