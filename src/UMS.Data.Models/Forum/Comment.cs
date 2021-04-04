namespace UMS.Data.Models.Forum
{
    using Common.Implementations;
    using UserDefinedPrincipal;

    public class Comment : BaseDeletableModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public int? ParentId { get; set; }

        public virtual Comment Parent { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
