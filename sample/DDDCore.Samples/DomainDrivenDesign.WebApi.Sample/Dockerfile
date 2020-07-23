#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DDDCore.Samples/DomainDrivenDesign.WebApi.Sample/DomainDrivenDesign.WebApi.Sample.csproj", "DDDCore.Samples/DomainDrivenDesign.WebApi.Sample/"]
RUN dotnet restore "DDDCore.Samples/DomainDrivenDesign.WebApi.Sample/DomainDrivenDesign.WebApi.Sample.csproj"
COPY . .
WORKDIR "/src/DDDCore.Samples/DomainDrivenDesign.WebApi.Sample"
RUN dotnet build "DomainDrivenDesign.WebApi.Sample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DomainDrivenDesign.WebApi.Sample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DomainDrivenDesign.WebApi.Sample.dll"]