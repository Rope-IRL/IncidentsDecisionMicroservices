FROM mcr.microsoft.com/dotnet/sdk:9.0 as build
WORKDIR /src

#Restore
COPY ["IncidentsDecisionMicroservices.Incidents.Api/IncidentsDecisionMicroservices.Incidents.Api.csproj", "IncidentsDecisionMicroservices.Incidents.Api/"]
COPY ["IncidentsDecisionMicroservices.Incidents.Application/IncidentsDecisionMicroservices.Incidents.Application.csproj", "IncidentsDecisionMicroservices.Incidents.Application/"]
COPY ["IncidentsDecisionMicroservices.Incidents.Core/IncidentsDecisionMicroservices.Incidents.Core.csproj", "IncidentsDecisionMicroservices.Incidents.Core/"]
COPY ["IncidentsDecisionMicroservices.Incidents.Persistence/IncidentsDecisionMicroservices.Incidents.Persistence.csproj", "IncidentsDecisionMicroservices.Incidents.Persistence/"]
COPY ["IncidentsDecisionMicroservices.Incidents.sln","./"]
RUN dotnet restore

#Build
COPY . .
RUN dotnet build -c Release -o /app/build

#Publish
FROM build as publish
RUN dotnet publish -c Release -o /app/publish

#Run
FROM mcr.microsoft.com/dotnet/aspnet:9.0
# ENV ASPNETCORE_HTTP_PORTS=29170
# EXPOSE 29170
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IncidentsDecisionMicroservices.Incidents.Api.dll"]