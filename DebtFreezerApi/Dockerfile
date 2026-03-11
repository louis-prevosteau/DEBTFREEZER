FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# Installer MySQL client
RUN apt-get update && apt-get install -y default-mysql-client

# Copier le csproj et restaurer
COPY *.csproj ./
RUN dotnet restore

# Copier tout le code
COPY . ./

# Exposer le port
EXPOSE 8080

# Lancer le serveur dev avec hot reload
CMD ["dotnet", "watch", "run", "--urls=http://0.0.0.0:8080"]