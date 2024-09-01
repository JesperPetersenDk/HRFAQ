using Helpers.ResponseModel;
using HrFaq.Database.Infrastructure;
using Model;

namespace Service
{
    public interface ISettingsService
    {
        Task<ResponseModel> GetSettingInformation();
        Task<ResponseModel> UpdateSettingInformation(SettingModel model);
        Task<ResponseModel> RemoveMatchWordStatus();
        Task<ResponseModel> RemoveMatchWordsFromContent(string codeValue);
    }

    public class SettingsService : ISettingsService
    {
        private readonly ICommands _com;
        public SettingsService(ICommands command)
        {
            _com = command;
        }
        public async Task<ResponseModel> GetSettingInformation()
        {
            var result = new ResponseDataModel();
            try
            {
                var com = await _com.SettingInformation();
                var resultData = com.Cast<SettingModel>().ToList();
                SettingModel model = new SettingModel();
                if (resultData != null && resultData.Count() > 0)
                {
                    foreach (var item in resultData)
                    {
                        model.AnswerMuli = item.AnswerMuli;
                        model.RemoveMatchWords = item.RemoveMatchWords;
                        model.CompanyCategory = item.CompanyCategory;
                        model.LoginUser = item.LoginUser;
                        model.StatusRapport = item.StatusRapport;
                        model.LinkTarget = item.LinkTarget;
                    }


                    result.Data = new ResponseModel()
                    {
                        Message = "Get information from Setting information service",
                        Status = EnumStatusValue.Info,
                        GetData = new[] { model }
                    };
                }
                else
                {
                    result.Data = new ResponseModel()
                    {
                        MessegeTouser = "Indhold der er angivet bliver ikke godkendt",
                        Message = $"Settings information failed. Try again.",
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
                var com = await _com.RemoveMatchWordAndRemoveMatchFromContent(codeValueInput);
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
                var resultData = await _com.RemoveMatchWordBool();
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

        public async Task<ResponseModel> UpdateSettingInformation(SettingModel model)
        {
            var result = new ResponseDataModel();
            try
            {
                bool saveInDatabase = await _com.SaveSettingInfo(model);
                if (saveInDatabase)
                {
                    result.Data = new ResponseModel()
                    {
                        MessegeTouser = "Er opdatere i database",
                        Message = "Success to save in database",
                        Status = EnumStatusValue.Success,
                    };
                }
                else
                {
                    result.Data = new ResponseModel()
                    {
                        MessegeTouser = "Sket en fejl i forhold til opdatering i databasen.",
                        Message = "Failed to save in Setting Information",
                        Status = EnumStatusValue.Failed,
                    };
                }
            }
            catch (Exception ex)
            {
                result.Data = new ResponseModel()
                {
                    MessegeTouser = $"Der er sket en fejl som gøre at indhold ikke blive opdateret. - Fejl besked: {ex.Message}",
                    Message = $"{ex.Message} - {ex}",
                    Status = EnumStatusValue.Error,
                };
            }
            return result.Data;
        }
    }
}
