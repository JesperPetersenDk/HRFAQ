using BlazorHrFaq.Database.Infrastructure;
using BlazorHrFaq.Faq.Model;
using BlazorHrFaq.TextHelper;
using Helpers.ResponseModel;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace HRFaq.Faq.Service
{
    public interface IFaqService
    {
        Task<ResponseModel> GetAnswersList(string answers);
    }

    public class FaqService : IFaqService
    {
        private readonly ICommands _com;
        public FaqService(ICommands command)
        {
            _com = command;
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
                        Message = "Show data to user",
                        Status = EnumStatusValue.Success,
                        GetData = new[] { listItemModel }
                    };
                }
                else
                {
                    result.Data = new ResponseModel()
                    {
                        Message = TextHelperResFile.NotAnswersToUser.ToString().ReplaceText(answers),
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
