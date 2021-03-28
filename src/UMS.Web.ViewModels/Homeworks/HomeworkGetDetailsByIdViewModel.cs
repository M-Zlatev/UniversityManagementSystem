namespace UMS.Web.ViewModels.Homeworks
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using Common.Mapping;
    using Data.Common.Enumerations;
    using Data.Models.Homeworks;

    public class HomeworkGetDetailsByIdViewModel : IMapFrom<Homework>, IMapExplicitly
    {
        public string Content { get; set; }

        public HomeworkType HomeworkType { get; set; }

        public DateTime AssignmentTime { get; set; }

        public DateTime OpenForSubmissionTime { get; set; }

        public string DoneByStudent { get; set; }

        public void RegisterMappings(IProfileExpression profile)
        {
            profile
                .CreateMap<Homework, HomeworkGetDetailsByIdViewModel>()
                .ForMember(h => h.DoneByStudent, cfg => cfg.MapFrom(h => h.Student.FirstName));
        }
    }
}
