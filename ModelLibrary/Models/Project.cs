using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelLibrary.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Project name must be between 1 - 50 letters")]
        public string ProjectName { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime ProjectStart { get; set; }

        public DateTime? ProjectEnd { get; set; }

        [JsonIgnore]
        public ICollection<TimeReport> TimeReports { get; set; }
    }
}
