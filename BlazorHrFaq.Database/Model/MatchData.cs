using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHrFaq.Database.Model
{
    public class MatchData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MatchId { get; set; } = Guid.NewGuid();
        public string Value { get; set; } //Url to site, image url or other.
        public string Text { get; set; } //Text to link, value to image or other.
        public string Type { get; set; } //Link, Img, PDFfile
        public string CodeValue { get; set; } // Random code value to user
    }
}
