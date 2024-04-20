using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunFox.PortalSystem.Domain.ViewModels.Class
{
    public class ClassViewModel
    {
        public string ProgramDetails { get; set; } = null!;
        public string GradeLevel { get; set; } = null!;
        public string ClassStartTime { get; set; } = null!;
        public string ClassEndTime { get; set; } = null!;

    }
}
