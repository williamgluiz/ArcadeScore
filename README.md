
# ArcadeScore

ArcadeScore é uma aplicação de registro e exibição de pontuações para jogos arcade, com backend em .NET 8 e frontend em Angular.

---

## Índice

- [Visão Geral](#visão-geral)
- [Backend](#backend)
  - [Tecnologias](#tecnologias)
  - [Configuração](#configuração)
  - [Executando a API](#executando-a-api)
  - [Validação](#validação)
- [Frontend](#frontend)
  - [Tecnologias](#tecnologias-1)
  - [Configuração](#configuração-1)
  - [Executando o Frontend](#executando-o-frontend)
  - [Layout e Navegação](#layout-e-navegação)
- [Instruções de Docker](#instruções-de-docker)
- [Contribuindo](#contribuindo)
- [Licença](#licença)

---

## Visão Geral

Este projeto consiste em uma API backend desenvolvida em .NET 8 e um frontend em Angular.  
Ele permite que usuários registrem pontuações de jogos arcade e visualizem rankings.

---

## Backend

### Tecnologias

- .NET 8
- MediatR (padrão CQRS)
- FluentValidation

### Configuração

1. Certifique-se de ter o [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) instalado.
2. Clone o repositório.
3. Navegue até a pasta do backend.
4. Restaure as dependências:

```bash
dotnet restore
```

### Executando a API

Execute a API com o comando:

```bash
dotnet run
```

A API será iniciada em `https://localhost:5001` (por padrão).

### Validação

O backend utiliza FluentValidation integrado com o pipeline do MediatR para validar comandos de entrada.  
Um middleware global de tratamento de exceções retorna erros de validação com respostas HTTP 400 claras e padronizadas.

---

## Frontend

### Tecnologias

- Angular 17+
- Bootstrap 5
- RxJS

### Configuração

1. Certifique-se de ter o [Node.js](https://nodejs.org/en/) e o npm instalados.
2. Navegue até a pasta do frontend.
3. Instale as dependências:

```bash
npm install
```

### Executando o Frontend

Execute o frontend com o comando:

```bash
ng serve
```

Abra o navegador em `http://localhost:4200`.

### Layout e Navegação

A aplicação possui um menu de navegação no topo com estilo retrô e responsivo:

- **Totalmente responsivo**: o menu se transforma em um ícone tipo "hamburger" em telas menores.
- **Construído com Bootstrap 5**, com estilização personalizada usando variáveis CSS e efeitos de sombra.
- **Links de navegação**:
  - `Registrar Pontuação`: abre o formulário para registrar uma nova pontuação.
  - `Ranking`: exibe o ranking atual de jogadores.

O layout também inclui fontes com estilo retrô e uma imagem decorativa ao lado do formulário, reforçando a estética nostálgica de fliperama.

---

## Instruções de Docker
Para facilitar a execução da API em ambiente isolado, criamos um arquivo específico com as instruções de uso do Docker.

Por favor, consulte o README_DOCKER.md para detalhes sobre como construir e rodar o container da API com Docker.

## Contribuindo

Contribuições são bem-vindas!  
Sinta-se à vontade para abrir issues ou pull requests para sugerir melhorias.

---

## Licença

Este projeto está licenciado sob a Licença MIT.
