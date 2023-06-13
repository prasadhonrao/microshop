# Stage 1: Build the application
FROM maven:3.8.4-openjdk-17-slim AS build
WORKDIR /app
COPY pom.xml .
RUN mvn dependency:go-offline
COPY src ./src
RUN mvn clean package -DskipTests

# Stage 2: Create the production-ready image
FROM openjdk:17 AS final
WORKDIR /app
COPY --from=build /app/target/product-microservice*.jar .
CMD ["java", "-jar", "product-microservice*.jar"]
