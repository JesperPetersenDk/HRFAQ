using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaqModel
{
    public class MatchViewModel
    {
        public string Code { get; set; } = string.Empty;
        public List<MatchListViewModel> data { get; set; }
    }

    public class MatchListViewModel
    {
        public string Value { get; set; } //Url to site, image url or other.
        public string Text { get; set; } //Text to link, value to image or other.
        public string CodeValue { get; set; } // Random code value to user
    }
}
