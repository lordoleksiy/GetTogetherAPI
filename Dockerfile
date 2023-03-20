FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
ARG PROJECT_PORT
WORKDIR /app
EXPOSE $PROJECT_PORT

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY GetTogether.WEBAPI/*.csproj ./GetTogether.WebAPI/
COPY GetTogether.DAL/*.csproj ./GetTogether.DAL/
COPY GetTogether.Common/*.csproj ./GetTogether.Common/
COPY GetTogether.BLL/*.csproj ./GetTogether.BLL/

RUN dotnet restore GetTogether.WebAPI/GetTogether.WEBAPI.csproj
COPY . .
WORKDIR /src/GetTogether.WEBAPI
RUN dotnet publish -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GetTogether.WEBAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:5051
ENTRYPOINT ["dotnet", "GetTogether.WEBAPI.dll"]