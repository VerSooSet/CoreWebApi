FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
EXPOSE 80
EXPOSE 443
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
Copy . .
RUN dotnet restore "ApplicationLayer/ApplicationLayer.csproj"

COPY . .
WORKDIR "/src/ApplicationLayer"
RUN dotnet build "ApplicationLayer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApplicationLayer.csproj" -c Release -o /app/publish /p:UseAppHost=false
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "ApplicationLayer.dll"]