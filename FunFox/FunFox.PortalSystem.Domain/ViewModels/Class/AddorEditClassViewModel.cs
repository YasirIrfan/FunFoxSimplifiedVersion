using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunFox.PortalSystem.Domain.ViewModels.Class
{
    public class AddorEditClassViewModel
    {

        /*
        public int Id { get; set; }
        public string ProgramDetails { get; set; } = null!;
        public string GradeLevel { get; set; } = null!;
        public string ClassStartTime { get; set; } = null!;
        public string ClassEndTime { get; set; } = null!;
        public string MaxClassSize { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public string ModifiedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Boolean Deleted { get; set; }

         */
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Program Details is Required.")]
        public string? ProgramDetails { get; set; }

        [Required(ErrorMessage = "Grade Level is Required.")]
        [StringLength(50)]
        public string? GradeLevel { get; set; }

        [Required(ErrorMessage = "Class Start Time is Required.")]
        [StringLength(50)]
        public string? ClassStartTime { get; set; }

        [Required(ErrorMessage = "Class End Time  is Required.")]
        public string? ClassEndTime { get; set; }

        [Required(ErrorMessage = "MaxClassSize  is Required.")]
        public string? MaxClassSize { get; set; }
       
    }
}
