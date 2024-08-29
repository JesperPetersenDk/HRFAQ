using BlazorHrFaq.Database.Model;
using Extensions;
using HrFaq.Database.Infrastructure;
using HrFaq.Settings.Model;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace BlazorHrFaq.Database.Infrastructure
{
    
    public class Commands : ICommands
    {
        public async Task<Tuple<int, string>> AddMatchData(string text, string value)
        {
            using (var db = new DatabaseDb())
            {
                int saveInDatabase = 0; // False to save in database
                string codeValue = Extensions.Extensions.FormatFileType(value);
                MatchData matchData = new MatchData
                {
                    CodeValue = codeValue,
                    Value = value,
                    Text = text
                };

                await db.Match.AddAsync(matchData);
                saveInDatabase = await db.SaveChangesAsync();

                return Tuple.Create(saveInDatabase, codeValue);
            }
        }

        public async Task<bool> CreateFaq(string searchwords, string answer)
        {
            using (var db = new DatabaseDb())
            {
                int saveInDatabase = 0; // False to save in database
                Faq matchData = new Faq
                {
                    Answer = answer,
                    SearchWords = searchwords
                };

                await db.Faq.AddAsync(matchData);
                saveInDatabase = await db.SaveChangesAsync();

                //error or success herre.
                bool saveInDb = saveInDatabase > 0 ? true : false;

                return saveInDb;
            }
        }

        public async Task<List<Tuple<string, int>>> GetFaq(string text)
        {
            using(var db = new DatabaseDb())
            {
                var list = new List<Tuple<string, int>>();
                var resultData = await db.Faq
                            .Where(r => r.SearchWords.Contains(text))
                            .ToListAsync(); // Sorter efter Priority fra højeste til laveste
                if(resultData != null)
                {
                    foreach(var result in resultData)
                    {
                        result.HitCount++;
                        await db.SaveChangesAsync();
                        list.Add(new Tuple<string, int>(result.Answer, result.HitCount ?? 0));
                    }
                }
                return list;                
            }
        }

        public async Task<List<Tuple<string>>> GetFaq()
        {
            using (var db = new DatabaseDb())
            {
                var list = new List<Tuple<string>>();
                var result = await db.Faq.ToListAsync();
                if(result != null)
                {
                    foreach (var item in result)
                    {
                        list.Add(new Tuple<string>(item.Answer));
                    }
                }
                return list;
            }
        }

        public async Task<List<Tuple<string, string,string>>> GetMatchData()
        {
            using (var db = new DatabaseDb())
            {
                var listData = new List<Tuple<string, string, string>>();
                var list = await db.Match.OrderByDescending(r => r.MatchId).ToListAsync();
                if(list.Count() > 0)
                {
                    foreach(var item in list)
                    {
                        listData.Add(new Tuple<string, string, string>(item.CodeValue, item.Text, item.Value));
                    }
                }
                return listData;
            }
        }

        public async Task<bool> SaveSettingInfo(SettingModel model)
        {
            using (var db = new DatabaseDb())
            {
                var resultData = await db.SettingInfo.FirstOrDefaultAsync();
                if(resultData != null )
                {
                    resultData.AnswerMuli = model.AnswerMuli;
                    resultData.RemoveMatchWords = model.RemoveMatchWords;
                    resultData.LoginUser = model.LoginUser;
                    resultData.CompanyCategory = model.CompanyCategory;
                    resultData.StatusRapport = model.StatusRapport;
                    int saveInDatabase = await db.SaveChangesAsync();
                    return (saveInDatabase > 0) ? true : false;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<List<SettingModel>> SettingInformation()
        {
            using (var db = new DatabaseDb())
            {
                var list = new List<SettingModel>();
                var resultData = await db.SettingInfo.FirstOrDefaultAsync();
                if( resultData != null)
                {
                    list.Add(new SettingModel
                    {
                        AnswerMuli = resultData.AnswerMuli,
                        CompanyCategory = resultData.CompanyCategory,
                        LoginUser = resultData.LoginUser,
                        RemoveMatchWords = resultData.RemoveMatchWords,
                        StatusRapport = resultData.StatusRapport
                    });
                }
                return list;
            }
        }
    }
}
