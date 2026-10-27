# BiblioHon 📚

O **BiblioHon** é um aplicativo desktop para cadastro e gerenciamento de livros de biblioteca, desenvolvido como projeto de portfólio. A proposta é aprender tecnologias novas e desenvolver competências de programação por meio da construção de uma aplicação prática.

## Sobre o projeto

O aplicativo permite cadastrar livros com título, autor, editora, ISBN, ano de publicação e gênero. Os dados são armazenados localmente em um banco SQLite. A interface apresenta os livros cadastrados e oferece uma ação para excluí-los.

O projeto está em desenvolvimento e serve também como espaço de experimentação e aprendizado. As anotações sobre conceitos e decisões técnicas estão no diretório [`MYLEARNING`](MYLEARNING/).

## Tecnologias

- **C# e .NET 10** — linguagem e plataforma da aplicação;
- **Avalonia UI** — interface desktop multiplataforma;
- **Entity Framework Core** — acesso e persistência de dados;
- **SQLite** — banco de dados local;
- **CommunityToolkit.Mvvm** — suporte ao padrão MVVM e comandos da interface.

## Organização

- `Models/` — entidades do domínio, como livro e exemplar;
- `Views/` — interface da aplicação;
- `ViewModels/` — estado e comandos apresentados pelas telas;
- `Services/` — regras e operações da aplicação;
- `Repositories/` — consultas e gravações no banco;
- `Migrations/` — migrações do Entity Framework Core;
- `MYLEARNING/` — anotações de aprendizado feitas durante o desenvolvimento.

## Como executar

É necessário ter o **SDK do .NET 10** instalado. Na pasta do projeto, execute:

```bash
dotnet restore
dotnet run
```

## Objetivos de aprendizado 🎯

Este projeto é uma oportunidade para praticar desenvolvimento desktop, organização em camadas, MVVM, injeção de dependência, operações assíncronas e persistência de dados com Entity Framework Core. Também registro aprendizados e conceitos no diretório `MYLEARNING` para acompanhar minha evolução.

---

Feito como parte da minha jornada de aprendizado e construção de portfólio 💻✨
