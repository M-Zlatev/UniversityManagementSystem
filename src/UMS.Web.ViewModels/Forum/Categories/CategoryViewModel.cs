﻿namespace UMS.Web.ViewModels.Forum.Categories
{
    using System.Collections.Generic;

    using Additional;
    using Data.Models.Forum;
    using Services.Mapping.Contracts;

    public class CategoryViewModel : PagingViewModel, IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<PostInCategoryViewModel> ForumPosts { get; set; }
    }
}
