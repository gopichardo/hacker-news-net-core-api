using Application.Services;
using Application.UseCases;
using Domain.Entities;
using Domain.Interfaces.Clients;
using Domain.Interfaces.Services;
using Domain.Interfaces.UseCases;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddScoped<IGetBestStoriesUseCase, GetBestStoriesUseCase>();
builder.Services.AddScoped<IStoryService, StoryService>();
// builder.Services.AddScoped<IHackerNewsClient, HackerNewsClient>();
// builder.Services.AddScoped<HttpClient, HttpClient>();

builder.Services.AddHttpClient<IHackerNewsClient, HackerNewsClient>();
builder.Services.AddMemoryCache();
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddOptions();


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
