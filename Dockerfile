FROM mcr.microsoft.com/dotnet/sdk:6.0
ARG BUILD_CONFIGURATION=Debug
ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_USE_POLLING_FILE_WATCHER=true  
ENV ASPNETCORE_URLS=http://+:80  
WORKDIR /app
COPY . .

RUN dotnet build /app/DesafioApi/DesafioApi.sln
RUN dotnet publish /app/DesafioApi/DesafioApi.sln  -c Release -o out
EXPOSE 80
ENTRYPOINT ["dotnet", "out/DesafioApi.dll"]