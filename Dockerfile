# Utilizar la imagen oficial de .NET SDK para compilar
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app

# Copiar todo el código al contenedor
COPY . .

# Ir a la carpeta donde está el proyecto
WORKDIR /app/Discos-web/Discos-web

# Restaurar dependencias
RUN dotnet restore

# Compilar el proyecto
RUN dotnet publish -c Release -o /app/publish

# Usar una imagen más liviana para producción
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

WORKDIR /app

# Copiar los archivos publicados desde la etapa de build
COPY --from=build /app/publish .

# Exponer el puerto (puede variar según tu app)
EXPOSE 80

# Comando para correr la app
ENTRYPOINT ["dotnet", "Discos-web.dll"]
