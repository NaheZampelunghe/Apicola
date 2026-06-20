using Apicola.Abstactions;
using Apicola.Application;
using Apicola.DataAccess;
using Apicola.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<DbDataAccess>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                    o => o.MigrationsAssembly("Apicola.WebApi"));
            options.UseLazyLoadingProxies();
        });

        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddScoped(typeof(IApplication<>), typeof(Application<>));
        builder.Services.AddScoped(typeof(IDbContext<>), typeof(DbContext<>));
        var mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(typeof(Program).Assembly);
        }, NullLoggerFactory.Instance).CreateMapper();

        builder.Services.AddSingleton(mapper);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
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