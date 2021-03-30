namespace UMS.Services.Mapping.Contracts
{
    using AutoMapper;

    public interface IMapExplicitly
    {
        public void CreateMappings(IProfileExpression profile);
    }
}
