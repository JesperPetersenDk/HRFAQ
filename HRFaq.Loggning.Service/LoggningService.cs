using Helpers.ResponseModel;

namespace HRFaq.Loggning.Service
{
    public interface ILoggningService
    {
        Task Addloggning(string message);
        Task Addloggning(ResponseModel responseModel);
    }

    public class LoggningService : ILoggningService
    {
        public Task Addloggning(string message)
        {
            throw new NotImplementedException();
        }

        public Task Addloggning(ResponseModel responseModel)
        {
            throw new NotImplementedException();
        }
    }
}
