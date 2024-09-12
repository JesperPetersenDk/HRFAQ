

using HrFaq.Application.Model;
using Model;

namespace HrFaq.Database.Infrastructure
{
    public interface ICommands
    {
        Task<List<Tuple<string>>> GetFaq();
        Task<List<Tuple<string, int>>> GetFaq(string text);
        Task<bool> CreateFaq(string searchwords, string answer);
        Task<int> AddMatchData(string text, string value, string codeValue);
        Task<List<Tuple<string, string, string>>> GetMatchData();
        Task<bool> RemoveMatchWordBool(bool settingRemoveMatch);
        Task<bool> RemoveMatchWordAndRemoveMatchFromContent(string codeValue, bool settingRemoveMatchWord);
        Task<string> FindMatchWordReplaceToLink(string codeValueInput, bool targetLink);
        Task AddQuestionStatus(string text, bool settingsBool);
        Task<bool> StatusRapport(bool settingStatusRapport);
        Task<List<FaqListModel>> GetListFaq();
        Task<bool> RemoveFaqFromList(string faqId);
        Task<RightFaqModel> GetSingleFaq(string FaqId);
    }
}
