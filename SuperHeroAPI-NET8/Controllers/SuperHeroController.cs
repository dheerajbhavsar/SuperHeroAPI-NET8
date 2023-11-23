using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI_NET8.Models;
using SuperHeroAPI_NET8.Repositories;

namespace SuperHeroAPI_NET8.Controllers;

public class SuperHeroController(IRepository repository) : ApiController
{
    private readonly IRepository _repo = repository ?? throw new ArgumentNullException(nameof(repository));

    [HttpGet("{id}")]
    public async Task<ActionResult<SuperHero>> Get(int id)
    {
        var superHero = await _repo.GetById(id);

        if(superHero is not null)
            return superHero;

        return NotFound();
    }

    [HttpGet]
    public async Task<IEnumerable<SuperHero>> GetAll()
    {
        return await _repo.GetAll();
    }
}
