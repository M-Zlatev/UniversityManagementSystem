﻿namespace UMS.Web.ViewModels.Homeworks
{
    using System.Collections.Generic;

    using Additional;

    public class HomeworkGetAllViewModel : PagingViewModel
    {
        public IEnumerable<HomeworkListingViewModel> Homeworks { get; set; }
    }
}
