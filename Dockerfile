FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FilmaiOutAPI.csproj", ""]
RUN dotnet restore "./FilmaiOutAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./FilmaiOutAPI.csproj" -c Release -o /app/Build

FROM build AS publish
RUN dotnet publish "./FilmaiOutAPI.csproj" -c Release -o /app/Publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/Publish .

ENTRYPOINT ["dotnet", "FilmaiOutAPI.dll"]
