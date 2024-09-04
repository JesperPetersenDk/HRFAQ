using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrFaq.Application.Database.Model
{
    public class Questions
    {
        [Key]
        public Guid QuestionID { get; set; } = Guid.NewGuid();  // Primærnøgle

        [Required]
        [StringLength(255)]
        public string QuestionType { get; set; }  // Typen af spørgsmålet

        [Required]
        public DateTime DateAsked { get; set; } = DateTime.Now; // Datoen spørgsmålet blev stillet
    }
}
