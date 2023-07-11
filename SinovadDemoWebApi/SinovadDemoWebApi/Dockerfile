#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SinovadDemoWebApi/SinovadDemoWebApi.csproj", "SinovadDemoWebApi/"]
COPY ["Application/SinovadDemo.Application.DTO/SinovadDemo.Application.DTO.csproj", "Application/SinovadDemo.Application.DTO/"]
COPY ["Application/SinovadDemo.Application.Interface/SinovadDemo.Application.Interface.csproj", "Application/SinovadDemo.Application.Interface/"]
COPY ["Domain/SinovadDemo.Domain/SinovadDemo.Domain.csproj", "Domain/SinovadDemo.Domain/"]
COPY ["Transversal/SinovadDemo.Transversal.Collection/SinovadDemo.Transversal.Collection.csproj", "Transversal/SinovadDemo.Transversal.Collection/"]
COPY ["Transversal/SinovadDemo.Transversal.Common/SinovadDemo.Transversal.Common.csproj", "Transversal/SinovadDemo.Transversal.Common/"]
COPY ["Application/SinovadDemo.Application.Main/SinovadDemo.Application.Main.csproj", "Application/SinovadDemo.Application.Main/"]
COPY ["Transversal/SinovadDemo.Transversal.Logger/SinovadDemo.Transversal.Logger.csproj", "Transversal/SinovadDemo.Transversal.Logger/"]
COPY ["Application/SinovadDemo.Application.Configuration/SinovadDemo.Application.Configuration.csproj", "Application/SinovadDemo.Application.Configuration/"]
COPY ["Application/SinovadDemo.Application.Enums/SinovadDemo.Application.Enums.csproj", "Application/SinovadDemo.Application.Enums/"]
COPY ["Transversal/SinovadDemo.Transversal.Mapping/SinovadDemo.Transversal.Mapping.csproj", "Transversal/SinovadDemo.Transversal.Mapping/"]
COPY ["Application/SinovadDemo.Application.Builder/SinovadDemo.Application.Builder.csproj", "Application/SinovadDemo.Application.Builder/"]
COPY ["Application/SinovadDemo.Application.Encryption/SinovadDemo.Application.Encryption.csproj", "Application/SinovadDemo.Application.Encryption/"]
COPY ["Application/SinovadDemo.Application.Helpers/SinovadDemo.Application.Helpers.csproj", "Application/SinovadDemo.Application.Helpers/"]
COPY ["Application/SinovadDemo.Application.Shared/SinovadDemo.Application.Shared.csproj", "Application/SinovadDemo.Application.Shared/"]
COPY ["Application/SinovadDemo.Application.Validator/SinovadDemo.Application.Validator.csproj", "Application/SinovadDemo.Application.Validator/"]
COPY ["Infrastructure/Data/SinovadDemo.Infrastructure.Data.csproj", "Infrastructure/Data/"]
COPY ["Infrastructure/SinovadDemo.Infrastructure.Repository/SinovadDemo.Infrastructure.Repository.csproj", "Infrastructure/SinovadDemo.Infrastructure.Repository/"]
COPY ["Transversal/SinovadDemo.Transversal.Paging/SinovadDemo.Transversal.Paging.csproj", "Transversal/SinovadDemo.Transversal.Paging/"]
RUN dotnet restore "SinovadDemoWebApi/SinovadDemoWebApi.csproj"
COPY . .
WORKDIR "/src/SinovadDemoWebApi"
RUN dotnet build "SinovadDemoWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SinovadDemoWebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SinovadDemoWebApi.dll"]