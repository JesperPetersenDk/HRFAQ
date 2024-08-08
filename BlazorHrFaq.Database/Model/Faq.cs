using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlazorHrFaq.Database.Model
{
    public class Faq
    {
        [Key]
        public Guid FaqId { get; set; }
        public string SearchWords { get; set; }
        public string Answer { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int? HitCount { get; set; } = 0;
        public int? Priority { get; set; } = 5;

    }
}
