#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 3333

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["SystemService.API/SystemService.API.csproj", "SystemService.API/"]
COPY ["SystemService.Infrastructure/SystemService.Infrastructure.csproj", "SystemService.Infrastructure/"]
COPY ["SystemService.Domain/SystemService.Domain.csproj", "SystemService.Domain/"]
COPY ["EshopSolution.Extentsions/EshopSolution.Extensions.csproj", "EshopSolution.Extentsions/"]
RUN dotnet restore "SystemService.API/SystemService.API.csproj"
COPY . .
WORKDIR "/src/SystemService.API"
RUN dotnet build "SystemService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SystemService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SystemService.API.dll"]