namespace UMS.Web.ViewModels.Homeworks
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using Data.Common.Enumerations;
    using Data.Models.Homeworks;
    using Services.Mapping.Contracts;

    public class HomeworkGetDetailsByIdViewModel : IMapFrom<Homework>, IMapExplicitly
    {
        public string Content { get; set; }

        public HomeworkType HomeworkType { get; set; }

        public DateTime AssignmentTime { get; set; }

        public DateTime OpenForSubmissionTime { get; set; }

        public string DoneByStudent { get; set; }

        public void CreateMappings(IProfileExpression profile)
        {
            profile
                .CreateMap<Homework, HomeworkGetDetailsByIdViewModel>()
                .ForMember(h => h.DoneByStudent, cfg => cfg.MapFrom(h => h.AddedByUser.FirstName));
        }
    }
}
