using SuperHeroAPI_NET8.Data;
using SuperHeroAPI_NET8.Models;
using Microsoft.EntityFrameworkCore;

namespace SuperHeroAPI_NET8.Repositories;

public class Repository(DataContext dbContext) : IRepository
{
    private readonly DataContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public void DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<SuperHero>> GetAll()
    {
        return await _dbContext.SuperHeroes.ToListAsync();
    }

    public async Task<SuperHero> GetById(int id)
    {
        return await _dbContext.SuperHeroes.FirstOrDefaultAsync(x => x.Id == id);
    }

    public void UpdateById(int id, SuperHero entity)
    {
        throw new NotImplementedException();
    }
}
