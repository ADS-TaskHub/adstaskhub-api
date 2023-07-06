using adstaskhub_api.Application.Services;
using adstaskhub_api.Infrastructure;
using adstaskhub_api.Infrastructure.Mappers;
using adstaskhub_api.Infrastructure.Mappers.Interfaces;
using adstaskhub_api.Infrastructure.Repositories;
using adstaskhub_api.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(x =>
{
    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    x.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
            Reference = new OpenApiReference
                {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,

            },
            new List<string>()
        }
    });
});

var hashKey = builder.Configuration.GetValue<string>("TokenSettings:HashKey");

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(hashKey)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<DBContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<IPeriodRepository, PeriodRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ITaskAssignmentRepository, TaskAssignmentRepository>();

builder.Services.AddScoped<IUserMapper, UserMapper>();
builder.Services.AddScoped<IClassMapper, ClassMapper>();
builder.Services.AddScoped<IPeriodMapper, PeriodMapper>();
builder.Services.AddScoped<ITaskMapper, TaskMapper>();
builder.Services.AddScoped<IRoleMapper, RoleMapper>();

builder.Services.AddScoped<TokenService>(sp => new TokenService(hashKey));
builder.Services.AddScoped<AuthenticationService>();


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
