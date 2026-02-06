using AudioLinker.Api.Models.Requests;
using System.ComponentModel.DataAnnotations;

namespace AudioLinker.Api.Tests
{
    public class AnalyzeRequestTests
    {
        [Fact]
        public void Url_Required_ErrorMessage_IsReturned()
        {
            // Arrange
            var model = new AnalyzeRequest { Url = null };
            var context = new ValidationContext(model) { MemberName = "Url" };
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(
                model,
                context,
                validationResults,
                validateAllProperties: false
            );

            // Assert
            Assert.False(isValid);
            Assert.Single(validationResults);
            Assert.Equal("Video url is required.", validationResults[0].ErrorMessage);
        }
    }
}
