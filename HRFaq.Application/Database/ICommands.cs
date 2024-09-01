

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
        Task<List<SettingModel>> SettingInformation();
        Task<bool> SaveSettingInfo(SettingModel model);
        Task<bool> RemoveMatchWordBool();
        Task<bool> RemoveMatchWordAndRemoveMatchFromContent(string codeValue);
        Task<string> FindMatchWordReplaceToLink(string codeValueInput);
    }
}
