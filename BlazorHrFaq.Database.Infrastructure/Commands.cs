﻿using BlazorHrFaq.Database.Model;
using Extensions;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace BlazorHrFaq.Database.Infrastructure
{
    public interface ICommands
    {
        Task<List<Faq>> GetFaq(string text);
        Task<Tuple<int, string>> AddMatchData(string text, string value);
        Task<List<MatchData>> GetMatchData();
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

        public async Task<List<Faq>> GetFaq(string text)
        {
            using(var db = new DatabaseDb())
            {
                var resultData = await db.Faq
                            .Where(r => r.SearchWords.Contains(text))
                            .OrderByDescending(r => r.Priority)
                            .ToListAsync(); // Sorter efter Priority fra højeste til laveste
                if(resultData != null)
                {
                    foreach(var result in resultData)
                    {
                        result.HitCount++;
                        await db.SaveChangesAsync();
                    }
                    return resultData;
                }
                return null;                
            }
        }

        public async Task<List<MatchData>> GetMatchData()
        {
            using (var db = new DatabaseDb())
            {
                return await db.Match.OrderByDescending(r => r.MatchId).ToListAsync();
            }
        }
    }
}
