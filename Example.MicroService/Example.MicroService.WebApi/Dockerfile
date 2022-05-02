FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Example.MicroService.WebApi/Example.MicroService.WebApi.csproj", "Example.MicroService.WebApi/"]
RUN dotnet restore "Example.MicroService.WebApi/Example.MicroService.WebApi.csproj"
COPY . .
WORKDIR "/src/Example.MicroService.WebApi"
RUN dotnet build "Example.MicroService.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Example.MicroService.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.MicroService.WebApi.dll"]
