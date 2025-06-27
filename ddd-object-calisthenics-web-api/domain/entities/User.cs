using ddd_object_calisthenics_web_api.domain.primitives;

namespace ddd_object_calisthenics_web_api.domain.entities;

public class User(Email email)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Email Email { get; private set; } = email;
}