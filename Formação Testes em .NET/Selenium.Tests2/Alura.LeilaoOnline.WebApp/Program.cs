using Alura.LeilaoOnline.Core;
using Alura.LeilaoOnline.WebApp.Dados;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<LeiloesContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("StringConnections"));
});

builder.Services.AddTransient<IModalidadeAvaliacao, MaiorValor>();
builder.Services.AddTransient<IRepositorio<Leilao>, RepositorioLeilao>();
builder.Services.AddTransient<IRepositorio<Interessada>, RepositorioInteressada>();
builder.Services.AddTransient<IRepositorio<Usuario>, RepositorioUsuario>();
builder.Services.AddSession();
builder.Services.AddMvc();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
