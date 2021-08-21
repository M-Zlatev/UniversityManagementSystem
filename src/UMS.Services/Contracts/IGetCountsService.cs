namespace UMS.Services.Contracts
{
    using Contracts.ServicesLifetimeContracts;
    using Models;

    public interface IGetCountsService : ITransientService
    {
        public CountsDto GetUniversityDivisionsCount();
    }
}
