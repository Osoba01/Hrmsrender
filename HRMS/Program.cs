using FluentValidation;
using FluentValidation.AspNetCore;
using static HRMSinfrastructure.Dependency.DLLDependency;
using System.Reflection;
using static HRMS.API.Utilities.Constant.ConfigurationConst;
using MediatR;
using static HRMS.Auth.AuthConfiguration;

using Microsoft.OpenApi.Models;
using Serilog;
using HRMS.API.ExceptionHandling;
using HRMSinfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using HRMS.API.Files.manager;
using HRMSinfrastructure.Dependency;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});
// Add services to the container.
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers()
    .AddFluentValidation(c =>
    {
        c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        c.ValidatorOptions.CascadeMode = CascadeMode.Stop;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<HRMSDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString(ConString));
});
//builder.Services.RepoDependencyCollection();
//builder.Services.MapDependencyCollection();
builder.Services.DependencyCollection();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddTransient<IFileManager, FileManager>();


builder.Services.AuthenticationSetup(builder.Configuration);

var key = builder.Configuration.GetSection(AppSettingToken).Value;
builder.Services.AddAuthorization();

builder.Services.AddCors(option =>
{
    option.AddPolicy(name: AllowSpecificOrigin, policy =>
    {
        policy
        .AllowAnyHeader()
        .AllowAnyOrigin()
        //.WithOrigins(builder.Configuration.GetSection("AllowedOrigins").Get<string[]>())
        .WithMethods("GET", "POST", "PUT", "PATCH", "DELETE");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(AllowSpecificOrigin);

app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();

app.Run();
