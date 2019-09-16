using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ScheduleWebApp.Dtos;
using ScheduleWebApp.Models;

namespace ScheduleWebApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {            
            Mapper.CreateMap<ScheduleDateAndTime, ScheduleDateAndTimeDto>();
            Mapper.CreateMap<ScheduleDateAndTimeDto, ScheduleDateAndTime>();

            Mapper.CreateMap<Student, StudentDto>();
            Mapper.CreateMap<StudentDto, Student>();

            Mapper.CreateMap<Staff, staffDto>();
            Mapper.CreateMap<staffDto, Staff>();

            Mapper.CreateMap<Driver, DriverDto>();
            Mapper.CreateMap<DriverDto, Driver>();


            Mapper.CreateMap<Routes, RoutesDto>();
            Mapper.CreateMap<RoutesDto, Routes>();

            Mapper.CreateMap<Schedules, ScheduleDto>();
            Mapper.CreateMap<ScheduleDto, Schedules>();




        }
    }   
}