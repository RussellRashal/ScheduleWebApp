using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScheduleWebApp.Models;
using System.ComponentModel.DataAnnotations;
using ScheduleWebApp.Dtos;

namespace ScheduleWebApp.Dtos
{
    public class ScheduleDateAndTimeDto
    {   
        public int id { get; set; }
        public DateTime startDateAndTime { get; set; }
        public DateTime endDateAndTime { get; set; }
        public StudentDto student { get; set; }
        public staffDto staff { get; set; }
    }
}