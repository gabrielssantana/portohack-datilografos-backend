
using API.Services;

namespace API;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSingleton<WebsocketObterDados>();

        var app = builder.Build();
        app.UseWebSockets();

        app.UseCors(opt =>
        {
            opt.AllowAnyHeader();
            opt.AllowAnyMethod();
            opt.AllowAnyOrigin();
        });

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.Map("/", () => Results.Redirect("/swagger"));
        }

        app.UseAuthorization();

        app.MapControllers();

        await app.RunAsync();
    }
}
