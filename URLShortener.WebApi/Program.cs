
using Microsoft.EntityFrameworkCore;
using URLShortener.Dados;
using URLShortener.WebApi.Filters;

namespace URLShortener.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<UrlShortenerContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("UrlShortenerApi"));
            });

            builder.Services.AddScoped<IRepository, UrlRepositorioEF>();


            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<CustomFilterExceptionHandler>();
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("AllowAnyOrigin");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
