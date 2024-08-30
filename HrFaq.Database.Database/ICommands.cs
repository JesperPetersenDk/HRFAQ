using HrFaq.Settings.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrFaq.Database.Infrastructure
{
    public interface ICommands
    {
        Task<List<Tuple<string>>> GetFaq();
        Task<List<Tuple<string, int>>> GetFaq(string text);
        Task<bool> CreateFaq(string searchwords, string answer);
        Task<Tuple<int, string>> AddMatchData(string text, string value);
        Task<List<Tuple<string, string, string>>> GetMatchData();
        Task<List<SettingModel>> SettingInformation();
        Task<bool> SaveSettingInfo(SettingModel model);
        Task<bool> RemoveMatchWordBool();
        Task<bool> RemoveMatchWordAndRemoveMatchFromContent(string codeValue);
    }
}
