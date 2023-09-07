using Microsoft.EntityFrameworkCore;
using VideoGames.DAL.Entities.Entities;

namespace VideoGames.DAL.EFramework.Context
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
            if (Database.EnsureCreated())
            {
                Init();
            }
        }

        public DbSet<GameEntity> Games { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<CreaterEntity> Creaters { get; set; }

        private void Init()
        {
            GenreEntity[] genres = {
                new GenreEntity{Title = "Action"},
                new GenreEntity{Title = "Sport"}
            };

            Genres.AddRange(genres);

            CreaterEntity[] creaters = {
                new CreaterEntity{Title = "Bethesda", Country = "USA"},
                new CreaterEntity{Title = "TargemGame", Country = "Russia"},
                new CreaterEntity{Title = "Ubisoft", Country = "Europe"},
            };

            Creaters.AddRange(creaters);

            GameEntity[] games = {
                new GameEntity{Title = "Crossout", Creater = creaters[1], Genres = new[]{ genres[0] } },
                new GameEntity{Title = "Assasin's Creed", Creater = creaters[2], Genres = genres },
                new GameEntity{Title = "Skyrim", Creater = creaters[0], Genres = new[]{ genres[1] } },
            };

            Games.AddRange(games);

            this.SaveChanges();
        }
    }
}
