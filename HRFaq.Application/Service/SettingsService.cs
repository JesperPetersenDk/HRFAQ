using Helpers.ResponseModel;
using HrFaq.Application.Model;
using HrFaq.Database.Infrastructure;
using Microsoft.Extensions.Configuration;
using Model;

namespace Service
{
    public interface ISettingsService
    {
        Task<ResponseModel> RemoveMatchWordStatus();
        Task<ResponseModel> RemoveMatchWordsFromContent(string codeValue);
        Task<ResponseModel> StatusRapport();
        Task<ResponseModel> LettersSetting();
    }

    public class SettingsService : ISettingsService
    {
        private readonly ICommands _com;
        private readonly IConfiguration _configuration;
        public SettingsService(ICommands command, IConfiguration configuration)
        {
            _com = command;
            _configuration = configuration;
        }

        public async Task<ResponseModel> LettersSetting()
        {
            var result = new ResponseDataModel();
            try
            {
                LettersSettingModel model = new LettersSettingModel();
                model.After = _configuration.GetSection("LettersSetting:after").Value.ToString() ?? "";
                model.Count = Convert.ToInt16(_configuration.GetSection("LettersSetting:count").Value);

                if(model.Count > 0)
                {
                    result.Data = new ResponseModel()
                    {
                        Message = "Letters Setting returne information",
                        Status = EnumStatusValue.Success,
                        GetData = new[] {model}
                    };
                }
                else
                {
                    result.Data = new ResponseModel()
                    {
                        Message = "Letters Setting Count 0",
                        Status = EnumStatusValue.Failed,
                    };
                }

            }
            catch (Exception ex)
            {
                result.Data = new ResponseModel()
                {
                    MessegeTouser = $"Der kunne ikke blive hentet indhold - Fejl besked {ex.Message}",
                    Message = $"{ex.Message} - {ex}",
                    Status = EnumStatusValue.Error,
                };
            }
            return result.Data;
        }

        public async Task<ResponseModel> RemoveMatchWordsFromContent(string codeValueInput)
        {
            var result = new ResponseDataModel();
            try
            {
                bool removeMatchBool = bool.TryParse(_configuration["SettingInformation:RemoveMatchWord"], out bool returnBool) && returnBool;
                var com = await _com.RemoveMatchWordAndRemoveMatchFromContent(codeValueInput, removeMatchBool);
                if (com)
                {
                    result.Data = new ResponseModel()
                    {
                        Message = "Remove Match word + Remove Match Word from content",
                        Status = EnumStatusValue.Success
                    };
                }
                else
                {
                    result.Data = new ResponseModel()
                    {
                        Message = "Failed to remove match word from content.",
                        Status = EnumStatusValue.Failed
                    };
                }

            }
            catch (Exception ex)
            {
                result.Data = new ResponseModel()
                {
                    MessegeTouser = $"Der kunne ikke blive hentet indhold - Fejl besked {ex.Message}",
                    Message = $"{ex.Message} - {ex}",
                    Status = EnumStatusValue.Error,
                };
            }
            return result.Data;
        }

        public async Task<ResponseModel> RemoveMatchWordStatus()
        {
            var result = new ResponseDataModel();
            try
            {
                bool removeMatchBool = bool.TryParse(_configuration["SettingInformation:RemoveMatchWord"], out bool returnBool) && returnBool;
                var resultData = await _com.RemoveMatchWordBool(removeMatchBool);
                result.Data = new ResponseModel()
                {
                    Message = resultData ? "Can remove match word" : "Cant remove match word",
                    Status = resultData ? EnumStatusValue.Success : EnumStatusValue.Info,
                    GetData = new[] { resultData }
                };
            }
            catch (Exception ex)
            {
                result.Data = new ResponseModel()
                {
                    MessegeTouser = $"Der kunne ikke blive hentet indhold - Fejl besked {ex.Message}",
                    Message = $"{ex.Message} - {ex}",
                    Status = EnumStatusValue.Error,
                };
            }
            return result.Data;
        }

        public async Task<ResponseModel> StatusRapport()
        {
            var result = new ResponseDataModel();
            try
            {
                bool statusBool = bool.TryParse(_configuration["SettingInformation:StatusRapport"], out bool returnBool) && returnBool;
                if (statusBool)
                {
                    result.Data = new ResponseModel()
                    {
                        Message = "Get status from statusrapport",
                        Status = EnumStatusValue.Success,
                        GetData = new[] { statusBool }
                    };
                }
                else
                {
                    result.Data = new ResponseModel()
                    {
                        Message = "Failed to get Status rapport.",
                        Status = EnumStatusValue.Failed,
                    };
                }
            }
            catch (Exception ex)
            {
                result.Data = new ResponseModel()
                {
                    MessegeTouser = $"Der kunne ikke blive hentet indhold - Fejl besked {ex.Message}",
                    Message = $"{ex.Message} - {ex}",
                    Status = EnumStatusValue.Error,
                };
            }
            return result.Data;
        }

    }
}
