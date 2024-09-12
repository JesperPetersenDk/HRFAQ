using BlazorHrFaq.Database.Model;
using HrFaq.Application.Database.Model;
using HrFaq.Application.Model;
using HrFaq.Database.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace BlazorHrFaq.Database.Infrastructure
{

    public class Commands : ICommands
    {
        public async Task<int> AddMatchData(string text, string value, string codeValue)
        {
            using (var db = new DatabaseDb())
            {
                int saveInDatabase = 0; // False to save in database
                MatchData matchData = new MatchData
                {
                    CodeValue = codeValue,
                    Value = value,
                    Text = text
                };

                await db.Match.AddAsync(matchData);
                saveInDatabase = await db.SaveChangesAsync();

                return saveInDatabase;
            }
        }

        public async Task AddQuestionStatus(string text, bool settingsBool)
        {
            using (var db = new DatabaseDb())
            {
                if (settingsBool)
                {
                    var question = new Questions
                    {
                        QuestionType = text
                    };
                    db.Questions.Add(question);
                    await db.SaveChangesAsync();
                }
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

        public async Task<string> FindMatchWordReplaceToLink(string codeValueInput, bool targetLink)
        {
            // Regex pattern to find all occurrences of {{site:XXXX}} where XXXX is a number
            var pattern = @"{{site:([a-zA-Z0-9]+)}}";
            var match = Regex.Match(codeValueInput, pattern);

            // No matches, return the original input
            if (!match.Success)
                return codeValueInput;

            // Use StringBuilder for efficient string manipulation
            var result = new StringBuilder(codeValueInput);

            if (match.Success)
            {
                // Extract the code value from the match
                var codeValue = match.Value.Replace("{{{", "{{").Replace("}}}","}}");

                using (var db = new DatabaseDb())
                {
                    // Find the corresponding entry in the database
                    var replaceContent = await db.Match.FirstOrDefaultAsync(r => r.CodeValue == codeValue);
                    if (replaceContent != null)
                    {
                        string replacement = string.Empty;
                        if (targetLink)
                        {
                            replacement = $"<a href=\"{replaceContent.Value}\" target=\"_blank\">{replaceContent.Text}</a>";
                        }
                        else
                        {
                            // Return the HTML link
                            replacement = $"<a href=\"{replaceContent.Value}\">{replaceContent.Text}</a>";
                        }

                        result.Replace(match.Value, replacement);
                    }
                }
            }

            // If no match is found or no corresponding database entry exists, return an empty string
            return result.ToString();
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

        public async Task<List<FaqListModel>> GetListFaq()
        {
            using (var db = new DatabaseDb())
            {
                var list = new List<FaqListModel>();
                var result = await db.Faq.OrderByDescending(r => r.FaqId).ToListAsync();
                if( result != null)
                {
                    foreach (var item in result)
                    {
                        list.Add(new FaqListModel
                        {
                            FaqId = item.FaqId,
                            Answer = item.Answer,
                            CreateDatetime = item.CreateDatetime,
                            HitCount = item.HitCount ?? 0,
                            SearchWords = item.SearchWords
                        });
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

        public async Task<RightFaqModel> GetSingleFaq(string FaqId)
        {
            using (var db = new DatabaseDb())
            {
                RightFaqModel model = new RightFaqModel();
                Guid faqIdGuid = new Guid(FaqId);
                var result = await db.Faq.FirstOrDefaultAsync(r => r.FaqId == faqIdGuid);
                if(result == null)
                {
                    return model;
                }
                else
                {
                    model.Answer = result.Answer;
                    model.FaqId = result.FaqId;
                    model.SearchWord = result.SearchWords;
                }
                return model;
            }
        }

        public async Task<bool> RemoveFaqFromList(string faqId)
        {
            using (var db = new DatabaseDb())
            {
                var returnData = false;
                var idGuid = new Guid(faqId);
                var result = await db.Faq.FirstOrDefaultAsync(r => r.FaqId == idGuid);
                if(result != null)
                {
                    db.Faq.Remove(result);
                    int saveInDatabase = await db.SaveChangesAsync();
                    returnData = (saveInDatabase > 0) ? true : false;
                }
                return returnData;
            }
        }

        public async Task<bool> RemoveMatchWordAndRemoveMatchFromContent(string codeValue, bool settingRemoveMatchWord)
        {
            using (var db = new DatabaseDb())
            {
                bool returnData = false;
                if(settingRemoveMatchWord)
                {
                    var resultContent = await db.Faq.Where(r => r.Answer.Contains(codeValue)).ToListAsync();
                    if (resultContent.Count() > 0)
                    {
                        // Loop through each item in resultContent
                        foreach (var item in resultContent)
                        {
                            // Use Regex to remove placeholders like {{site:6a077be658}}
                            item.Answer = System.Text.RegularExpressions.Regex.Replace(item.Answer, @"{{site:[^}]+}}", "");

                            // Trim any extra spaces that may be left after removal
                            item.Answer = item.Answer.Trim();
                        }

                        // Save the changes to the database
                        await db.SaveChangesAsync();
                    }

                    var resultRemove = await db.Match.FirstOrDefaultAsync(r => r.CodeValue.Contains(codeValue));
                    if(resultRemove != null)
                    {
                        db.Match.Remove(resultRemove);
                        int saveInDatabase = await db.SaveChangesAsync();

                        returnData = (saveInDatabase > 0) ? true : false;
                    }
                }
                return returnData;
            }
        }

        public async Task<bool> RemoveMatchWordBool(bool settingRemoveMatch)
        {
            using (var db = new DatabaseDb())
            {
                return (settingRemoveMatch) ? true : false;
            }
        }

        public async Task<bool> StatusRapport(bool settingStatusRapport)
        {
            using (var db = new DatabaseDb())
            {
                if (settingStatusRapport)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
