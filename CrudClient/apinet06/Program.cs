
using apinet06.Models.Interfaces;
using apinet06.Models.Repositorys;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(x=>x.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IClientRepository,ClientRepository>();
// builder.Services.AddScoped<ICobrancaRepository,ClientRepository>();



//builder.Services.AddControllers().AddNewtonsoftJson();
// builder.Services.AddControllers().AddJsonOptions(opt => {opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());});

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


