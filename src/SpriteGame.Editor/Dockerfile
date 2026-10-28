FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SpriteGame.Editor/SpriteGame.Editor.csproj", "SpriteGame.Editor/"]
COPY ["SpriteGame.Persistence/SpriteGame.Persistence.csproj", "SpriteGame.Persistence/"]
COPY ["SpriteGame.Domain/SpriteGame.Domain.csproj", "SpriteGame.Domain/"]
COPY ["SpriteGame.ServiceDefaults/SpriteGame.ServiceDefaults.csproj", "SpriteGame.ServiceDefaults/"]
RUN dotnet restore "SpriteGame.Editor/SpriteGame.Editor.csproj"
COPY . .
WORKDIR "/src/SpriteGame.Editor"
RUN dotnet build "./SpriteGame.Editor.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SpriteGame.Editor.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpriteGame.Editor.dll"]
