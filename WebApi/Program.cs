using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using WebApi.Application.Abstractions.Messaging;
using WebApi.Application.Features.Users.Commands.DeleteUser;
using WebApi.Application.Features.Users.Commands.RegisterUser;
using WebApi.Application.Features.Users.Queries.GetByEmail;
using WebApi.Application.Features.Users.Queries.GetUserById;
using WebApi.Application.Features.Users.Queries.GetUserByUserName;
using WebApi.Domain.Repositories;
using WebApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<IUserRepository, InMemoryUserRepository>();
builder.Services.AddScoped<ICommandHandler<RegisterUserCommand, Guid>, RegisterUserCommandHandler>();
builder.Services.AddScoped<IQueryHandler<GetUserByIdQuery, UserResponse>, GetUserByIdQueryHandler>();
builder.Services.AddScoped<IQueryHandler<GetUserByUserNameQuery, UserResponse>, GetUserByUserNameQueryHandler>();
builder.Services.AddScoped<IQueryHandler<GetUserByEmailQuery, UserResponse>, GetUserByEmailQueryHandler>();
builder.Services.AddScoped<ICommandHandler<DeleteUserCommand>, DeleteUserCommandHandler>();

builder.Services.AddDbContext<InMemoryDbContext>(o =>
{
    o.UseInMemoryDatabase("CqrsDemo");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapControllers();

app.Run();