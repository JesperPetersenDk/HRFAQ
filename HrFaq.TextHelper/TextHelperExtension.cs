using BlazorHrFaq.TextHelper;

namespace System
{
    public static class TextHelperExtension
    {
        public static string ReplaceText(this string text, string? word)
        {
            return text
                .Replace("{sitename}".ToLower(), TextHelperResFile.Sitename)
                .Replace("{searchword}".ToLower(), word)
                .Replace("{titlename}".ToLower(), TextHelperResFile.TitleName);
        }
    }
}
