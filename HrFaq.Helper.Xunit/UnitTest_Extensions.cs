namespace HrFaq.Helper.Xunit
{
    public class UnitTest_Extensions
    {
        [Fact]
        public void FormatFileType_Url_ReturnsCorrectFormat()
        {
            // Arrange
            string input = "https://example.com";

            // Act
            string result = Extensions.Extensions.FormatFileType(input);

            // Assert
            Assert.StartsWith("{{site:", result);
            Assert.EndsWith("}}", result);
        }

        [Fact]
        public void FormatFileType_Url_ReturnsCorrectFormat_UniqueIdentifier()
        {
            // Arrange
            string input = "https://example.com";

            // Act
            string result = Extensions.Extensions.FormatFileType(input);
            string resultTwo = Extensions.Extensions.FormatFileType(input);

            // Assert
            Assert.NotSame(result, resultTwo);
        }

        [Fact]
        public void FormatFileType_EmptyInput_ThrowsArgumentException()
        {
            // Arrange
            string input = "";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => Extensions.Extensions.FormatFileType(input));
        }

        [Fact]
        public void FormatFileType_NullInput_ThrowsArgumentException()
        {
            // Arrange
            string input = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => Extensions.Extensions.FormatFileType(input));
        }

    }
}