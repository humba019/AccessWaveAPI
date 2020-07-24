#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["AccessWave/AccessWave.csproj", "AccessWave/"]
RUN dotnet restore "AccessWave/AccessWave.csproj"
COPY ./AccessWave ./AccessWave
WORKDIR "/src/AccessWave"
RUN dotnet build "AccessWave.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AccessWave.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN useradd -m myappuser
USER myappuser

CMD ASPNETCORE_URLS="http://*:$PORT" dotnet AccessWave.dll