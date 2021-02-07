namespace UMS.Web.ViewModels.Courses
{
    using System;
    using System.Collections.Generic;

    public class CourseGetAllViewModel : PagingViewModel
    {
        public IEnumerable<CourseListingViewModel> Courses { get; set; }
    }
}
