namespace UMS.Web.ViewModels.Forum.Posts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreatePostInputForm
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public int UserId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Categories { get; set; }

        public bool RedirectFromCategory { get; set; }
    }
}
