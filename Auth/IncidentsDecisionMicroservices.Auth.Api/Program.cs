using IncidentsDecisionMicroservices.Auth.Api.Initializers;
using IncidentsDecisionMicroservices.Auth.Application.Interfaces;
using IncidentsDecisionMicroservices.Auth.Application.RabbitMqService;
using IncidentsDecisionMicroservices.Auth.Application.Services;
using IncidentsDecisionMicroservices.Auth.Core.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var corsName = "AllowAny";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsName,
        builder =>
        {
            builder.WithOrigins("http://127.0.0.1:8080")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
    });
});

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

builder.Services.AddDbContext<IncidentDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

builder.Services.AddOpenApi();

builder.Services.AddScoped<IEmployeeLoginRepository, EmployeeLoginRepository>();
builder.Services.AddScoped<IEmployeeLoginService, EmployeeLoginService>();

builder.Services.AddScoped<ITechSupportLoginRepository, TechSupportLoginRepository>();
builder.Services.AddScoped<ITechSupportLoginService, TechSupportLoginService>();

builder.Services.AddControllers();

builder.Services.AddSingleton<ITokenProvider, TokenProvider>();
 
//builder.Services.AddSingleton<IRabbitMqService, RabbitMqService>();
//builder.Services.AddHostedService<RabbitMqInitializer>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
        o.RequireHttpsMetadata = false;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])),
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            ClockSkew = TimeSpan.Zero
        };

        o.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies[builder.Configuration["JWT:Name"]];

                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();