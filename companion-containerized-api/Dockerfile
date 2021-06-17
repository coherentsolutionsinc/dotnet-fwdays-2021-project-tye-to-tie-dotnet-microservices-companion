FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["companion-containerized-api.csproj", "companion-containerized-api/"]
RUN dotnet restore "companion-containerized-api/companion-containerized-api.csproj"

WORKDIR /src/companion-containerized-api
COPY . .
RUN dotnet build "companion-containerized-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "companion-containerized-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "companion-containerized-api.dll"]
