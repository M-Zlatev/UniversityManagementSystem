namespace UMS.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Services.Contracts.ServicesLifetimeContracts;
    using Web.ViewModels.Forum.Posts;

    public interface IPostsService : ITransientService
    {
        T GetById<T>(int id);

        IEnumerable<T> GetByCategoryId<T>(int categoryId);

        int GetCountByCategoryId(int categoryId);

        Task<int> CreateAsync(CreatePostInputForm createForm);
    }
}
