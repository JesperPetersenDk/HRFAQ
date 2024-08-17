using BlazorHrFaq.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorHrFaq.Database.Infrastructure
{
    public interface ICommands
    {
        Task<List<Faq>> GetFaq(string text);
    }
    public class Commands : ICommands
    {
        public async Task<List<Faq>> GetFaq(string text)
        {
            using(var db = new DatabaseDb())
            {
                return await db.Faq
                            .Where(r => r.SearchWords.Contains(text))
                            .OrderByDescending(r => r.Priority)
                            .ToListAsync(); // Sorter efter Priority fra højeste til laveste
            }
        }
    }
}
