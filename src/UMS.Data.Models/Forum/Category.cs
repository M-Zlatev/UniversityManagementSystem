namespace UMS.Data.Models.Forum
{
    using System.Collections.Generic;

    using Common.Implementations;

    public class Category : BaseDeletableModel
    {
        public Category()
        {
            this.Posts = new HashSet<Post>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
