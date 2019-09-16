using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScheduleWebApp.Models;

namespace ScheduleWebApp.Models
{
    public class home
    {
        public ScheduleDateAndTime ScheduleDateAndTime { get; set; }
        public Student student { get; set; }
        public Staff staff { get; set; }
    }
}
