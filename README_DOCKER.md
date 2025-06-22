# ArcadeScore API

## Como rodar a API com Docker

### Requisitos

- Docker instalado e rodando na sua máquina  
- Docker Compose (normalmente já vem junto com Docker Desktop)  

---

### Dockerfile

O projeto possui um `Dockerfile` configurado para:

- Restaurar as dependências  
- Construir o projeto  
- Publicar a aplicação em modo Release  
- Criar a imagem final baseada na imagem oficial `mcr.microsoft.com/dotnet/aspnet:8.0`

Exemplo do Dockerfile usado:

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY . .

RUN dotnet restore "./ArcadeScore.Api/ArcadeScore.Api.csproj"
RUN dotnet build "./ArcadeScore.Api/ArcadeScore.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "./ArcadeScore.Api/ArcadeScore.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ArcadeScore.Api.dll"]
```

---

### docker-compose.yml

O arquivo `docker-compose.yml` define um serviço chamado `api` que constrói a imagem da API usando o Dockerfile acima e publica a porta 80 para a porta 8080 do host.

Exemplo:

```yaml
services:
  api:
    build:
      context: ./src/ArcadeScore.Api
      dockerfile: Dockerfile
      args:
        BUILD_CONFIGURATION: Release
    ports:
      - "8080:80"
```

---

### Como executar

1. Na raiz do projeto (onde está o arquivo `docker-compose.yml`), rode:

```bash
docker-compose up --build
```

2. Aguarde o processo de build e startup do container.

3. A API ficará disponível em: `http://localhost:8080`

---

### Observações

- Certifique-se que o caminho `context` no `docker-compose.yml` está correto (exemplo: `./src/ArcadeScore.Api`) para que o Docker consiga encontrar o projeto.  
- Se tiver problemas com cache, pode usar `docker-compose build --no-cache`.  
- Para rodar o container em segundo plano use: `docker-compose up -d`.  
