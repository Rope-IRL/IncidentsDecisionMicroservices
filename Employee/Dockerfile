FROM mcr.microsoft.com/dotnet/sdk:9.0 as build
WORKDIR /src

#Restore
COPY ["IncidentsDecisionMicroservices.EmployeeLogic.Api/IncidentsDecisionMicroservices.EmployeeLogic.Api.csproj", "IncidentsDecisionMicroservices.EmployeeLogic.Api/"]
COPY ["IncidentsDecisionMicroservices.EmployeeLogic.Application/IncidentsDecisionMicroservices.EmployeeLogic.Application.csproj", "IncidentsDecisionMicroservices.EmployeeLogic.Application/"]
COPY ["IncidentsDecisionMicroservices.EmployeeLogic.Core/IncidentsDecisionMicroservices.EmployeeLogic.Core.csproj", "IncidentsDecisionMicroservices.EmployeeLogic.Core/"]
COPY ["IncidentsDecisionMicroservices.EmployeeLogic.Persistence/IncidentsDecisionMicroservices.EmployeeLogic.Persistence.csproj", "IncidentsDecisionMicroservices.EmployeeLogic.Persistence/"]
COPY ["IncidentsDecisionMicroservices.EmployeeLogic.sln","./"]
RUN dotnet restore

#Build
COPY . .
RUN dotnet build -c Release -o /app/build

#Publish
FROM build as publish
RUN dotnet publish -c Release -o /app/publish

#Run
FROM mcr.microsoft.com/dotnet/aspnet:9.0
# ENV ASPNETCORE_HTTP_PORTS=29171
# EXPOSE 29171
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IncidentsDecisionMicroservices.EmployeeLogic.Api.dll"]