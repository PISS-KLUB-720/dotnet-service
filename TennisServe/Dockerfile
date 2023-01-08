FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY TennisServe.Web/TennisServe.Web.csproj TennisServe.Web/
COPY TennisServe.Database/TennisServe.Database.csproj TennisServe.Database/
RUN dotnet restore TennisServe.Web/TennisServe.Web.csproj
COPY . .
WORKDIR /src/TennisServe.Web
RUN dotnet build TennisServe.Web.csproj -c Release -o /app


FROM build AS publish
RUN dotnet publish TennisServe.Web.csproj -c Release -o /app


FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TennisServe.Web.dll"]
