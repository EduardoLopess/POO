using Data.Context;
using Data.Repositories;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(
    x => x.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IAlunoRepository , AlunoRepository>();
builder.Services.AddScoped<IProfessorRepository , ProfessorRepository>();
builder.Services.AddScoped<ICursoRepository , CursoRepository>();
builder.Services.AddScoped<IEnderecoRepository , EnderecoRepository>();
builder.Services.AddScoped<ITurmaRepository , TurmaRepository>();
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
builder.Services.AddScoped<INotaRepository, NotaRepository>();
builder.Services.AddScoped<IMateriaRepository, MateriaRepository>();
// builder.Services.AddScoped<IHistoricosRepository, HistoricosRepository>();


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
