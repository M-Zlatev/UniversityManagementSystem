﻿namespace UMS.Web.ViewModels.Courses
{
    using System;
    using System.Linq;

    using AutoMapper;

    using Common.Mapping;
    using Data.Models;

    public class CourseDetailsViewModel : IMapFrom<Course>, IMapExplicitly
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public string BelongsToMajor { get; set; }

        public void RegisterMappings(IProfileExpression profile)
        {
            profile
               .CreateMap<Course, CourseDetailsViewModel>()
               .ForMember(c => c.BelongsToMajor, cfg => cfg.MapFrom(
                   c => c.Majors
                            .Select(cm => cm.Major.Name)
                            .FirstOrDefault()));
        }
    }
}