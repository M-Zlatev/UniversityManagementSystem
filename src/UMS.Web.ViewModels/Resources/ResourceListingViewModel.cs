﻿namespace UMS.Web.ViewModels.Resources
{
    using UMS.Data.Common.Enumerations;

    using UMS.Common.Mapping;
    using UMS.Data.Models;

    public class ResourceListingViewModel : IMapFrom<Resource>
    {
        public string Name { get; set; }

        public ResourceType ResourceType { get; set; }
    }
}