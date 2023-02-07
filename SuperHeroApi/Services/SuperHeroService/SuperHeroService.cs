using Microsoft.AspNetCore.Mvc;

namespace SuperHeroApi.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext _dbContext;
        //private static List<SuperHero> superHeroes = new List<SuperHero>
        //    {
        //        new SuperHero
        //        {
        //            Id= 1,
        //            Name="SpiderMan",
        //            FirstName="Peter",
        //            LastName="Parker",
        //            Place ="New York"
        //        },
        //        new SuperHero
        //        {
        //            Id=2,
        //            Name="IronMan",
        //            FirstName="Tony",
        //            LastName="Stark",
        //            Place="New York"
        //        }
        //    };

        public SuperHeroService(DataContext dbContext)
        {
            _dbContext= dbContext;
        }
        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes = await _dbContext.SuperHeroes.ToListAsync();
            return heroes;
        }

        public async Task<SuperHero?> GetSingleHero(int id)
        {
            var hero = await _dbContext.SuperHeroes.FindAsync(id); 
            if (hero is null) return null;
            return hero;
        }
        public async Task<SuperHero> AddHero(SuperHero hero)
        {
            var addHero = await _dbContext.SuperHeroes.AddAsync(hero);
            await _dbContext.SaveChangesAsync();
            return hero;

        }

        public async Task<SuperHero?> DeleteHero(int id)
        {
            var hero = await _dbContext.SuperHeroes.FindAsync(id);
            if (hero is null) return null;
            _dbContext.Remove(hero);
            await _dbContext.SaveChangesAsync(); 
            return hero;
        }

        

        public async Task<SuperHero?> UpdateHero(SuperHero request, int id)
        {
            var hero = await _dbContext.SuperHeroes.FindAsync(id);
            if (hero is null) return null;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;
            hero.Name = request.Name;
            _dbContext.SuperHeroes.Update(hero);
            await _dbContext.SaveChangesAsync();
            return hero;
        }
    }
}
