FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /src

COPY . .

RUN dotnet restore ce.imf.connect/ce.imf.connect.csproj
RUN dotnet publish ce.imf.connect/ce.imf.connect.csproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview
WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "ce.imf.connect.dll"]