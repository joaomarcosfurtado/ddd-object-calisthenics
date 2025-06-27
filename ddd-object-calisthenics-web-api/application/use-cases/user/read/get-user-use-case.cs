using ddd_object_calisthenics_web_api.application.dtos.responses;
using ddd_object_calisthenics_web_api.domain.entities;
using ddd_object_calisthenics_web_api.domain.repositories;

namespace ddd_object_calisthenics_web_api.application.use_cases.user.read;

public class GetUserUseCase(IUserRepository repository) : IGetUserUseCase
{
    private readonly IUserRepository _repository = repository;
    public async Task<GetUserResponse?> Execute(string id)
    {
        var user = await _repository.GetById(id);
        if (user == null)
            return null;

        return new GetUserResponse
        {
            Id = user.Id,
            Email = user.Email
        };
    }
}
