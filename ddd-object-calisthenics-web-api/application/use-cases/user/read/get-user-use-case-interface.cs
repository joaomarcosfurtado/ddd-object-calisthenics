using ddd_object_calisthenics_web_api.application.dtos.responses;

namespace ddd_object_calisthenics_web_api.application.use_cases.user.read;

public interface IGetUserUseCase
{
    Task<GetUserResponse?> Execute(string id);
}
