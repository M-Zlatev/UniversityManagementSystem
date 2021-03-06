﻿namespace UMS.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Data.Models.ResourcesParametersModels;
    using ServicesLifetimeContracts;
    using UMS.Data.Common.Enumerations;

    public interface IResourcesService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int id, int resourcesPerPage);

        public T GetDetailsById<T>(int id);

        Task<bool> Exists(int id);

        int GetCount();

        Task<int> CreateAsync(ResourceCreateParametersModel createParametersModel);

        Task<bool> EditAsync(int id, ResourceEditParametersModel editParametersModel);

        Task<bool> DeleteAsync(int id);
    }
}
