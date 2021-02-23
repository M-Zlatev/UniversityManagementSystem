namespace UMS.Common.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using AutoMapper;
    using AutoMapper.Configuration;

    public static class AutoMapperConfig
    {
        private static bool initialized;

        public static IMapper MapperInstance { get; set; }

        public static IMapperConfigurationExpression ConfigurationExpression { get; set; }

        public static bool Initialized
        {
            get => initialized;
            set
            {
                Initialized = initialized;
            }
        }

        public static void RegisterMappings(params Assembly[] assemblies)
        {
            if (initialized)
            {
                return;
            }

            initialized = true;

            var config = new MapperConfigurationExpression();
            config.CreateProfile(
                "ReflectionProfile",
                configuration =>
                {
                    var modelRegistrations = AppDomain
                      .CurrentDomain
                      .GetAssemblies()
                      .Where(a => a.GetName().Name.StartsWith("UMS."))
                      .SelectMany(a => a.GetExportedTypes())
                      .Where(t => t.IsClass && !t.IsAbstract)
                      .Select(t => new
                      {
                          Type = t,
                          MapFrom = GetMappingModel(t, typeof(IMapFrom<>)),
                          MapTo = GetMappingModel(t, typeof(IMapTo<>)),
                          ExplicitMap = t.GetInterfaces()
                              .Where(i => i == typeof(IMapExplicitly))
                              .Select(i => (IMapExplicitly)Activator.CreateInstance(t))
                              .FirstOrDefault(),
                      });

                    foreach (var modelRegistration in modelRegistrations)
                    {
                        if (modelRegistration.MapFrom != null)
                        {
                            configuration.CreateMap(modelRegistration.MapFrom, modelRegistration.Type);
                        }

                        if (modelRegistration.MapTo != null)
                        {
                            configuration.CreateMap(modelRegistration.Type, modelRegistration.MapTo);
                        }

                        modelRegistration.ExplicitMap?.RegisterMappings(configuration);
                    }
                });
            MapperInstance = new Mapper(new MapperConfiguration(config));
        }

        private static Type GetMappingModel(Type type, Type mappingInterface)
        => type.GetInterfaces()
            .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == mappingInterface)
            ?.GetGenericArguments()
            .First();
    }
}
