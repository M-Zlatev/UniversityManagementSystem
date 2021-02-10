﻿namespace UMS.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UMS.Data.Common.Enumerations;
    using Services.Data.Models.StudentsParametersModels;

    public interface IStudentsService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int id, int studentsPerPage);

        public T GetDetailsById<T>(int id);

        Task<bool> Exists(int id);

        int GetCount();

        Task<int> Create(StudentCreateParametersModel createParametersModel);

        Task<bool> Edit(int id, StudentEditParametersModel editParametersModel);

        Task<bool> Delete(int id);
    }
}
