using Infrastructure.Extensions.App;
using Infrastructure.Extensions.builder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ServicesCollection(builder.Configuration);

var app = builder.Build();

app.AppConfigure();
