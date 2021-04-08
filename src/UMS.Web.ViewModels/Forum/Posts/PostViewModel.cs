namespace UMS.Web.ViewModels.Forum.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using Ganss.XSS;

    using Data.Models.Forum;
    using Services.Mapping.Contracts;

    public class PostViewModel : IMapFrom<Post>, IMapTo<Post>, IMapExplicitly
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserUserName { get; set; }

        public int VotesCount { get; set; }

        public IEnumerable<PostCommentViewModel> Comments { get; set; }

        public void CreateMappings(IProfileExpression profile)
        {
            profile.CreateMap<Post, PostViewModel>()
                .ForMember(x => x.VotesCount, cfg =>
                {
                    cfg.MapFrom(p => p.Votes.Sum(v => (int)v.Type));
                });
        }
    }
}
