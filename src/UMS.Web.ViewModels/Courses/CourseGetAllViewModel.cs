namespace UMS.Web.ViewModels.Courses
{
    using System;
    using System.Collections.Generic;

    using Additional;

    public class CourseGetAllViewModel : PagingViewModel
    {
        public IEnumerable<CourseListingViewModel> Courses { get; set; }
    }
}
