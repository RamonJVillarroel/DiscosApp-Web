# Usar una imagen de .NET SDK para compilar
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Crear carpeta de la app
WORKDIR /app

# Copiar todo
COPY . .

# Ir a la carpeta donde realmente está el proyecto
WORKDIR /app/Discos-web/

# Restaurar dependencias
RUN dotnet restore

# Compilar el proyecto
RUN dotnet publish /app/Discos-web/Discos-web.csproj -c Release -o /app/publish

# Usar una imagen más liviana para producción
FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /app
COPY --from=build /app/publish .

# Arrancar la app
ENTRYPOINT ["dotnet", "Discos-web.dll"]
