using serviceEnterprise.Infrastructure.Extensions;
using serviceEnterprise.Infrastructure.Persistence;
using serviceEnterprise.Application.Extension;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Infrastructure
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
