//Minimal APIs em C# 
//Testar a API
// - Rest Client - Extensão VSCode
// - Postman**
// - Insomnia**
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Endpoints - Funcionalidades
//Requisição - URL e método/verbo HTTP
app.MapGet("/", () => "Mestre");
app.MapGet("/mom", () => "Hi mom!");
app.MapGet("/vampeta", () => "https://assets.portalleodias.com/2024/04/vampetasso-a-trolagem-brasileira-contra-o-preconceito-sofrido-por-vin.webp");

//Exercícios para próxima aula
// - Criar um endpoint para receber informação pela URL

//dotnet run --project API
app.Run();
