using ScheduleWebApp.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;  
using System.Web.Http;
using ScheduleWebApp.Dtos;
using AutoMapper;


namespace ScheduleWebApp.Controllers.api
{
    public class ScheduleDateAndTimeController : ApiController
    {
        private ApplicationDbContext _context;

        public ScheduleDateAndTimeController()
        {
            _context = new ApplicationDbContext();
        }

        //ScheduleDateAndTime
        //GET /api/Main should return list of ScheduleDateAndTime
       public IHttpActionResult GetScheduleDateAndTime()
        {

           
            var ScheduleDateAndTimeDtos = _context.ScheduleDateAndTime
                .Include(c => c.student)
                .Include(c => c.staff)
                .ToList()
                .Select(Mapper.Map<ScheduleDateAndTime, ScheduleDateAndTimeDto>);

           
            return Json(ScheduleDateAndTimeDtos);
        }

        //POST /api/main                
        //POSTing a timeAndDate
        [HttpPost] //This is needed as you're creating a resource
        public IHttpActionResult CreateScheduleDateAndTime(ScheduleDateAndTimeDto ScheduleDateAndTimeDto)
        {
            //if what the user has enetered is not valid
            if (!ModelState.IsValid)
                return BadRequest();

            /*To allow the user to add a new dataAndTime using this mapper method below. the 
            "ScheduleDateAndTimeDto" object is passed to the mapper method to be converted from Dto to domain object
            This then gets saved in a variable called "ScheduleDateAndTime"
            */
            var ScheduleDateAndTime = Mapper.Map<ScheduleDateAndTimeDto, ScheduleDateAndTime>(ScheduleDateAndTimeDto);

            //the variable "ScheduleDateAndTime" gets added to the database and then saved 
            _context.ScheduleDateAndTime.Add(ScheduleDateAndTime);
            _context.SaveChanges();

            //an Id is generated in the database and needs to be returned to the user by converting it into the dto object
            ScheduleDateAndTimeDto.id = ScheduleDateAndTime.id;

            //dto object is returned to the user
            return Created(new Uri(Request.RequestUri + "/" + ScheduleDateAndTime.id), ScheduleDateAndTimeDto);
        }

        //PUT /api/main/1  to update a date and time
        [HttpPut]
        public void UpdateScheduleDateAndTime(int id, ScheduleDateAndTimeDto ScheduleDateAndTimeDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var scheduleDateAndTimeInDb = _context.ScheduleDateAndTime.SingleOrDefault(c => c.id == id);

            if (scheduleDateAndTimeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            /*Both the "ScheduleDateAndTimeDto" and "scheduleDateAndTimeInDb" gets passed into the mapper method
            This automatically maps the database object to the dto object properties.  it says i want to equal the 
            properties inputed by the user to the database properties. 
            */
            Mapper.Map<ScheduleDateAndTimeDto, ScheduleDateAndTime>(ScheduleDateAndTimeDto, scheduleDateAndTimeInDb);



            _context.SaveChanges();
        }

        //Delete /api/main/1
        [HttpDelete]
        public void DeletescheduleDateAndTime(int id)
        {
            //check to see if the schedule exists or not
            var scheduleDateAndTimeInDb = _context.ScheduleDateAndTime.SingleOrDefault(c => c.id == id);

            if (scheduleDateAndTimeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.ScheduleDateAndTime.Remove(scheduleDateAndTimeInDb);
            _context.SaveChanges();
        }
    }
}
