using DataAccess.DbContext;
using DataAccess.Repositories;
using Domain.Repositories.Interfaces;
using Domain.UseCases;
using Domain.UseCases.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

AddServices(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void AddServices(WebApplicationBuilder builder)
{
    builder.Services.AddDbContext<ApplicationContext>(opts =>
        opts.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
            optionsBuilder => optionsBuilder.MigrationsAssembly("Api")));
    
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IUserGroupRepository, UserGroupRepository>();
    builder.Services.AddScoped<IUserStateRepository, UserStateRepository>();

    builder.Services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
    builder.Services.AddScoped<IGetUserUseCase, GetUserUseCase>();
    builder.Services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();
    builder.Services.AddScoped<IGetUsersListUseCase, GetUsersListUseCase>();
}