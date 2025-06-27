using ddd_object_calisthenics_web_api.domain.entities;

namespace ddd_object_calisthenics_web_api.domain.repositories;

public interface IUserRepository
{
    Task<User> GetById(string id);
    Task Add(User user);
}
