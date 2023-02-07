

using Microsoft.AspNetCore.Mvc;

namespace SuperHeroApi.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAllHeroes();
        Task<SuperHero?> GetSingleHero(int id);
        Task<SuperHero> AddHero (SuperHero hero);
        Task<SuperHero?> UpdateHero(SuperHero request, int id);
        Task<SuperHero?> DeleteHero(int id);
    }
}
