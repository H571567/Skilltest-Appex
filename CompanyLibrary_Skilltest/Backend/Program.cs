using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.Extensions.Hosting;
using Backend.Data;
using System.Text;
using Backend.UserRepository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Backend.Configuration;
using Microsoft.Extensions.Configuration;

var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtConfig:Secret"]);
var tokenValidationParms = new TokenValidationParameters
{
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(key),
    ValidateIssuer = false,
    ValidateAudience = false,
    ValidateLifetime = true,
    RequireExpirationTime = true,
    ClockSkew = TimeSpan.Zero
};

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(option => option.UseMySql(builder.Configuration.GetConnectionString("Default"), serverVersion));

builder.Services.AddCors();
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddHttpContextAccessor();

/*
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
*/

builder.Services.AddSingleton(tokenValidationParms);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

})
                .AddJwtBearer(jwt =>
                {
                    jwt.SaveToken = true;
                    jwt.TokenValidationParameters = tokenValidationParms;
                    jwt.Events = new JwtBearerEvents();

                    jwt.Events.OnMessageReceived = context =>
                    {
                        if (context.Request.Cookies.ContainsKey("token"))
                        {
                            context.Token = context.Request.Cookies["token"];
                        }
                        return Task.CompletedTask;
                    };
                });

var app = builder.Build();

// Configure the HTTP request pipeline.
/*
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors(options => options
    .WithOrigins(new[] { "http://localhost:5001" })
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
