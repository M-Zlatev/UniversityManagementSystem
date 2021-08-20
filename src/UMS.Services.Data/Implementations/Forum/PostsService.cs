namespace UMS.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Contracts;
    using Mapping.Infrastructure;
    using UMS.Data.Models.Forum;
    using UMS.Data.Repositories.Contracts;
    using UMS.Web.ViewModels.Forum.Posts;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postsRepository;

        public PostsService(IDeletableEntityRepository<Post> postsRepository)
            => this.postsRepository = postsRepository;

        public T GetById<T>(int id)
            => this.postsRepository.All()
                    .Where(x => x.Id == id)
                    .To<T>()
                    .FirstOrDefault();

        public IEnumerable<T> GetByCategoryId<T>(int categoryId)
        {
            var query = this.postsRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .Where(x => x.CategoryId == categoryId);

            return query.To<T>().ToList();
        }

        public int GetCountByCategoryId(int categoryId)
            => this.postsRepository.All().Count(x => x.CategoryId == categoryId);

        public async Task<int> CreateAsync(CreatePostInputForm createForm)
        {
            var post = new Post
            {
                Title = createForm.Title,
                Content = createForm.Content,
                CategoryId = createForm.CategoryId,
                UserId = createForm.UserId,
            };

            await this.postsRepository.AddAsync(post);
            await this.postsRepository.SaveChangesAsync();

            return post.Id;
        }
    }
}
