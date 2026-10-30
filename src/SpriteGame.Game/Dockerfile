FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SpriteGame.Game/SpriteGame.Game.csproj", "SpriteGame.Game/"]
COPY ["SpriteGame.Persistence/SpriteGame.Persistence.csproj", "SpriteGame.Persistence/"]
COPY ["SpriteGame.Domain/SpriteGame.Domain.csproj", "SpriteGame.Domain/"]
COPY ["SpriteGame.ServiceDefaults/SpriteGame.ServiceDefaults.csproj", "SpriteGame.ServiceDefaults/"]
RUN dotnet restore "SpriteGame.Game/SpriteGame.Game.csproj"
COPY . .
WORKDIR "/src/SpriteGame.Game"
RUN dotnet build "./SpriteGame.Game.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SpriteGame.Game.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
RUN mkdir -p /assets && chown -R $APP_UID:$APP_UID /assets
USER $APP_UID:$APP_UID
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpriteGame.Game.dll"]
