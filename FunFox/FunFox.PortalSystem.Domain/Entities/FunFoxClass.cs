using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunFox.PortalSystem.Domain.Entities
{
    public class FunFoxClass
    {
        public int Id { get; set; }
        public string? ProgramDetails { get; set; } = null!;
        public string? GradeLevel { get; set; } = null!;
        public string? ClassStartTime { get; set; } = null!;
        public string? ClassEndTime { get; set; } = null!;
        public string? MaxClassSize { get; set; } = null!;
        public string? CreatedBy { get; set; } = null!;
        public string? ModifiedBy { get; set; } = null!;
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public Boolean? Deleted { get; set; }
    }

}
