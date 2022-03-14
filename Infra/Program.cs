using Infra.Database.Ef;
using Infra.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfra();

var app = builder.Build();

app.Run();