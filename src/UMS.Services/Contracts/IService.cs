namespace UMS.Services.Contracts
{
    /// <summary>
    /// Blank interface that helps automatic registration of services of that unit in Startup.
    ///     In UMS.Web.Infrastructure --- Extensions --- ServiceCollectionExtensions (the extension used in Startup) we perform        logic of finding Services and their corresponding interfaces and add transient / singleton / scoped services. This         interface facilitate finding the Services and their corresponding interfaces using Reflection (through Assembly ---        ExportedTypes and select whatever is necessary) and perform add services.
    ///     DO NOT DELETE THIS INTERFACE !!! The automatic registration of services and their corresponding interfaces in Startup      will cease to work and thus far overall website malfunction will be caused.
    /// </summary>
    public interface IService
    {
    }
}
