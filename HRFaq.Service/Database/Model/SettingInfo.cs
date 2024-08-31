using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrFaq.Database.Model
{
    public class SettingInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SettingInfoId { get; set; } = Guid.NewGuid();

        public bool LoginUser { get; set; } = false;
        public bool RemoveMatchWords { get; set; } = false;
        public bool CompanyCategory { get; set; } = false;
        public bool AnswerMuli { get; set; } = true;
        public bool StatusRapport { get; set; } = false;

    }
}
