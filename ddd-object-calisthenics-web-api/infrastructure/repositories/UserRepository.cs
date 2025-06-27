using ddd_object_calisthenics_web_api.domain.entities;
using ddd_object_calisthenics_web_api.domain.repositories;

namespace ddd_object_calisthenics_web_api.infrastructure.repositories;

public class UserRepository : IUserRepository
{
    public async Task Add(User user)
    {
        Console.WriteLine("Usuario adicionado", user.Email);
    }
    
    public Task<User> GetById(string id)
    {
        Console.WriteLine("Usuario recuperado");
        throw new NotImplementedException();
    }
}
