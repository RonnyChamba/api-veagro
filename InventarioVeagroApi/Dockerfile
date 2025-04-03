# Etapa base (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Instalar Chromium en la imagen base
RUN apt-get update && apt-get install -y chromium

# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia solo el .csproj primero para aprovechar el cache de Docker
COPY ["InventarioVeagroApi.csproj", "./"]

# Restaura paquetes de NuGet
RUN dotnet restore "./InventarioVeagroApi.csproj"

# Copia el resto del código
COPY . .

# Establece el directorio correcto
WORKDIR "/src"

# Compila el proyecto
RUN dotnet build "./InventarioVeagroApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Etapa de publicación
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./InventarioVeagroApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etapa final
FROM base AS final

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InventarioVeagroApi.dll"]
