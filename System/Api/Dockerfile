# See https://aka.ms/customizecontainer to learn how to customize your debug container 
# and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Salin file proyek untuk masing-masing komponen
COPY ["MasterParameter/MasterParameter.csproj", "MasterParameter/"]
COPY ["Common/Components/Components.csproj", "Common/Components/"]
COPY ["Common/Helpers/Helpers.csproj", "Common/Helpers/"]
COPY ["Common/Entities/Entities.csproj", "Common/Entities/"]
COPY ["Common/Services/Services.csproj", "Common/Services/"]
COPY ["Common/Utils/Utils.csproj", "Common/Utils/"]
COPY ["Repositories/Repositories.csproj", "Repositories/"]
COPY ["NonSSO/appsettings.json", "./appsettings.json"]

# Restore dependensi
RUN dotnet restore "MasterParameter/MasterParameter.csproj"

# Salin semua kode aplikasi
COPY . .

WORKDIR "/src/MasterParameter"

# Build proyek
RUN dotnet build "MasterParameter.csproj" -c Release -o /app/build

#publish
FROM build AS publish
RUN dotnet publish "MasterParameter.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MasterParameter.dll"]
