using BlazorHrFaq.Database.Infrastructure;
using FaqModel;
using BlazorHrFaq.TextHelper;
using Helpers.ResponseModel;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace HRFaq.Faq.Service
{
    public interface IFaqService
    {
        Task<ResponseModel> AddAnswer(AnswerModel model);
        Task<ResponseModel> GetAnswersList(string answers);
        Task<ResponseModel> MatchWord(MatchModel model);
        Task<ResponseModel> GetMatchWord();
    }

    public class FaqService : IFaqService
    {
        private readonly ICommands _com;
        public FaqService(ICommands command)
        {
            _com = command;
        }

        public async Task<ResponseModel> MatchWord(MatchModel model)
        {
            var result = new ResponseDataModel();
            try
            {
                var resultData = await _com.AddMatchData(model.Text, model.Value);
                int returnBoolData = resultData.Item1;
                MatchViewModel dataModel = new MatchViewModel();
                dataModel.Code = resultData.Item2;

                result.Data = new ResponseModel()
                {
                    Message = (returnBoolData > 0) ? "Succes to save in database" : "Error to add in MatchData - Database",
                    MessegeTouser = (returnBoolData > 0) ? "Indholdet er gemt." : "Der er sket en fejl i tilføjelse til databasen",
                    Status = EnumStatusValue.Info,
                    GetData = new[] { dataModel }
                };
            }
            catch (Exception ex)
            {
                result.Data = new ResponseModel()
                {
                    MessegeTouser = "Indhold der er angivet bliver ikke godkendt",
                    Message = $"{ex.Message} - {ex}",
                    Status = EnumStatusValue.Error,
                };
            }
            return result.Data;
        }

        public async Task<ResponseModel> GetAnswersList(string answers)
        {
            var result = new ResponseDataModel();
            try
            {
                var resultData = await _com.GetFaq(answers);
                if(resultData != null && resultData.Count > 0)
                {
                    //Add Item to model
                    ListItemModel listItemModel = new ListItemModel();
                    listItemModel.SearchWord = answers;
                    listItemModel.data = new List<ListWithSearchDataModel>();
                    //Add Item to list of model
                    foreach (var item in resultData)
                    {
                        listItemModel.data.Add(new ListWithSearchDataModel
                        {
                            Answer = item.Answer,
                            HitCount = item.HitCount,
                        });
                    }


                    result.Data = new ResponseModel()
                    {
                        MessegeTouser = "Fremvisning af indhold: " + answers,
                        Message = "Show data to user",
                        Status = EnumStatusValue.Success,
                        GetData = new[] { listItemModel }
                    };
                }
                else
                {

                    result.Data = new ResponseModel()
                    {
                        MessegeTouser = TextHelperResFile.NotAnswersToUser.ToString().ReplaceText(answers),
                        Message = "Failed with search data - Try again",
                        Status = EnumStatusValue.Failed,
                    };
                }
            }
            catch (Exception ex)
            {
                result.Data = new ResponseModel()
                {
                    Message = $"{ex.Message} - {ex}",
                    Status = EnumStatusValue.Error,
                };
            }
            return result.Data;
        }

        public async Task<ResponseModel> GetMatchWord()
        {
            var result = new ResponseDataModel();
            try
            {
                MatchViewModel dataModel = new MatchViewModel();
                dataModel.data = new List<MatchListViewModel>();
                var listData = await _com.GetMatchData();
                foreach (var item in listData)
                {
                    dataModel.data.Add(new MatchListViewModel
                    {
                        CodeValue = item.CodeValue,
                        Text = item.Text,
                        Value = item.Value
                    });
                }
                result.Data = new ResponseModel()
                {
                    Message = "Show list to user",
                    Status = EnumStatusValue.Success,
                    GetData = new[] { dataModel }
                };
            }
            catch (Exception ex)
            {
                result.Data = new ResponseModel()
                {
                    Message = $"{ex.Message} - {ex}",
                    Status = EnumStatusValue.Error,
                };
            }
            return result.Data;
        }

        public async Task<ResponseModel> AddAnswer(AnswerModel model)
        {
            var result = new ResponseDataModel();
            try
            {
                var createFaq = await _com.CreateFaq(model.SearchWords, model.Answer);
                if (createFaq)
                {
                    result.Data = new ResponseModel()
                    {
                        MessegeTouser = "Tilføj indholdet.",
                        Message = $"Success to save in Database for user.",
                        Status = EnumStatusValue.Success,
                    };
                }
                else
                {
                    result.Data = new ResponseModel()
                    {
                        MessegeTouser = "Der er sket en fejl ved oprettelsen.",
                        Message = $"Cant not save in Database to Faq. - Try again.",
                        Status = EnumStatusValue.Failed,
                    };
                }
            }
            catch (Exception ex)
            {
                result.Data = new ResponseModel()
                {
                    Message = $"{ex.Message} - {ex}",
                    Status = EnumStatusValue.Error,
                };
            }
            return result.Data;
        }
    }
}
