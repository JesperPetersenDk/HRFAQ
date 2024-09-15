using Helpers.ResponseModel;
using HrFaq.Database.Infrastructure;
using Microsoft.Extensions.Configuration;
using Moq;
using Service;

namespace HrFaq.Settings.Xunit.Test
{
    public class TestSettingsService
    {
        private readonly Mock<ICommands> _mockCommands;
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly SettingsService _settingsService;

        public TestSettingsService()
        {
            _mockCommands = new Mock<ICommands>();
            _mockConfiguration = new Mock<IConfiguration>();

            // Initialize the SettingsService with mocked dependencies
            _settingsService = new SettingsService(_mockCommands.Object, _mockConfiguration.Object);
        }

        [Fact]
        public async Task LettersSetting_ReturnsSuccess()
        {
            var result = await _settingsService.LettersSetting();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task LettersSetting_ReturnsSuccess_NullData()
        {
            var result = await _settingsService.LettersSetting();

            Assert.Null(result.GetData);
        }

    }
}