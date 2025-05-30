# Imagem base para execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Imagem para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o .csproj e restaura as dependências
COPY ["CaixaFacil/CaixaFacil.csproj", "CaixaFacil/"]
RUN dotnet restore "CaixaFacil/CaixaFacil.csproj"

# Copia todo o código
COPY . .

# Define a pasta de trabalho para o build
WORKDIR "/src/CaixaFacil"
RUN dotnet build "CaixaFacil.csproj" -c Release -o /app/build

# Publica o projeto
FROM build AS publish
RUN dotnet publish "CaixaFacil.csproj" -c Release -o /app/publish

# Cria a imagem final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CaixaFacil.dll"]
