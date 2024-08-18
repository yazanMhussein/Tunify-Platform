using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.interfaces;
using TunifyPlatform.Repositories.Services;

namespace TunifyPlatform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            string ConnectsStringVar = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<TunifyDbContext>(optoinsX => optoinsX.UseSqlServer(ConnectsStringVar));

            
            builder.Services.AddScoped<IUser, UserServices>();
            builder.Services.AddScoped<IArtist, ArtistServices>();
            builder.Services.AddScoped<IPlayList, PlayListServices>();
            
            builder.Services.AddTransient<ISong, SongServices>();

            builder.Services.AddSwaggerGen
                (
                option =>
                {
                    option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Tunify API",
                        Version = "v1",
                        Description = "API for managing playlists, songs, and artists in the Tunify Platform"
                    });

                });
            var app = builder.Build();

            app.UseSwagger
                (
                options =>
                {
                    options.RouteTemplate = "api/{documentName}/swagger.json";
                }
                );
            app.UseSwaggerUI
                (
                    options =>
                    {
                        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Tunify API v1");
                        options.RoutePrefix = "";
                    }
                );

            app.MapControllers();
 
            //app.MapGet("/", () => "You are on the main page (The Home Page)!");
            app.Run();
        }
    }
}
