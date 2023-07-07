#build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
workdir /source
copy . .
RUN dotnet restore "./ApplicationLayer/ApplicationLayer.csproj"
RUN dotnet publish "./ApplicationLayer/ApplicationLayer.csproj"  -c release -o /app --no-restore

#serve
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
workdir /app
copy --from=build /app ./

EXPOSE 5000
ENTRYPOINT ["dotnet", "ApplicationLayer.dll"]