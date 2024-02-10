# SushiTime.API
Um projeto de loja online feito com ASP.NET Core Web API e EF Core, com banco de dados SQL Server

Para utilizar a API é necessário configurar o appsettings.json inserindo as informações do seu contexto de banco de dados

"ConnectionStrings": {
    "Default": "Server=localhost;Database=SeuBancoDeDados;User Id=SeuUsuario;Password=SuaSenha;TrustServerCertificate=true;"
  },

  Substitua os campos com seu contexto, inserindo um nome para um novo banco de dados, seu usuario e sua senha.

  Depois é necessário rodar as migrações com dotnet database update, ou se quiser apagar as migrações e gerar novas fique a vontade, você é o dev ;)
