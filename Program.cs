using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Repository;
using SistemaDeTarefas.Repository.Interface;
using SistemaTarefasService;
using SistemaTarefasService.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configuração do contexto
// qual string de coxão e banco vai usar
builder.Services.AddDbContext<SistemaTarefasDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));
//  configuração  das dependecia do repositorio
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
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
