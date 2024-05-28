using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using RiverBooks.Books;
using RiverBooks.Users;
using Serilog;

var logger = Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

logger.Information("Starting RiverBooks.Web");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, config) =>
    config.ReadFrom.Configuration(builder.Configuration));

builder.Services
    .AddAuthenticationJwtBearer(s => s.SigningKey = builder.Configuration["Auth:JwtSecret"])
    .AddAuthorization()
    .AddFastEndpoints()
    .SwaggerDocument();

builder.Services.AddBookService(builder.Configuration, logger);
builder.Services.AddUserModuleServices(builder.Configuration, logger);

var app = builder.Build();

app.UseAuthentication()
    .UseAuthorization();

app.UseFastEndpoints()
    .UseSwaggerGen();

app.Run();

public partial class Program { } // Required for FastEndpoints Testing 