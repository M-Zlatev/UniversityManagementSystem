namespace UMS.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Data.Models.PostsParametersModels;
    using ServicesLifetimeContracts;

    public interface IPostsService : ITransientService
    {
        T GetById<T>(int id);

        IEnumerable<T> GetByCategoryId<T>(int categoryId);

        int GetCountByCategoryId(int categoryId);

        Task<int> CreateAsync(PostCreateParametersModel createParametersModel);
    }
}
