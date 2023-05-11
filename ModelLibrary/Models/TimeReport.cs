using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelLibrary.Models
{
    public class TimeReport
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Must Set the Employees ID")]
        public int EmployeeId { get; set; }
        [JsonIgnore]
        public Employee Employee { get; set; }
        [Required(ErrorMessage = "Must Set the Projects ID")]
        public int ProjectId { get; set; }
        [JsonIgnore]
        public Project project { get; set; }
        [Required(ErrorMessage = "Insert number of hours worked")]
        public double HoursWorked  { get; set; }
        [Required(ErrorMessage = "Insert related week number")]
        public int WeekNumber { get; set; }



    }
}
