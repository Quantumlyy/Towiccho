FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
EXPOSE 1201

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["Towiccho.Server/Towiccho.Server.csproj", "Towiccho.Server/"]

RUN dotnet restore "Towiccho.Server/Towiccho.Server.csproj"
COPY . .
WORKDIR "/src/Towiccho.Server"
RUN dotnet build "Towiccho.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Towiccho.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Towiccho.Server.dll"]