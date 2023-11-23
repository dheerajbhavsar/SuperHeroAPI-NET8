using SuperHeroAPI_NET8.Models;

namespace SuperHeroAPI_NET8.Repositories;

public interface IRepository
{
    Task<SuperHero> Create(SuperHero entity);
    Task<IEnumerable<SuperHero>> GetAll();
    Task<SuperHero> GetById(int id);
    Task DeleteById(int id);
    Task UpdateById(int id, SuperHero entity);
    Task<bool> Exist(int id);
}
