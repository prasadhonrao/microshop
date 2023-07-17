# Stage 1: Build the project
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy the project files
COPY ./*.csproj ./
RUN dotnet restore

# Copy the rest of the project files and build the project
COPY . .
RUN dotnet publish -c Release -o out

# Stage 2: Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Expose the necessary port
EXPOSE 80

# Set the entry point for the application
ENTRYPOINT ["dotnet", "Customer.MicroService.dll"]
