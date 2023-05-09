using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public bool IsActive { get; set; }
        public DateTime ProjectStart { get; set; }
        public DateTime? ProjectEnd { get; set; }


        public ICollection<TimeReport> TimeReports { get; set; }
    }
}
