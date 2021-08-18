namespace UMS.Services.Contracts
{
    using System.Collections.Generic;

    using Dtos;
    using ServicesLifetimeContracts;

    public interface IUniversityDivisionsCountService : ITransientService
    {
        public UniversityDivisionsCount GetUniversityDivisionsCount();
    }
}
