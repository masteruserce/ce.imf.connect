# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /src

# Copy solution
COPY ce.imf.connect.sln .

# Copy project files
COPY ce.imf.connect/ce.imf.connect.csproj ce.imf.connect/
COPY ce.imf.connect.application/ce.imf.connect.application.csproj ce.imf.connect.application/
COPY ce.imf.connect.infra/ce.imf.connect.infra.csproj ce.imf.connect.infra/
COPY ce.imf.connect.models/ce.imf.connect.models.csproj ce.imf.connect.models/
COPY ce.imf.connect.dtos/ce.imf.connect.comon.csproj ce.imf.connect.dtos/

# Restore dependencies
RUN dotnet restore ce.imf.connect.sln

# Copy everything else
COPY . .

# Publish API project
RUN dotnet publish ce.imf.connect/ce.imf.connect.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "ce.imf.connect.dll"]