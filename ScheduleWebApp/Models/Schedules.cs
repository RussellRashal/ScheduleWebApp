using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScheduleWebApp.Models
{
    public class Schedules
    {

        public int id { get; set; }

        public Boolean monday { get; set; }
        public Boolean tuesday { get; set; }
        public Boolean wednesday { get; set; }
        public Boolean thursday { get; set; }
        public Boolean friday { get; set; }

        public Driver Driver { get; set; }

        public int DriverId { get; set; }

        public Routes Routes { get; set; }
        public int RoutesId { get; set; }


    }
}