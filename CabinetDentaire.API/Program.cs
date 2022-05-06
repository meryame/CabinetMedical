using CabinetDentaire.BLL.Services;
using CabinetDentaire.DAL.Data.Models;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<DbContext>();
builder.Services.AddTransient<IDentisteService, DentisteService>();
builder.Services.AddTransient<IPatientService, PatientService>();
builder.Services.AddScoped<IFicheMedicalService, FicheMedicalService>();
builder.Services.AddTransient<IConsultationService, ConsultationService>();
builder.Services.AddTransient<IRendezVousService, RendezVousService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.MapType<TimeSpan>(() => 
new OpenApiSchema { Type = "string", Example = new OpenApiString("00:00:00") }));
//builder.Services.AddMvc().AddNewtonsoftJson();

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
