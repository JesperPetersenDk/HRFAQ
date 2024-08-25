using BlazorHrFaq.Database.Model;
using Extensions;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace BlazorHrFaq.Database.Infrastructure
{
    public interface ICommands
    {
        Task<List<Tuple<string, int>>> GetFaq(string text);
        Task<bool> CreateFaq(string searchwords, string answer);
        Task<Tuple<int, string>> AddMatchData(string text, string value);
        Task<List<Tuple<string, string, string>>> GetMatchData();
    }
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
    }
}
