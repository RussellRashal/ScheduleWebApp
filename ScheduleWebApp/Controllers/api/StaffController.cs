using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ScheduleWebApp.Models;
using ScheduleWebApp.Dtos;
using AutoMapper;

namespace ScheduleWebApp.Controllers.api
{
    public class StaffController : ApiController
    {
        private ApplicationDbContext _context;

        public StaffController()
        {
            _context = new ApplicationDbContext();
        }


        //GET staff name
        public IHttpActionResult GetStaff()
        {
            var StaffDtos = _context.staff                
                .ToList()
                .Select(Mapper.Map<Staff, staffDto>);


            return Json(StaffDtos);


        }
    }
}
