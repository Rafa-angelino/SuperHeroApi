using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Models;
using SuperHeroApi.Services.SuperHeroService;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _service;
        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _service= superHeroService;
        }


        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
           
            return await _service.GetAllHeroes();
        }

        [HttpGet("{id}")]
        
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var result = await _service.GetSingleHero(id);
            if (result is null) return NotFound("Não foi possível localizar o héroi com o ID informado");
            return Ok(result);  
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            var result = await _service.AddHero(hero);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request, int id)
        {
            var result = await _service.UpdateHero(request, id);
            if (result is null) return NotFound("Herói não encontrado");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var result = await _service.DeleteHero(id);
            if (result is null) return NotFound("Herói not found");
            return Ok(result);
        }

    }
}
