FROM mcr.microsoft.com/dotnet/sdk:6.0.201 AS build-env
WORKDIR /app

# Restore project
COPY Backend.csproj ./
RUN dotnet restore

# Copy all files to container and create production build
COPY . ./
RUN dotnet publish Backend.csproj -c Release -o out

# This is the port the server uses
EXPOSE 80/tcp

# Start server
FROM mcr.microsoft.com/dotnet/sdk:6.0.201

# Label for GCR
LABEL org.opencontainers.image.source=https://github.com/it2901-sintef01/backend

WORKDIR /app
COPY --from=build-env /app/out .
# Run on port 80 locally
ENTRYPOINT ["dotnet", "Backend.dll", "--urls", "http://*:80"] 
