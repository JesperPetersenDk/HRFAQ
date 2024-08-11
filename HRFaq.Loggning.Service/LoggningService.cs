using Helpers.ResponseModel;
using Helpers.ResponseModel.Enum;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;

namespace HRFaq.Loggning.Service
{
    public interface ILoggningService
    {
        void Log(string message, EnumStatusValue enumStatusValue);
    }

    public class LoggningService : ILoggningService
    {
        private readonly ILogger _logger;
        public LoggningService(IConfiguration configuration)
        {
            var logMode = configuration.GetValue<int>("Serilog:LogMode");
            var loggerConfig = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration);

            if (logMode == 1 || logMode == 3)
            {
                // File logging
                loggerConfig.WriteTo.File(
                    path: configuration["Serilog:File:Path"],
                    rollingInterval: RollingInterval.Day);
            }

            if (logMode == 2 || logMode == 3)
            {
                // Database logging
                loggerConfig.WriteTo.MSSqlServer(
                    connectionString: configuration["Database:ConnectionString"],
                    tableName: configuration["Serilog:DatabaseSerilog:TableName"],
                    autoCreateSqlTable: true);
            }

            _logger = loggerConfig.CreateLogger();
        }

        public void Log(string message, EnumStatusValue enumStatusValue)
        {
            switch (enumStatusValue)
            {
                case EnumStatusValue.Info:
                case EnumStatusValue.Success:
                    _logger.Information(message);
                    break;

                case EnumStatusValue.Failed:
                    _logger.Warning(message);
                    break;

                case EnumStatusValue.Error:
                    _logger.Error(message);
                    break;

                case EnumStatusValue.Unknown:
                    _logger.Information("Unknown status: " + message);
                    break;

                default:
                    _logger.Information(message);
                    break;
            }
        }
    }
}
