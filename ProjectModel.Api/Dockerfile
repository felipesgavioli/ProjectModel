#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ProjectModel.Api/ProjectModel.Api.csproj", "ProjectModel.Api/"]
RUN dotnet restore "ProjectModel.Api/ProjectModel.Api.csproj"
COPY . .
WORKDIR "/src/ProjectModel.Api"
RUN dotnet build "ProjectModel.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectModel.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/mssql/server:latest AS sqlserver
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=modelproject_test
EXPOSE 1433

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectModel.Api.dll"]