using System.Reflection;

using MediatR;

using Microsoft.EntityFrameworkCore;
using ProjectModel.Application.Commands.User;
using ProjectModel.Application.Handlers.User;
using ProjectModel.Infrastructure.Data;
using ProjectModel.Infrastructure.Interfaces;
using ProjectModel.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// DI Repository
builder.Services.AddScoped<IUserRepository, UserRepository>();

// DI Handlers
// Users
builder.Services.AddTransient<IRequestHandler<UserCreateCommand, int>, UserCommandHandler>();
builder.Services.AddTransient<IRequestHandler<UserUpdateCommand, Unit>, UserCommandHandler>();
builder.Services.AddTransient<IRequestHandler<UserDeleteCommand, Unit>, UserCommandHandler>();

// Add Conexão com base de dados
builder.Services.AddDbContext<ProjectModelDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

app.Run();