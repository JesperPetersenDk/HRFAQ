using HrFaq.Database.Infrastructure;
using Microsoft.Extensions.Configuration;
using Moq;
using Service;

namespace BlazorHrFaq.Faq.Xunit.Test
{
    public class TestFaqService
    {
        private readonly Mock<ICommands> _mockCommands;
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly FaqService _faqService;

        public TestFaqService()
        {
            _mockCommands = new Mock<ICommands>();
            _mockConfiguration = new Mock<IConfiguration>();

            // Initialize the FaqService with mocked dependencies
            _faqService = new FaqService(_mockCommands.Object, _mockConfiguration.Object);
        }

        [Fact]
        public async void GetMatchWord_NotNull()
        {
            var result = await _faqService.GetMatchWord();
            Assert.NotNull(result);
        }

        [Fact]
        public async void GetMatchWord_GetDataIsNull()
        {
            var result = await _faqService.GetMatchWord();
            Assert.Null(result.GetData);
        }
    }
}