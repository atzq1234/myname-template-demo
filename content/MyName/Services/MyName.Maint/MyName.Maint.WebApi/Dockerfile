#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/MyName.Maint/MyName.Maint.WebApi/MyName.Maint.WebApi.csproj", "Services/MyName.Maint/MyName.Maint.WebApi/"]
COPY ["Services/Shared/MyName.Shared.WebApi/MyName.Shared.WebApi.csproj", "Services/Shared/MyName.Shared.WebApi/"]
COPY ["Infrastructures/MyName.Infra.Helper/MyName.Infra.Helper.csproj", "Infrastructures/MyName.Infra.Helper/"]
COPY ["Infrastructures/MyName.Infra.Core/MyName.Infra.Core.csproj", "Infrastructures/MyName.Infra.Core/"]
COPY ["Infrastructures/MyName.Infra.EventBus/MyName.Infra.EventBus.csproj", "Infrastructures/MyName.Infra.EventBus/"]
COPY ["Services/Shared/MyName.Shared.Application.Contracts/MyName.Shared.Application.Contracts.csproj", "Services/Shared/MyName.Shared.Application.Contracts/"]
COPY ["Services/Shared/MyName.Shared.Rpc/MyName.Shared.Rpc.csproj", "Services/Shared/MyName.Shared.Rpc/"]
COPY ["Services/Shared/MyName.Shared/MyName.Shared.csproj", "Services/Shared/MyName.Shared/"]
COPY ["Infrastructures/MyName.Infra.Caching/MyName.Infra.Caching.csproj", "Infrastructures/MyName.Infra.Caching/"]
COPY ["Infrastructures/MyName.Infra.Consul/MyName.Infra.Consul.csproj", "Infrastructures/MyName.Infra.Consul/"]
COPY ["Services/MyName.Maint/MyName.Maint.Application/MyName.Maint.Application.csproj", "Services/MyName.Maint/MyName.Maint.Application/"]
COPY ["Services/Shared/MyName.Shared.Application/MyName.Shared.Application.csproj", "Services/Shared/MyName.Shared.Application/"]
COPY ["Infrastructures/MyName.Infra.Mapper/MyName.Infra.Mapper.csproj", "Infrastructures/MyName.Infra.Mapper/"]
COPY ["Infrastructures/MyName.Infra.EfCore.MySQL/MyName.Infra.EfCore.MySQL.csproj", "Infrastructures/MyName.Infra.EfCore.MySQL/"]
COPY ["Infrastructures/MyName.Infra.Repository/MyName.Infra.Repository.csproj", "Infrastructures/MyName.Infra.Repository/"]
COPY ["Infrastructures/MyName.Infra.Dapper/MyName.Infra.Dapper.csproj", "Infrastructures/MyName.Infra.Dapper/"]
COPY ["Infrastructures/MyName.Infra.Mongo/MyName.Infra.Mongo.csproj", "Infrastructures/MyName.Infra.Mongo/"]
COPY ["Infrastructures/MyName.Infra.IdGenerater/MyName.Infra.IdGenerater.csproj", "Infrastructures/MyName.Infra.IdGenerater/"]
COPY ["Services/MyName.Maint/MyName.Maint.Application.Contracts/MyName.Maint.Application.Contracts.csproj", "Services/MyName.Maint/MyName.Maint.Application.Contracts/"]
COPY ["Services/MyName.Maint/MyName.Maint.Repository/MyName.Maint.Repository.csproj", "Services/MyName.Maint/MyName.Maint.Repository/"]
RUN dotnet restore "Services/MyName.Maint/MyName.Maint.WebApi/MyName.Maint.WebApi.csproj"
COPY . .
WORKDIR "/src/Services/MyName.Maint/MyName.Maint.WebApi"
RUN dotnet build "MyName.Maint.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyName.Maint.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyName.Maint.WebApi.dll"]