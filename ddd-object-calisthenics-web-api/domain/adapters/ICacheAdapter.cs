namespace ddd_object_calisthenics_web_api.domain.adapters;

public interface ICacheAdapter
{
    Task CacheSomething(string item);
}
