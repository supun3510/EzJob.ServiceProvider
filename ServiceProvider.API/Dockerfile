#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EzPay.ServiceProvider.Api/EzPay.ServiceProvider.Api.csproj", "EzPay.ServiceProvider.Api/"]
RUN dotnet restore "EzPay.ServiceProvider.Api/EzPay.ServiceProvider.Api.csproj"
COPY . .
WORKDIR "/src/EzPay.ServiceProvider.Api"
RUN dotnet build "EzPay.ServiceProvider.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EzPay.ServiceProvider.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EzPay.ServiceProvider.Api.dll"]