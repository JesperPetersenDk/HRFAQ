using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrFaq.Database.Model
{
    public class StatusRapport
    {
        [Key]
        public Guid StatusId { get; set; }
        public DateTime TimeAsked { get; set; } = DateTime.Now;
        public string Content { get; set; }
    }
}
