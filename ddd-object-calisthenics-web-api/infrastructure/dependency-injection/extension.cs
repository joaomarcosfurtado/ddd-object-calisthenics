using ddd_object_calisthenics_web_api.domain.repositories;
using ddd_object_calisthenics_web_api.infrastructure.repositories;

namespace ddd_object_calisthenics_web_api.infrastructure.dependency_injection;

public static class Extension
{
    public static void AddInfra(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
