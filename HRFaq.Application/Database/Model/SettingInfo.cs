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

        public bool LoginUser { get; set; }
        public bool RemoveMatchWords { get; set; }
        public bool CompanyCategory { get; set; }
        public bool AnswerMuli { get; set; }
        public bool StatusRapport { get; set; }

    }
}
