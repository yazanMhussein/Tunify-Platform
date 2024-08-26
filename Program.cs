using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
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

            
            builder.Services.AddIdentity<AccountUser, IdentityRole>()
                   .AddEntityFrameworkStores<TunifyDbContext>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<IUser, UserServices>();
            builder.Services.AddScoped<IArtist, ArtistServices>();
            builder.Services.AddScoped<IPlayList, PlayListServices>();
            
            builder.Services.AddScoped<ISong, SongServices>();
            builder.Services.AddScoped<IAccount, IdentityAccountService>();

            // jwt set up part 1
            builder.Services.AddScoped<JwtTokenService>();
            // add jwt set up part 2 


            builder.Services.AddAuthentication(
    options =>
    {
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }
        ).AddJwtBearer(
                options =>
                {
                    options.TokenValidationParameters = JwtTokenService.ValidateToken(builder.Configuration);
                }
                );


            builder.Services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Tunify API",
                        Version = "v1",
                        Description = "API for managing playlists, songs, and artists in the Tunify Platform"
                    });

                    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "Please enter user token below."
                    });

                    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                        }
                    });

                });
            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();

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
                        options.SwaggerEndpoint("/api/v1/swagger.json", "Tunify API v1");
                        options.RoutePrefix = "";
                    });
            


            app.MapControllers();
            app.MapGet("/newpages", () => "Hello World! from the new page");
            //app.MapGet("/", () => "You are on the main page (The Home Page)!");
            app.Run();
        }
    }
}
