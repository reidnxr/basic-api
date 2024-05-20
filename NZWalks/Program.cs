using DataContext;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services;
using Services.IServices;
using System.Linq.Expressions;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "Jwt Authentication",
                Description = "Enter a valid JWT bearer token",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };
            options.CustomSchemaIds(type => type.ToString());
            options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {securityScheme, new string[] { } }
            });
        });
        builder.Services.AddDbContext<WalksDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksConnection")));
        builder.Services.AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<Program>());
        builder.Services.AddScoped<IRegionService, RegionService>();
        builder.Services.AddScoped<IWalkService, WalkService>();
        builder.Services.AddScoped<IWalkDifficultyService, WalkDifficultyService>();
        builder.Services.AddScoped<ITokenService, TokenService>();

        builder.Services.AddSingleton<IUserService, UserService>();

        builder.Services.AddAutoMapper(typeof(Program).Assembly);
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                        .AddJwtBearer(options =>
                            options.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuer = true,
                                ValidateAudience = true,
                                ValidateLifetime = true,
                                ValidateIssuerSigningKey = true,
                                ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                                ValidAudience = builder.Configuration["JwtSettings:Audience"],
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
                            }
                        );
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}