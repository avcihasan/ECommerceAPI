FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Presentation/ECommerceAPI.API/ECommerceAPI.API.csproj", "Presentation/ECommerceAPI.API/"]
COPY ["Core/ECommerceAPI.Application/ECommerceAPI.Application.csproj", "Core/ECommerceAPI.Application/"]
COPY ["Core/ECommerceAPI.Domain/ECommerceAPI.Domain.csproj", "Core/ECommerceAPI.Domain/"]
COPY ["Infrastructure/ECommerceAPI.Infrastructure/ECommerceAPI.Infrastructure.csproj", "Infrastructure/ECommerceAPI.Infrastructure/"]
COPY ["Infrastructure/ECommerceAPI.Persistence/ECommerceAPI.Persistence.csproj", "Infrastructure/ECommerceAPI.Persistence/"]
COPY ["Infrastructure/ECommerceAPI.SignalR/ECommerceAPI.SignalR.csproj", "Infrastructure/ECommerceAPI.SignalR/"]
RUN dotnet restore "Presentation/ECommerceAPI.API/ECommerceAPI.API.csproj"
COPY . .
WORKDIR "/src/Presentation/ECommerceAPI.API"
RUN dotnet build "ECommerceAPI.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ECommerceAPI.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerceAPI.API.dll"]