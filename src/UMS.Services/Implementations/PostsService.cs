namespace UMS.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Contracts;
    using Data.Models.PostsParametersModels;
    using Mapping.Infrastructure;
    using UMS.Data.Models.Forum;
    using UMS.Data.Repositories.Contracts;

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

        public IEnumerable<T> GetByCategoryId<T>(GetByCategoryIdParametersModel model)
        {
            var query = this.postsRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .Where(x => x.CategoryId == model.CategoryId)
                .Skip(model.Skip);

            if (model.Take.HasValue)
            {
                query = query.Take(model.Take.Value);
            }

            return query.To<T>().ToList();
        }

        public int GetCountByCategoryId(int categoryId)
            => this.postsRepository.All().Count(x => x.CategoryId == categoryId);

        public async Task<int> CreateAsync(PostCreateParametersModel model)
        {
            var post = new Post
            {
                Title = model.Title,
                Content = model.Content,
                CategoryId = model.CategoryId,
                UserId = model.UserId,
            };

            await this.postsRepository.AddAsync(post);
            await this.postsRepository.SaveChangesAsync();

            return post.Id;
        }
    }
}
