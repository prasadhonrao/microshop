# Build stage
FROM maven:3.9-eclipse-temurin-17 as build
RUN mkdir /app
WORKDIR /app
COPY pom.xml .
# RUN mvn dependency:resolve
COPY src src
RUN --mount=type=cache,target=/root/.m2 mvn package -DskipTests

# Package stage
FROM eclipse-temurin:17-jre
COPY --from=build /app/target/discovery-server.jar discovery-server.jar
EXPOSE 8080
ENTRYPOINT ["java","-jar","/discovery-server.jar"]