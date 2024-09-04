using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrFaq.Application.Database.Model
{
    public class QuestionStats
    {
        [Key, Column(Order = 1)]
        public DateTime Date { get; set; }  // Dato for statistikken

        [Key, Column(Order = 2)]
        [StringLength(255)]
        public string QuestionType { get; set; }  // Typen af spørgsmålet

        [Required]
        public int Count { get; set; }  // Antal spørgsmål af denne type på denne dato
    }
}
