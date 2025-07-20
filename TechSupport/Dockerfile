FROM mcr.microsoft.com/dotnet/sdk:9.0 as build
WORKDIR /src

#Restore
COPY ["IncidentsDecisionMicroservices.TechSupportLogic.Api/IncidentsDecisionMicroservices.TechSupportLogic.Api.csproj", "IncidentsDecisionMicroservices.TechSupportLogic.Api/"]
COPY ["IncidentsDecisionMicroservices.TechSupportLogic.Application/IncidentsDecisionMicroservices.TechSupportLogic.Application.csproj", "IncidentsDecisionMicroservices.TechSupportLogic.Application/"]
COPY ["IncidentsDecisionMicroservices.TechSupportLogic.Core/IncidentsDecisionMicroservices.TechSupportLogic.Core.csproj", "IncidentsDecisionMicroservices.TechSupportLogic.Core/"]
COPY ["IncidentsDecisionMicroservices.TechSupportLogic.Persistence/IncidentsDecisionMicroservices.TechSupportLogic.Persistence.csproj", "IncidentsDecisionMicroservices.TechSupportLogic.Persistence/"]
COPY ["IncidentsDecisionMicroservices.TechSupportLogic.sln","./"]
RUN dotnet restore

#Build
COPY . .
RUN dotnet build -c Release -o /app/build

#Publish
FROM build as publish
RUN dotnet publish -c Release -o /app/publish

#Run
FROM mcr.microsoft.com/dotnet/aspnet:9.0
# ENV ASPNETCORE_HTTP_PORTS=29172
# EXPOSE 29172
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IncidentsDecisionMicroservices.TechSupportLogic.Api.dll"]