namespace UMS.Web.Infrastructure.Extensions
{
    using AutoMapper;

    using Services.Mapping;

    public static class CustomAutoMapperExtension
    {
        public static IMapper Mapper => CustomAutoMapper.MapperInstance;
    }
}
