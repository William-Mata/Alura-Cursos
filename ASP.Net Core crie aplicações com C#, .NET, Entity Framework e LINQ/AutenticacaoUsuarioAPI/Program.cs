using AutenticacaoUsuarioAPI.Authorization;
using AutenticacaoUsuarioAPI.Data;
using AutenticacaoUsuarioAPI.Models;
using AutenticacaoUsuarioAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// CONFIGURA플O DA CONEX홒 COM O BANCO DE DADOS - INSTALAR ENTITY FRAMEWORKCORE SQLSERVER E TOLS
builder.Services.AddDbContext<Context>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("Connection")); 
});

// CONFIGURA플O DO ENTITY - INSTALAR IDENTITY E STORES
builder.Services.AddIdentity<Usuario, IdentityRole>().AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();

// CONFIGURA플O DE AUTORIZA플O E POLITICA DE ACESSO 

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).
AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SymmetricSecurityKey"])),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("IdadeMinima", policy => policy.AddRequirements(new IdadeMinima(18)));
});


// ADICIONANDO O AUTOMAPPER - INSTALAR AUTOMAPPER E DEPENDENCY INJECTION 
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// CONFIGURANDO A INJE플O DE DEPENDENCIA - (AddTransient GERA UMA INSTANCIA A CADA REQUISI플O, AddScoped REUTILIZA A INSTANCIA)
builder.Services.AddScoped<UsuarioService>(); 
builder.Services.AddScoped<TokenService>();
builder.Services.AddSingleton<IAuthorizationHandler, IdadeAuthorization>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
