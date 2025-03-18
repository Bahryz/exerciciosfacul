using API_REVISAO.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://192.168.56.1:3000")  // Adiciona a origem permitida
              .AllowAnyHeader()  // Permite qualquer cabeçalho
              .AllowAnyMethod(); // Permite qualquer método (GET, POST, etc.)
    });
});

var app = builder.Build();

app.MapGet("/", () => "Revisão de Web API e EF!");

app.MapPost("/api/produto/cadastrar", 
    ([FromBody] Produto produto, 
    [FromServices] AppDataContext ctx) => 
{
    ctx.Produtos.Add(produto);
    ctx.SaveChanges();
    return Results.Created("", produto);
});

app.MapGet("/api/produto/listar", 
    ([FromServices] AppDataContext ctx) => 
{
    return Results.Ok(ctx.Produtos.ToList());
});

app.UseCors("AllowSpecificOrigin");
app.Run();
