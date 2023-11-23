using SuperHeroAPI_NET8.Models;

namespace SuperHeroAPI_NET8.Repositories;

public interface IRepository
{
    Task<IEnumerable<SuperHero>> GetAll();
    Task<SuperHero> GetById(int id);
    void DeleteById(int id);
    void UpdateById(int id, SuperHero entity);
}
