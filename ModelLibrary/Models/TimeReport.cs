﻿using System;
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

        public int EmployeeId { get; set; }
        [JsonIgnore]
        public Employee Employee { get; set; }
        public int ProjectId { get; set; }
        [JsonIgnore]
        public Project project { get; set; }
        public double HoursWorked  { get; set; }
        public int WeekNumber { get; set; }



    }
}
