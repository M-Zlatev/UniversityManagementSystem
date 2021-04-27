namespace UMS.Data.Models.Forum
{
    using System.ComponentModel.DataAnnotations;

    using Common.Enumerations;
    using Common.Implementations;
    using UserDefinedPrincipal;

    public class Vote : BaseAuditInfoModel
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public VoteType Type { get; set; }
    }
}
