using Api.Extensions;
using Application.Extensions;
using Infra.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMappers();
builder.Services.AddInfra();
builder.Services.AddQueries();
builder.Services.AddCommands();
// Add services to the container.
builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.ConfigureHttpExceptionHandler();

app.Run();
