FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Restore project
COPY Backend.csproj ./
RUN dotnet restore

# Copy all files to container and create production build
COPY . ./
RUN dotnet publish -c Release -o out

# This is the port the server uses
EXPOSE 80/tcp

# Label for GCR
LABEL org.opencontainers.image.source=https://github.com/IT2901-SINTEF01/backend

# Start server
FROM mcr.microsoft.com/dotnet/sdk:5.0
WORKDIR /app
COPY --from=build-env /app/out .
# Run on port 80 locally
ENTRYPOINT ["dotnet", "Backend.dll", "--urls", "http://*:80"] 