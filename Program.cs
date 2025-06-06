using FluentValidation.AspNetCore;
using PedidoBebidaAPI.Configuration;
using PedidoBebidaAPI.Repositories;
using PedidoBebidaAPI.Services;
using PedidoBebidaAPI.Validators;
using Serilog;

//Logs
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(fv =>
        fv.RegisterValidatorsFromAssemblyContaining<RevendaRequestValidator>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<RevendaService>();
builder.Services.AddSingleton<IRevendaRepository, RevendaRepository>();

builder.Services.AddHttpClient<IPedidoExternoService, PedidoExternoService>()
    .AddPolicyHandler(Policies.ObterRetryPolicy());

builder.Services.AddSingleton<PedidoClienteService>();
builder.Services.AddScoped<PedidoRevendaService>();
builder.Services.AddScoped<PedidoRevendaValidator>();

builder.Host.UseSerilog();

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
