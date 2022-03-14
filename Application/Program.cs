
using Application.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMappers();
builder.Services.AddQueries();
builder.Services.AddCommands();
var app = builder.Build();

app.Run();