FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5122

ENV ASPNETCORE_URLS=http://+:5122

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/LibraryApp.WebApi/LibraryApp.WebApi.csproj", "src/LibraryApp.WebApi/"]
RUN dotnet restore "src/LibraryApp.WebApi/LibraryApp.WebApi.csproj"
COPY . .
WORKDIR "/src/src/LibraryApp.WebApi"
RUN dotnet build "LibraryApp.WebApi.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "LibraryApp.WebApi.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibraryApp.WebApi.dll"]
