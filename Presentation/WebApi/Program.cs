using Application.Services;
using Application.UseCases;
using Domain.Interfaces.Clients;
using Domain.Interfaces.Services;
using Domain.Interfaces.UseCases;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddScoped<IGetBestStoriesUseCase, GetBestStoriesUseCase>();
builder.Services.AddScoped<IStoryService, StoryService>();
builder.Services.AddScoped<IHackerNewsClient, HackerNewsClient>();
builder.Services.AddScoped<HttpClient, HttpClient>();

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
