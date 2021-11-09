#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["PhotoStock.Sales.WebApp/PhotoStock.Sales.WebApp.csproj", "PhotoStock.Sales.WebApp/"]
COPY ["Photostock.Sales.Infrastructure/PhotoStock.Sales.Infrastructure.csproj", "Photostock.Sales.Infrastructure/"]
COPY ["DDD.Base/DDD.Base.csproj", "DDD.Base/"]
COPY ["PhotoStock.Sales.Query/PhotoStock.Sales.Query.csproj", "PhotoStock.Sales.Query/"]
COPY ["PhotoStock.Sales.Domain/PhotoStock.Sales.Domain.csproj", "PhotoStock.Sales.Domain/"]
COPY ["PhotoStock.SharedKernel/PhotoStock.SharedKernel.csproj", "PhotoStock.SharedKernel/"]
COPY ["PhotoStock.Sales.Application/PhotoStock.Sales.Application.csproj", "PhotoStock.Sales.Application/"]
COPY ["PhotoStock.System/PhotoStock.System.csproj", "PhotoStock.System/"]
RUN dotnet restore "PhotoStock.Sales.WebApp/PhotoStock.Sales.WebApp.csproj"
COPY . .
WORKDIR "/src/PhotoStock.Sales.WebApp"
RUN dotnet build "PhotoStock.Sales.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PhotoStock.Sales.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PhotoStock.Sales.WebApp.dll"]
