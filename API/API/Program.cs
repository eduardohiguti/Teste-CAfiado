using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Produto> produtos = new List<Produto> {};
/*
 {
    new Produto { Nome = "Apple iPhone 14", Valor = 999.99, Quantidade = 10 },
    new Produto { Nome = "Samsung Galaxy S23", Valor = 899.99, Quantidade = 5 },
    new Produto { Nome = "Sony WH-1000XM5", Valor = 349.99, Quantidade = 20 },
    new Produto { Nome = "Dell XPS 13", Valor = 1199.99, Quantidade = 8 },
    new Produto { Nome = "Apple MacBook Pro", Valor = 2399.99, Quantidade = 15 },
    new Produto { Nome = "Bose QuietComfort 35 II", Valor = 299.99, Quantidade = 12 },
    new Produto { Nome = "Nintendo Switch", Valor = 299.99, Quantidade = 7 },
    new Produto { Nome = "GoPro HERO10", Valor = 499.99, Quantidade = 25 },
    new Produto { Nome = "Kindle Paperwhite", Valor = 139.99, Quantidade = 30 },
    new Produto { Nome = "Sony PlayStation 5", Valor = 499.99, Quantidade = 18 }
};
*/

app.MapGet("/", () => "API de Produtos");

app.MapGet("/api/produto/listar", () =>
{
    if (produtos.Count > 0)
    {
        return Results.Ok(produtos);
    }
    return Results.NotFound();
});

app.MapPost("/api/produto/cadastrar", ([FromBody] Produto produto) =>
{
    produtos.Add(produto);
    return Results.Created("", produto);
});

app.MapPut("/api/produto/buscar", ([FromBody] Produto produto) =>
{
    var produtoExistente = produtos.FirstOrDefault(p => p.Nome == produto.Nome);
    if (produtoExistente != null)
    {
        produtoExistente.Nome = produto.Nome;
        return Results.Ok(produtoExistente);
    }
    return Results.NotFound();
});

app.MapPut("/api/produto/atualizar", ([FromBody] Produto produto) =>
{
    var produtoExistente = produtos.FirstOrDefault(p => p.Nome == produto.Nome);
    if (produtoExistente != null)
    {
        produtoExistente.Valor = produto.Valor;
        produtoExistente.Quantidade = produto.Quantidade;
        return Results.Ok(produtoExistente);
    }
    return Results.NotFound();
});

app.MapDelete("/api/produto/remover", ([FromBody] Produto produto) =>
{
    var produtoExistente = produtos.FirstOrDefault(p => p.Nome == produto.Nome);
    if (produtoExistente != null)
    {
        produtos.Remove(produtoExistente);
        return Results.NoContent();
    }
    return Results.NotFound();
});

app.Run();