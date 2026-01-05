using ContosoPizza.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data Source=ContosoPizza.db")); builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Registrar o serviço
builder.Services.AddScoped<ProdutoService>();

// Se ainda não tiveres, adiciona o suporte a controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Adicione esta linha para habilitar arquivos estáticos (como wwwroot)
app.UseStaticFiles();

// Adicione isso se quiser que a raiz sirva o index.html automaticamente
app.MapGet("/", context =>
{
    context.Response.Redirect("/index.html");
    return Task.CompletedTask;
});

// Ou, se preferir servir o arquivo sem redirecionamento:
// app.MapGet("/", () => Results.File("wwwroot/index.html", "text/html"));

app.UseAuthorization();

app.MapControllers();

app.Run();
