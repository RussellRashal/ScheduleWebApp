
using System;
using ScheduleWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScheduleWebApp.Dtos;
using AutoMapper;
using System.Data.Entity;
using System.Web.Http;
using System.Net;


namespace ScheduleWebApp.Controllers.api
{
    public class ScheduleController : ApiController
    {


        private ApplicationDbContext _context;

        public ScheduleController()
        {


            _context = new ApplicationDbContext();


        }
        public IHttpActionResult GetSchedule()
        {


            var SchedulesDto = _context.Schedules
                .Include(c => c.Driver)
                .Include(c => c.Routes)
                .ToList()
                .Select(Mapper.Map<Schedules, ScheduleDto>);

               return Json (SchedulesDto);
        }


        //post the api raw data to the database
        [HttpPost]
        public IHttpActionResult CreateSchedule(ScheduleDto SchedulesDto)
        {
            //if what the user has enetered is not valid
            if (!ModelState.IsValid)
                return BadRequest();

            /*To allow the user to add a new dataAndTime using this mapper method below. the 
            "ScheduleDateAndTimeDto" object is passed to the mapper method to be converted from Dto to domain object
            This then gets saved in a variable called "ScheduleDateAndTime"
            */
            var Schedule = Mapper.Map<ScheduleDto, Schedules>(SchedulesDto);

            //the variable "ScheduleDateAndTime" gets added to the database and then saved 
            _context.Schedules.Add(Schedule);
            _context.SaveChanges();

            //an Id is generated in the database and needs to be returned to the user by converting it into the dto object
            SchedulesDto.id = Schedule.id;

            //dto object is returned to the user
            return Created(new Uri(Request.RequestUri + "/" + Schedule.id), SchedulesDto);
        }












    }
}