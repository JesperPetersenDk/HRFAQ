using Extensions;
using FaqModel;
using Helpers.ResponseModel;
using HrFaq.Application.Helper;
using HrFaq.Database.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Service
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
        private readonly IConfiguration _configuration;
        public FaqService(ICommands command, IConfiguration configuration)
        {
            _com = command;
            _configuration = configuration;
        }

        public async Task<ResponseModel> MatchWord(MatchModel model)
        {
            var result = new ResponseDataModel();
            try
            {
                string codeValue = model.Value.FormatFileType();
                var resultData = await _com.AddMatchData(model.Text, model.Value, codeValue);
                int returnBoolData = resultData;
                MatchViewModel dataModel = new MatchViewModel();
                dataModel.Code = codeValue;

                result.Data = new ResponseModel()
                {
                    Message = returnBoolData > 0 ? "Succes to save in database" : "Error to add in MatchData - Database",
                    MessegeTouser = returnBoolData > 0 ? "Indholdet er gemt." : "Der er sket en fejl i tilføjelse til databasen",
                    Status = returnBoolData > 0 ? EnumStatusValue.Success : EnumStatusValue.Failed,
                    GetData = new[] { dataModel }
                };
            }
            catch (Exception ex)
            {
                result.Data = new ResponseModel()
                {
                    MessegeTouser = $"Der er sket en fejl ved matchword - Fejl besked: {ex.Message}",
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
                bool targetBool = false;
                var targetBlank = _configuration.GetSection("SettingInformation:TargetBlankLink").Value;
                if(targetBlank.Contains("True"))
                {
                    targetBool = true;
                }
                var resultData = await _com.GetFaq(answers);
                if (resultData != null && resultData.Count() > 0)
                {
                    //Add Item to model
                    ListItemModel listItemModel = new ListItemModel();
                    listItemModel.SearchWord = answers;
                    listItemModel.data = new List<ListWithSearchDataModel>();
                    //Add Item to list of model
                    foreach (var item in resultData)
                    {
                        string answerReplaceContent = await _com.FindMatchWordReplaceToLink(item.Item1, targetBool);
                        listItemModel.data.Add(new ListWithSearchDataModel
                        {
                            Answer = answerReplaceContent,
                            HitCount = item.Item2,
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
                    MessegeTouser = $"Der er sket en fejl prøv igen. Fejl besked: {ex.Message}",
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
                // Opret HashSet til at holde styr på fundne nøgleord
                HashSet<string> foundKeywords = new HashSet<string>();

                // Initialiser data modellen
                MatchViewModel dataModel = new MatchViewModel
                {
                    data = new List<MatchListViewModel>()
                };

                // Hent data fra eksterne kilder
                var matchDataList = await _com.GetMatchData();
                var faqList = await _com.GetFaq();

                // Gennemgå match data listen
                foreach (var matchData in matchDataList)
                {
                    // Hvis nøgleordet allerede er fundet, springes det over
                    if (foundKeywords.Contains(matchData.Item1))
                    {
                        continue;
                    }

                    // Gennemgå FAQ-listen
                    bool isMatchFound = false;
                    foreach (var faq in faqList)
                    {
                        // Tjek om FAQ-svar indeholder match-koden
                        if (faq.Item1.Contains(matchData.Item1))
                        {
                            foundKeywords.Add(matchData.Item1);
                            isMatchFound = true;
                            break;  // Stop gennemgangen af FAQ-listen, når et match er fundet
                        }
                    }

                    // Tilføj data til modellen
                    dataModel.data.Add(new MatchListViewModel
                    {
                        CodeValue = matchData.Item1,
                        Text = matchData.Item2,
                        Value = matchData.Item3,
                        MatchWord = isMatchFound
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
                    MessegeTouser = $"Der er sket en fejl prøv igen. Fejl besked: {ex.Message}",
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
                    MessegeTouser = $"Der er sket en fejl prøv igen. Fejl besked: {ex.Message}",
                    Message = $"{ex.Message} - {ex}",
                    Status = EnumStatusValue.Error,
                };
            }
            return result.Data;
        }


    }
}
