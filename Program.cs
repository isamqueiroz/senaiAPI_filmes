using api_filmes_senai.Context;
using api_filmes_senai.Interfaces;
using api_filmes_senai.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o contexto do banco de dados (exemplo com SQL Server)
builder.Services.AddDbContext<Filmes_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Adicionar o repositorio e a interface ao container de injecao de dependencia
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();

//Adicionar o servico de Controllers
builder.Services.AddControllers();

var app = builder.Build();

//Adicionar o mapeamento dos controllers
app.MapControllers();

app.Run();

