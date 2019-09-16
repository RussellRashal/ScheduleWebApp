using ScheduleWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ScheduleWebApp.Dtos;
using AutoMapper;
using System.Data.Entity;



namespace ScheduleWebApp.Controllers.api
{
    public class StudentController : ApiController
    {
        private ApplicationDbContext _context;

        public StudentController()
        {
            _context = new ApplicationDbContext();
        }

        //Students
        //GET /api/Main should return list of students
        public IEnumerable<StudentDto> GetStudent()
        {
            return _context.Student.ToList().Select
             (Mapper.Map<Student, StudentDto>);
            /*var StudentDto = _context.Student
                .Include(c => c.)
                .ToList().Select(Mapper.Map<Student, StudentDto>);

            return Ok(StudentDto);
            */
        }

        //POST /api/main
        //POSTing a student
        [HttpPost] //This is needed as you're creating a resource
        public IHttpActionResult CreateStudent(StudentDto StudentDto)
        {
            //if what the user has enetered is not valid
            if (!ModelState.IsValid)
                return BadRequest();

            /*To allow the user to add a new student using this mapper method below. the 
            "ScheduleDateAndTimeDto" object is passed to the mapper method to be converted from Dto to domain object
            This then gets saved in a variable called "ScheduleDateAndTime"
            */
            var Student = Mapper.Map<StudentDto, Student>(StudentDto);

            //the variable "ScheduleDateAndTime" gets added to the database and then saved 
            _context.Student.Add(Student);
            _context.SaveChanges();

            //an Id is generated in the database and needs to be returned to the user by converting it into the dto object
            StudentDto.id = Student.id;

            //dto object is returned to the user
            return Created(new Uri(Request.RequestUri + "/" + Student.id), StudentDto);
        }

        //PUT /api/main/1  to update a student
        [HttpPut]
        public void UpdateStudent(int id, StudentDto StudentDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var studentInDb = _context.Student.SingleOrDefault(c => c.id == id);

            if (studentInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            /*Both the "ScheduleDateAndTimeDto" and "scheduleDateAndTimeInDb" gets passed into the mapper method
            This automatically maps the database object to the dto object properties.  it says i want to equal the 
            properties inputed by the user to the database properties. 
            */
            Mapper.Map<StudentDto, Student>(StudentDto, studentInDb);

            _context.SaveChanges();
        }

        //Delete /api/main/1
        [HttpDelete]
        public void DeleteStudent(int id)
        {
            //check to see if the schedule exists or not
            var studentInDb = _context.Student.SingleOrDefault(c => c.id == id);

            if (studentInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Student.Remove(studentInDb);
            _context.SaveChanges();
        }
    }
}

