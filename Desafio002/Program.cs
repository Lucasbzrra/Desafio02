using Desafio002.Data;
using Desafio002.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//Conexão com banco de dado Ms Sql Server

builder.Services.AddDbContext<UrlDbContext>(opts => opts.UseSqlServer("Data Source=LUCAS\\MSSQLSERVER01; Initial Catalog=Url;User ID=sa;Password=0000"));
builder.Services.AddScoped<EncurtadorDeUrl>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
