FROM mcr.microsoft.com/dotnet/sdk:9.0 as build
WORKDIR /src

#Restore
COPY ["IncidentsDecisionMicroservices.Notifications.Api/IncidentsDecisionMicroservices.Notifications.Api.csproj", "IncidentsDecisionMicroservices.Notifications.Api/"]
COPY ["IncidentsDecisionMicroservices.Notifications.Application/IncidentsDecisionMicroservices.Notifications.Application.csproj", "IncidentsDecisionMicroservices.Notifications.Application/"]
COPY ["IncidentsDecisionMicroservices.Notifications.Core/IncidentsDecisionMicroservices.Notifications.Core.csproj", "IncidentsDecisionMicroservices.Notifications.Core/"]
COPY ["IncidentsDecisionMicroservices.Notifications.Persistence/IncidentsDecisionMicroservices.Notifications.Persistence.csproj", "IncidentsDecisionMicroservices.Notifications.Persistence/"]
COPY ["IncidentsDecisionMicroservices.Notifications.sln","./"]
RUN dotnet restore

#Build
COPY . .
RUN dotnet build -c Release -o /app/build

#Publish
FROM build as publish
RUN dotnet publish -c Release -o /app/publish

#Run
FROM mcr.microsoft.com/dotnet/aspnet:9.0
# ENV ASPNETCORE_HTTP_PORTS=29174
# EXPOSE 29174
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IncidentsDecisionMicroservices.Notifications.Api.dll"]