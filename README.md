# Microshop

Cross-platform microservices and container based application that runs on Linux, Windows and macOS

## Application Services

| Service | Technology |
| ------------- | ------------- |
| Customer MicroService | ASP.NET Web API Core + SQL Server + EF|
| Product MicroService | Java 17 + SpringBoot 3.1 + MongoDB |
| Order MicroService | Java 17 + SpringBoot 3.1 + MySQL |
| Inventory MicroService | TBD |
| Notification MicroService | Python Flask |

## Infrastructure Services

| Service | Technology |
| ------------- | ------------- |
| API Gateway | Spring Cloud |
| Discovery Server | Spring Cloud |

## Feature - Implementation Mapping

| Service | DevOps | ORM | Logging | Unit Testing | Integration Testing | Open API
| ------------- | ------------- | ------------- | ------------- | ------------- | ------------- | ------------- |
| Customer | GitHub Action | Entity Framework, AutoMapper | Seq | XUnit | XUnit | Swagger |
| Product | GitHub Action | JPA | TBD | JUnit | TBD | TBD |

## Build Status (GitHub Actions)

| Image | Status |
| ------------- | ------------- |
| Customer MicroService | [![Customer MicroService Build and Deploy to Docker Hub](https://github.com/prasadhonrao/microshop/actions/workflows/customer-microservice.yml/badge.svg?branch=main)](https://github.com/prasadhonrao/microshop/actions/workflows/customer-microservice.yml)
| Product MicroService | [![Product MicroService Build and Deploy to Docker Hub](https://github.com/prasadhonrao/microshop/actions/workflows/product-microservice.yml/badge.svg?branch=main)](https://github.com/prasadhonrao/microshop/actions/workflows/product-microservice.yml)
| Order MicroService | [![Order MicroService Build and Deploy to Docker Hub](https://github.com/prasadhonrao/microshop/actions/workflows/order-microservice.yml/badge.svg?branch=main)](https://github.com/prasadhonrao/microshop/actions/workflows/order-microservice.yml)
