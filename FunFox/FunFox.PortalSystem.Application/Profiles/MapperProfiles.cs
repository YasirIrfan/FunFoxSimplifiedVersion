using AutoMapper;

namespace FunFox.PortalSystem.Application.Profiles;

public class MapperProfiles
{
    public static IEnumerable<Profile> GetAssemblyProfiles()
    {
        return new Profile[]
        {
            new DefaultAutoMapperProfile(),
            new PlantAutoMapperProfile(),
            new ClassAutoMapperProfile()
        };
    }
}