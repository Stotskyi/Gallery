# Build Stage
FROM mcr.microsoft.com/dotnet/sdk AS build-env
WORKDIR /app
EXPOSE 8080

# Copy the solution file and restore dependencies
COPY . ./GalleryAPI/
WORKDIR /app/GalleryAPI
RUN dotnet restore

# Build and publish
RUN dotnet publish -c Release -o out

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet AS runtime
WORKDIR /app
COPY --from=build-env /app/GalleryAPI/out ./

# Define entrypoint
ENTRYPOINT ["dotnet", "GalleryAPI.dll"]
