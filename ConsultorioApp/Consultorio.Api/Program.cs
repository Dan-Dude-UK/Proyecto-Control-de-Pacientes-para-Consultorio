using Consultorio.Infrastructura.Interfaces.Repository;
using Consultorio.Infrastructura.Context;
using Consultorio.Infrastructura.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var MyConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ConsultorioDbContext>(option =>
{
    option.UseSqlServer(MyConnectionString);
});

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IConsultationRepository, ConsultationRepository>();
builder.Services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

//app.UseHttpsRedirection();
app.MapSwagger();
app.UseSwaggerUI();
app.UseCors("AllowFrontend");

app.MapControllers();

app.Run();
