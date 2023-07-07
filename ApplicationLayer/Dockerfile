#build
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
#EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ApplicationLayer/ApplicationLayer.csproj", "ApplicationLayer/"]
COPY ["Api.Abstractions/Api.Requests.Abstractions.csproj", "Api.Abstractions/"]
COPY ["AspNetCore.APIController.Abstractions/AspNetCore.ApiController.Abstractions.csproj", "AspNetCore.APIController.Abstractions/"]
COPY ["AspNetCore.ApiController.Extensions/AspNetCore.ApiController.Extensions.csproj", "AspNetCore.ApiController.Extensions/"]
COPY ["DatabaseTransactions/Database.Transactions.csproj", "DatabaseTransactions/"]
COPY ["Database.Abstraction/Database.Abstraction.csproj", "Database.Abstraction/"]
COPY ["Database.N/Database.N.csproj", "Database.N/"]
COPY ["Domain.Abstractions/Domain.Abstractions.csproj", "Domain.Abstractions/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Domain.Infrastructure/Command.Abstractions.csproj", "Domain.Infrastructure/"]
COPY ["Queries.Abstractions/Queries.Abstractions.csproj", "Queries.Abstractions/"]
COPY ["Persistence/Persistence.csproj", "Persistence/"]
RUN dotnet restore "ApplicationLayer/ApplicationLayer.csproj"

COPY . .
WORKDIR "/src/ApplicationLayer"
RUN dotnet build "ApplicationLayer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApplicationLayer.csproj" -c Release -o /app/publish /p:UseAppHost=false --no-restore

#serve
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApplicationLayer.dll"]