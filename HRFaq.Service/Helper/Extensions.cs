using System.Text.RegularExpressions;

namespace Extensions
{
    public static class Extensions
    {
        public static string FormatFileType(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input string cannot be null or empty.");
            }

            // Regular expressions to identify the file types or URL
            //var pdfRegex = new Regex(@"\.pdf$", RegexOptions.IgnoreCase);
            //var imgRegex = new Regex(@"\.(jpg|jpeg|png|gif)$", RegexOptions.IgnoreCase);
            var urlRegex = new Regex(@"^https?:\/\/[^\s]+$", RegexOptions.IgnoreCase);

            // Generate a unique identifier based on the current timestamp
            var uniqueIdentifier = Guid.NewGuid().ToString("N").Substring(0, 10);

            // Check if the input is a PDF file
            //if (pdfRegex.IsMatch(input))
            //{
            //    return $"{{{{pdf:{uniqueIdentifier}}}}}";
            //}
            //// Check if the input is an image file
            //else if (imgRegex.IsMatch(input))
            //{
            //    return $"{{{{img:{uniqueIdentifier}}}}}";
            //}
            // Check if the input is a URL
            if (urlRegex.IsMatch(input))
            {
                return $"{{{{site:{uniqueIdentifier}}}}}";
            }
            else
            {
                throw new ArgumentException("The input string is not recognized as a PDF, image file, or URL.");
            }
        }
    }
}
