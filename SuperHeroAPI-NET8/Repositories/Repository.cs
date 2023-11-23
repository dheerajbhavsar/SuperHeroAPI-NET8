using SuperHeroAPI_NET8.Data;
using SuperHeroAPI_NET8.Models;
using Microsoft.EntityFrameworkCore;

namespace SuperHeroAPI_NET8.Repositories;

public class Repository(DataContext dbContext) : IRepository
{
    private readonly DataContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    public async Task<SuperHero> Create(SuperHero entity)
    {
        var superHero = _dbContext.Add(entity);
        await _dbContext.SaveChangesAsync();
        return superHero.Entity;
    }

    public async Task DeleteById(int id)
    {
        var superHero = await _dbContext.SuperHeroes.FindAsync(id);
        if (superHero != null)
        {
            _dbContext.SuperHeroes.Remove(superHero);
        }
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> Exist(int id)
    {
        var superHero = await _dbContext.SuperHeroes.FindAsync(id);
        return superHero != null;
    }

    public async Task<IEnumerable<SuperHero>> GetAll()
    {
        return await _dbContext.SuperHeroes
            .AsNoTracking().ToListAsync();
    }

    public async Task<SuperHero> GetById(int id)
    {
        return await _dbContext.SuperHeroes
            !.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateById(int id, SuperHero entity)
    {
        var userToUpdate = await _dbContext.SuperHeroes.FindAsync(id);

        if (userToUpdate != null)
        {
            userToUpdate.FirstName = entity.FirstName;
            userToUpdate.LastName = entity.LastName;
            userToUpdate.Place = entity.Place;
            _dbContext.Update(userToUpdate);
            await _dbContext.SaveChangesAsync(true);
        }
    }
}
