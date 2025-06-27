using ddd_object_calisthenics_web_api.application.use_cases;
using ddd_object_calisthenics_web_api.application.use_cases.user.create;

namespace ddd_object_calisthenics_web_api.application.dependency_injection;

public static class Extension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
    }
}
