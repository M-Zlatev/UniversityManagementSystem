namespace UMS.Web.ViewModels.Forum.Posts
{
    using System;

    using Ganss.XSS;

    using Data.Models.Forum;
    using Services.Mapping.Contracts;

    public class PostCommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserUserName { get; set; }
    }
}
