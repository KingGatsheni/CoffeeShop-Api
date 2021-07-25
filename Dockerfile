FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 4000

ENV ASPNETCORE_URLS=http://+:4000

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["cs-Api.csproj", "./"]
RUN dotnet restore "cs-Api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "cs-Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "cs-Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "cs-Api.dll"]