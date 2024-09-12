using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrFaq.Application.Model
{
    public class RightFaqModel
    {
        public Guid FaqId { get; set; }
        public string SearchWord { get; set; }
        public string Answer { get; set; }
    }
}
