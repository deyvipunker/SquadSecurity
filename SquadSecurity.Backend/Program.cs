using Microsoft.EntityFrameworkCore;
using SquadSecurity.Backend.Data;
using SquadSecurity.Backend.Repositories.Implementations;
using SquadSecurity.Backend.Repositories.Interfaces;
using System.Text.Json.Serialization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder
    .Services
    .AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=DefaultConnection"));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IParametrosRepository, ParametrosRepository>();

var app = builder.Build();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
