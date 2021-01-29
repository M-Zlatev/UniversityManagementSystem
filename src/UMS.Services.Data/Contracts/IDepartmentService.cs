﻿namespace UMS.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Models.Departments;
    using UMS.Data.Models;

    public interface IDepartmentService
    {
        public Task<IEnumerable<DepartmentListingServiceModel>> All(int page);

        public Task<DepartmentDetailsServiceModel> Details(int id);

        Task<bool> Exists(int id);

        Task<int> Create(string name, string description, string email, string phoneNumber, string fax, string belongsToFaculty, string userId);

        Task<bool> Edit(int id, string name, string description, string email, string phoneNumber, string fax);

        Task<bool> Delete(int id);
    }
}
