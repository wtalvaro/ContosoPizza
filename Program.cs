var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

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
