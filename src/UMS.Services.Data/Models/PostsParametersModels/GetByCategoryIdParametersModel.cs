namespace UMS.Services.Data.Models.PostsParametersModels
{
    public class GetByCategoryIdParametersModel
    {
        public int Skip { get; set; } = 0;

        public int? Take { get; set; } = null;

        public int CategoryId { get; set; }
    }
}
