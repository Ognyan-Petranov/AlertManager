#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AlertManager.API/AlertManager.API.csproj", "AlertManager.API/"]
COPY ["AlertManager.Application/AlertManager.Application.csproj", "AlertManager.Application/"]
COPY ["AlertManager.Persistance.FE/AlertManager.Persistance.FE.csproj", "AlertManager.Persistance.FE/"]
COPY ["AlertManager.Domain/AlertManager.Domain.csproj", "AlertManager.Domain/"]
RUN dotnet restore "AlertManager.API/AlertManager.API.csproj"
COPY . .
WORKDIR "/src/AlertManager.API"
RUN dotnet build "AlertManager.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AlertManager.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AlertManager.API.dll"]