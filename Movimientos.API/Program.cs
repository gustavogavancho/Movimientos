using Microsoft.EntityFrameworkCore;
using Movimientos.API.Profiles;
using Movimientos.BIZ.Services;
using Movimientos.BIZ.Services.Interfaces;
using Movimientos.DAL.EFCore;
using Movimientos.DAL.EFCore.Repository;
using Movimientos.DAL.EFCore.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MovimientosDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("sqlite")));
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IMovimientoRepository, MovimientoRepository>();
builder.Services.AddScoped<ICuentaRepository, CuentaRepository>();
builder.Services.AddScoped<IMovimientoService, MovimientoService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
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
