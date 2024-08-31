using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaqModel
{
    public class ListItemModel
    {
        public string SearchWord { get; set; } = string.Empty;

        public List<ListWithSearchDataModel> data { get; set; }
    }

    public class ListWithSearchDataModel
    {
        public string Answer { get; set; } = string.Empty;
        public int? HitCount { get; set; } = 0;
    }
}
