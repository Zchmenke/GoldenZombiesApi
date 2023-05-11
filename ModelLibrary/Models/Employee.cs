using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelLibrary.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "First name must be between 1 - 30 letters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Last name must be between 1 - 30 letters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }



        [JsonIgnore]
        public ICollection<TimeReport> TimeReports { get; set; }





    }
}
