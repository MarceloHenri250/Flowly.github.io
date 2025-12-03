# Flowly API (skeleton)

Projeto ASP.NET Core Web API — scaffold inicial.

Como rodar (exemplo):

```powershell
cd flowly-api
dotnet restore
dotnet ef database update    # se usar EF Migrations
dotnet run
```

Estrutura inicial:
- `Program.cs` — bootstrap da API
- `Flowly.Api.csproj` — projeto .NET

Próximos passos:
- Implementar Models, DTOs, Repositories
- Configurar autenticação JWT
- Criar migrations e conectar ao DB
