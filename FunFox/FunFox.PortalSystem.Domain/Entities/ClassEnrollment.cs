using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunFox.PortalSystem.Domain.Entities
{
    public class ClassEnrollment
    {
        public int Id { get; set; }
        [ForeignKey(nameof(FunFoxClass))]
        public string ClassId { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public string CreatedBy { get; set; } = null!;
        public string ModifiedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Boolean Deleted { get; set; }

    }
}
