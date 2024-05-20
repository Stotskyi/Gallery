FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 5229

ENV ASPNETCORE_URLS=http://+:5229

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG configuration=Release
WORKDIR /src
COPY ["GalleryAPI/GalleryAPI.csproj", "GalleryAPI/"]
RUN dotnet restore "GalleryAPI\GalleryAPI.csproj"
COPY . .
WORKDIR "/src/GalleryAPI"
RUN dotnet build "GalleryAPI.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "GalleryAPI.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GalleryAPI.dll"]
