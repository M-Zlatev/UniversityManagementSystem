﻿namespace UMS.Web.ViewModels
{
    using UMS.Data.Models;
    using UMS.Services.Mapping;

    public class FacultyListingViewModel : IMapFrom<Faculty>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
