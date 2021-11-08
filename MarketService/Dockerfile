FROM mcr.microsoft.com/dotnet/aspnet:3.1-focal AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:3.1-focal AS build
WORKDIR /src
COPY ["MarketService/MarketService.csproj", "MarketService/"]
RUN dotnet restore "MarketService/MarketService.csproj"
COPY . .
RUN dotnet build "MarketService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MarketService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MarketService.dll"]
