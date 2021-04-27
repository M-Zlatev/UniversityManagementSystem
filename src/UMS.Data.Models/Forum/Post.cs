namespace UMS.Data.Models.Forum
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Implementations;
    using UserDefinedPrincipal;

    public class Post : BaseDeletableModel
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
            this.Votes = new HashSet<Vote>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
