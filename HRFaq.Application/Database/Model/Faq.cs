using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlazorHrFaq.Database.Model
{
    public class Faq
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid FaqId { get; set; } = Guid.NewGuid();
        public string SearchWords { get; set; }
        public string Answer { get; set; }
        public DateTime CreateDatetime { get; set; } = DateTime.Now;
        public int? HitCount { get; set; } = 0;
    }
}
