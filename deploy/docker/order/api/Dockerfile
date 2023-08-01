# Use a base image with Java and Maven pre-installed
FROM maven:3.8.4-openjdk-17-slim AS build

# Set the working directory in the container
WORKDIR /app

# Copy the Maven project file
COPY pom.xml .

# Download the project dependencies
RUN mvn dependency:go-offline -B

# Copy the application source code
COPY src ./src

# Build the application
RUN mvn package -DskipTests

# Create a new container for the application runtime
FROM openjdk:17-jdk-slim AS final

# Set the working directory in the container
WORKDIR /app

# Copy the JAR file from the build container
COPY --from=build /app/target/order-microservice*.jar ./order-microservice.jar

# Expose the application port
EXPOSE 8080

# Start the application
CMD ["java", "-jar", "order-microservice.jar"]
