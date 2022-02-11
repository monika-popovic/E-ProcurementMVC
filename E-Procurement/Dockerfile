#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["E-Procurement/E-Procurement.csproj", "E-Procurement/"]
RUN dotnet restore "E-Procurement/E-Procurement.csproj"
COPY . .
WORKDIR "/src/E-Procurement"
RUN dotnet build "E-Procurement.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "E-Procurement.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "E-Procurement.dll"]