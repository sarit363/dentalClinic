using dental_clinic.entities;
using dental_clinic.Core.services;
using dental_clinic.Serivce;
using dental_clinic.Core.reposetories;
using dental_clinic.Data.repositories;
using dental_clinic;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    option.JsonSerializerOptions.WriteIndented = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDentistServices, DentistService>();
builder.Services.AddScoped<IDentistRepository, DentistRepository>();

builder.Services.AddScoped<IPatientServices, PatientService>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();

builder.Services.AddScoped<ITurnServices, TurnService>();
builder.Services.AddScoped<ITurnRepository, TurnRepository>();


builder.Services.AddDbContext<DataContext>();
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
