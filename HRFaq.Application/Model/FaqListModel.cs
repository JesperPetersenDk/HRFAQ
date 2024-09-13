using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrFaq.Application.Model
{
    public class FaqListModel
    {
        public Guid FaqId { get; set; }
        public string SearchWords { get; set; }
        public string Answer { get; set; }
        public DateTime CreateDatetime { get; set; }
        public int HitCount { get; set; }
    }
}
