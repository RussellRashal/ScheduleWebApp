using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScheduleWebApp.Models;
using System.ComponentModel.DataAnnotations;
using ScheduleWebApp.Dtos;



namespace ScheduleWebApp.Dtos
{
    public class ScheduleDto
    {

        public int id { get; set; }

        public Boolean monday { get; set; }
        public Boolean tuesday { get; set; }
        public Boolean wednesday { get; set; }
        public Boolean thursday { get; set; }
        public Boolean friday { get; set; }


        public DriverDto Driver { get; set; }

        public RoutesDto Routes { get; set; }




    }
}