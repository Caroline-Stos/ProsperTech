using Microsoft.Extensions.Options;
using RepositorioEntity.Context;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using Model.Geladeira;
using RepositorioEntity.Interfaces;
using RepositorioEntity.Repository;
using Servicos.Interfaces;
using Servicos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//adicionando a conexao ao contexto da GeladeiraDbContext
builder.Services.AddDbContext<GeladeiraDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Adicionando o Repository à injeção de dependência
builder.Services.AddScoped<IRepository<ItemModel>, GeladeiraRepository>();

// Adicionando o Service à injeção de dependência (caso tenha um serviço adicional)
builder.Services.AddScoped<IService<ItemModel>, GeladeiraService>();

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
