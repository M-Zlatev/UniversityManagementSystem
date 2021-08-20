namespace UMS.Services.Contracts
{
    using System.Collections.Generic;

    using Dtos;
    using Contracts.ServicesLifetimeContracts;

    public interface IUniversityDivisionsCountService : ITransientService
    {
        public UniversityDivisionsCount GetUniversityDivisionsCount();
    }
}
