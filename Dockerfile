# Definición del nombre del proyecto
ARG PROJECT_NAME=zarape2

# 1. Capa de ejecución (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# 2. Capa de compilación (SDK)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG PROJECT_NAME
WORKDIR /src

# Copiar archivos de proyecto y restaurar dependencias
COPY ["${PROJECT_NAME}/${PROJECT_NAME}.csproj", "${PROJECT_NAME}/"]
RUN dotnet restore "${PROJECT_NAME}/${PROJECT_NAME}.csproj"

# Copiar todo el resto del código fuente
COPY . .

# Nos movemos firmemente a la carpeta del proyecto para los siguientes pasos
WORKDIR "/src/${PROJECT_NAME}"

# Compilar el proyecto
RUN dotnet build "${PROJECT_NAME}.csproj" -c Release -o /app/build

# 3. Capa de publicación
FROM build AS publish
ARG PROJECT_NAME
RUN dotnet publish "${PROJECT_NAME}.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 4. Configurar el contenedor final
FROM base AS final
ARG PROJECT_NAME
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["sh", "-c", "dotnet ${PROJECT_NAME}.dll"]
