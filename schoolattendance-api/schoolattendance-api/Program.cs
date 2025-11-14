using Encryption.Extension;
using Microsoft.IdentityModel.Tokens;
using Repository.Extensions;
using schoolattendance_api.Cors;
using schoolattendance_api.Helpers;
using schoolattendance_api.Mapper;
using schoolattendance_api.Middlewares;
using schoolattendance_api.Services.Auth;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// We assign the configuration instance for the static helper (singleton-like functionality)
ConfigurationHelper.SetConfigValue(builder.Configuration);

// Handle Cors Extension
var myAllowSpecificOrigins = "_frontEndOrigin";
builder.Services.AddCorsPolicyExtension(myAllowSpecificOrigins);

var secretKeyAuth = ConfigurationHelper.GetConfigValue("JWT_SETTINGS_SECRET_KEY", "JwtSettings:SecretKey");
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtTokenService>(provider => new JwtTokenService(secretKeyAuth));

builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer(opt =>
{
    var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKeyAuth));
    var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature);

    opt.RequireHttpsMetadata = false;

    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = signingKey,
    };

});

// AutoMapper Extensions
builder.Services.AddAutoMapperExtension();

// Data MySql Extensions
var connectionString = ConfigurationHelper.GetConfigValue("DB_CONNECTION_STRING", "ConnectionStrings:MysqlConnection");
builder.Services.AddMySQLRepositories(connectionString);

// Encryption Extension
var keySettingEncrypted = ConfigurationHelper.GetConfigValue("", "EncryptionSettings:EncryptionKey");
var vectorSettingEncrypted = ConfigurationHelper.GetConfigValue("", "EncryptionSettings:InitializationVector");
builder.Services.AddEncryptionExtension(keySettingEncrypted, vectorSettingEncrypted);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(myAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();
app.Run();
