namespace UMS.Services.Contracts
{
    using System.Collections.Generic;

    using ServicesLifetimeContracts;

    public interface ICategoriesService : ITransientService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        T GetByName<T>(string name);
    }
}
