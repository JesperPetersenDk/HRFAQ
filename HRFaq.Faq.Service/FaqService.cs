using System.Text.RegularExpressions;

namespace HRFaq.Faq.Service
{
    public interface IFaqService
    {
        List<string> GetSearchWordsList(string searchWords);
        List<string> GetAnswersList(string answers);
    }

    public class FaqService : IFaqService
    {
        // Hjælpefunktion til at opdele en streng ved {} eller {{}}
        private List<string> SplitStringByDelimiters(string input)
        {
            if (string.IsNullOrEmpty(input))
                return new List<string>();

            // Brug Regex til at splitte på {} eller {{}}
            string pattern = @"\{\{.*?\}\}|\{.*?\}";
            var matches = Regex.Matches(input, pattern);

            return matches.Select(m => m.Value.Trim('{', '}')).ToList();
        }

        // Funktion til at hente liste over søgeord
        public List<string> GetSearchWordsList(string searchWords)
        {
            return SplitStringByDelimiters(searchWords);
        }

        // Funktion til at hente liste over svar
        public List<string> GetAnswersList(string answers)
        {
            return SplitStringByDelimiters(answers);
        }
    }
}
