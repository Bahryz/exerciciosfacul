using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>(options =>
    options.UseSqlite("Data Source=app.db"));

builder.Services.AddCors();

var app = builder.Build();


var produtos = new List<object>
{
    new { Id = 1, Nome = "Notebook", Preco = 5000.00 },
    new { Id = 2, Nome = "Mouse Gamer", Preco = 250.00 },
    new { Id = 3, Nome = "Teclado Mecânico", Preco = 350.00 }
};

app.MapGet("produto/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Produtos.Any())
    {
        return Results.Ok(ctx.Produtos.ToList());
    }
    return Results.NotFound("Nenhuma produto encontrado");
});

app.MapGet("produto/buscar/{id}", ([FromServices] AppDataContext ctx, int id) =>
{
    var produto = ctx.Produtos.Find(id);
    return produto != null ? Results.Ok(produto) : Results.NotFound("Produto não encontrado");
});

app.MapPost("produto/adicionar", ([FromServices] AppDataContext ctx, Produto produto) =>
{
    ctx.Produtos.Add(produto);
    ctx.SaveChanges();
    return Results.Created("", produto);
});


app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


app.Run();