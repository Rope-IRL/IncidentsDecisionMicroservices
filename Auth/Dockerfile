FROM mcr.microsoft.com/dotnet/sdk:9.0 as build
WORKDIR /src

#Restore
COPY ["IncidentsDecisionMicroservices.Auth.Api/IncidentsDecisionMicroservices.Auth.Api.csproj", "IncidentsDecisionMicroservices.Auth.Api/"]
COPY ["IncidentsDecisionMicroservices.Auth.Application/IncidentsDecisionMicroservices.Auth.Application.csproj", "IncidentsDecisionMicroservices.Auth.Application/"]
COPY ["IncidentsDecisionMicroservices.Auth.Core/IncidentsDecisionMicroservices.Auth.Core.csproj", "IncidentsDecisionMicroservices.Auth.Core/"]
COPY ["IncidentsDecisionMicroservices.Auth.Persistence/IncidentsDecisionMicroservices.Auth.Persistence.csproj", "IncidentsDecisionMicroservices.Auth.Persistence/"]
COPY ["IncidentsDecisionMicroservices.Auth.sln","./"]
RUN dotnet restore

#Build
COPY . .
RUN dotnet build -c Release -o /app/build

#Publish
FROM build as publish
RUN dotnet publish -c Release -o /app/publish

#Run
FROM mcr.microsoft.com/dotnet/aspnet:9.0
ENV ASPNETCORE_HTTP_PORTS=29171
EXPOSE 29171
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IncidentsDecisionMicroservices.Auth.Api.dll"]