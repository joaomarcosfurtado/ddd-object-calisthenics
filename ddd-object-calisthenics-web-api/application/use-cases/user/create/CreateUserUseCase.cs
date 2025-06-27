using ddd_object_calisthenics_web_api.application.dtos;
using ddd_object_calisthenics_web_api.application.dtos.responses;
using ddd_object_calisthenics_web_api.application.use_cases.user.create;
using ddd_object_calisthenics_web_api.domain.entities;
using ddd_object_calisthenics_web_api.domain.primitives;
using ddd_object_calisthenics_web_api.domain.repositories;

namespace ddd_object_calisthenics_web_api.application.use_cases;

public class CreateUserUseCase(IUserRepository repository) : ICreateUserUseCase
{
    private readonly IUserRepository _repository = repository;

    public async Task<CreateUserResponse> Execute(CreateUserRequest request)
    {
        var email = Email.Create(request.Email);
        var user = new User(email);

        await _repository.Add(user);
        return new CreateUserResponse() {Id = user.Id};
    }
}