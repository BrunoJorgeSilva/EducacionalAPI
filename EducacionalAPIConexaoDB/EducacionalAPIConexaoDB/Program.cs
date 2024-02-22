using Microsoft.EntityFrameworkCore;
using EducacionalAPIConexaoDB.Context;
using System.Text.Json.Serialization;
using EducacionalAPIConexaoDB.Persistency;
using EducacionalAPIConexaoDB.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string mySqlConnection =
ConfigurationExtensions.GetConnectionString(GetConfiguration(builder), "DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(mySqlConnection,
                ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddControllers()
       .AddJsonOptions(options =>
          options.JsonSerializerOptions
             .ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IClassRoomService, ClassRoomService>();
builder.Services.AddScoped<IReqWarningService, ReqWarningService>();


builder.Services.AddScoped<IStudentPersistence, StudentPersistence>();
builder.Services.AddScoped<IEmailPersistence, EmailPersistence>();
builder.Services.AddScoped<IClassRoomPersistence, ClassRoomPersistence>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

static ConfigurationManager GetConfiguration(WebApplicationBuilder builder)
{
    return builder.Configuration;
}

