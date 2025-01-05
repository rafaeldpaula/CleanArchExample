#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/CleanArchExample.WebApi/CleanArchExample.WebApi.csproj", "src/CleanArchExample.WebApi/"]
COPY ["src/CleanArchExample.IoC/CleanArchExample.IoC.csproj", "src/CleanArchExample.IoC/"]
COPY ["src/CleanArchExample.Domain/CleanArchExample.Domain.csproj", "src/CleanArchExample.Domain/"]
COPY ["src/CleanArchExample.Common/CleanArchExample.Common.csproj", "src/CleanArchExample.Common/"]
COPY ["src/CleanArchExample.Application/CleanArchExample.Application.csproj", "src/CleanArchExample.Application/"]
COPY ["src/CleanArchExample.ORM/CleanArchExample.ORM.csproj", "src/CleanArchExample.ORM/"]
RUN dotnet restore "./src/CleanArchExample.WebApi/CleanArchExample.WebApi.csproj"
COPY . .
WORKDIR "/src/src/CleanArchExample.WebApi"
RUN dotnet build "./CleanArchExample.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CleanArchExample.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanArchExample.WebApi.dll"]