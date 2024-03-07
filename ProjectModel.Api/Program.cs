using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProjectModel.Api.Configurations;
using ProjectModel.Application.Commands.User;
using ProjectModel.Application.Handlers.User;
using ProjectModel.Infrastructure.Data;
using ProjectModel.Infrastructure.Interfaces;
using ProjectModel.Infrastructure.Repositories;
using ProjectModel.Infrastructure.Resources;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// DI Repository
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// DI Handlers
// Users
builder.Services.AddTransient<IRequestHandler<UserCreateCommand, int>, UserCommandHandler>();
builder.Services.AddTransient<IRequestHandler<UserUpdateCommand, Unit>, UserCommandHandler>();
builder.Services.AddTransient<IRequestHandler<UserDeleteCommand, Unit>, UserCommandHandler>();

//DI Resources
builder.Services.AddTransient<IResources, Resources>();

//Resource Localization
builder.Services.AddLocalization(options => options.ResourcesPath = "");

// Add Conexão com base de dados
builder.Services.AddDbContext<ProjectModelDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// Adicione o Swagger com multi linguagem
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Model API", Version = "v1" });

    // Adicionar suporte para múltiplos idiomas
    options.OperationFilter<SwaggerLanguageOperationFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Model API");
    });
}

// Adicione o middleware para definir a cultura com base no idioma selecionado no Swagger
app.UseLanguageMiddleware();

app.UseRouting();

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();