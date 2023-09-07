
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VideoGames.Api.Mapper;
using VideoGames.BLL.Abstract;
using VideoGames.BLL.Services;
using VideoGames.DAL.Abstract;
using VideoGames.DAL.EFramework.Context;
using VideoGames.DAL.EFramework.Repositories;
using VideoGames.DAL.Entities.Entities;

namespace VideoGames.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Контекст БД
            string connectionString = builder.Configuration.GetConnectionString("default")!;
            builder.Services.AddDbContext<EFContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            #endregion

            #region Репозитоории
            builder.Services.AddScoped<IGenericRepository<GameEntity>, EFGamesRepository>();
            builder.Services.AddScoped<IGenericRepository<GenreEntity>, EFGenreRepository>();
            builder.Services.AddScoped<IGenericRepository<CreaterEntity>, EFCreaterRepository>();
            #endregion

            #region Сервисы
            builder.Services.AddScoped<IGameService, GameService>();
            #endregion

            #region Маппер
            builder.Services.AddAutoMapper(typeof(ApplicationProfile));
            #endregion

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}