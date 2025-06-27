using ddd_object_calisthenics_web_api.application.dtos;
using ddd_object_calisthenics_web_api.application.dtos.responses;

namespace ddd_object_calisthenics_web_api.application.use_cases.user.create;

public interface ICreateUserUseCase
{
    Task<CreateUserResponse> Execute(CreateUserRequest request);
}
