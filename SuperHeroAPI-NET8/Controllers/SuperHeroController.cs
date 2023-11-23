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

        if (superHero is not null)
            return superHero;

        return NotFound();
    }

    [HttpGet]
    public async Task<IEnumerable<SuperHero>> GetAll()
    {
        return await _repo.GetAll();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        if(!await _repo.Exist(id))
            return BadRequest();

        await _repo.DeleteById(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, SuperHero entity)
    {
        if(!await _repo.Exist(id))
            return BadRequest();
        await _repo.UpdateById(id, entity);
        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult> Post(SuperHero entity)
    {
        var superHero = await _repo.Create(entity);
        return CreatedAtAction("Get", new { id = superHero.Id }, superHero);
    }
}
