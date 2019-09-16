using ScheduleWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScheduleWebApp.Dtos;
using AutoMapper;
using System.Data.Entity;
using System.Web.Http;
using System.Net;



//use this link to get raw data http://localhost:58371/api/Driver

namespace ScheduleWebApp.Controllers.api
{

    public class DriverController : ApiController
    {


        private ApplicationDbContext _context;



        public DriverController()
        {
            _context = new ApplicationDbContext();


        }

    
        public IEnumerable<DriverDto> GetDriver()
        {
            return _context.Drivers.ToList().Select
                (Mapper.Map<Driver, DriverDto>);
          

        }

        [HttpPost] //This is needed as you're creating a resource
        public IHttpActionResult CreateDriver(DriverDto driverDto)
        {
            //if what the user has enetered is not valid
            if (!ModelState.IsValid)
                return BadRequest();

            /*To allow the user to add a new student using this mapper method below. the 
            "ScheduleDateAndTimeDto" object is passed to the mapper method to be converted from Dto to domain object
            This then gets saved in a variable called "ScheduleDateAndTime"
            */
            var Driver = Mapper.Map<DriverDto, Driver>(driverDto);

            //the variable "ScheduleDateAndTime" gets added to the database and then saved 
            _context.Drivers.Add(Driver);
            _context.SaveChanges();

            //an Id is generated in the database and needs to be returned to the user by converting it into the dto object
            driverDto.id = Driver.id;

            //dto object is returned to the user
            return Created(new Uri(Request.RequestUri + "/" + Driver.id), driverDto);
        }












        // This reffers back to the Identity models which I've covered 
        //Thats why I made a new migration called new mistakes 
        //  .ToList()
        // .Select(Mapper.Map<Driver, DriverDto>);


        //  return Json(DriverDtos);
    }

    //post data to the driver list





}
