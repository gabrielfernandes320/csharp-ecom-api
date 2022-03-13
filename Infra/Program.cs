using Infra.Database.Ef;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "User ID=postgres;Password=admin;Host=localhost;Port=5432;Database=ecomapi;Pooling=true;";
builder.Services.AddDbContext<Context>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

app.Run();