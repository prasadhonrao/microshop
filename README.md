# Microshop

Microshop is a cross-platform, microservice-based application designed to serve as a fully functional and scalable ecommerce platform. Built on modern technologies and best practices, Microshop offers a comprehensive solution for online retail businesses seeking to establish a robust and efficient online presence.

Key Features:
- **Microservices Architecture:** Microshop follows a modular architecture, breaking down complex functionalities into independent microservices. Each microservice is responsible for a specific aspect of the application, facilitating maintainability, scalability, and fault isolation.

- **Scalability and Flexibility:** The application is designed to scale effortlessly as business demands grow. Microservices allow individual components to be deployed independently, enabling seamless expansion and enhanced performance.

- **Dockerized Containers:** Microshop leverages containerization using Docker, ensuring consistency across various environments and simplifying the deployment process.

- **Kubernetes Orchestration:** The application is designed to be deployed and managed on Kubernetes, providing a powerful and flexible orchestration solution for containerized microservices.

- **RESTful APIs:** Microshop offers RESTful APIs for communication between microservices, enabling secure and efficient data exchange.

- **User-friendly Interface:** The frontend of Microshop is designed with a focus on user experience, providing an intuitive and engaging interface for customers to browse products, place orders, and manage their accounts.

- **Authentication and Security:** Robust authentication mechanisms and data encryption ensure that user data and transactions remain secure and protected.

- **Order Processing and Payment Integration:** Microshop includes a streamlined order processing system and supports integration with popular payment gateways, enabling seamless and secure payment transactions.

- **Product Catalog and Inventory Management:** The application offers comprehensive product catalog management, allowing administrators to efficiently manage product details, categories, and stock levels.

- **Order Tracking and Customer Support:** Customers can track their orders in real-time, and the application facilitates seamless customer support through integrated communication channels.

Microshop provides an open-source foundation for ecommerce businesses to build upon and customize as per their specific requirements. Whether setting up a small boutique store or a large-scale online retail platform, Microshop empowers businesses to achieve their ecommerce goals efficiently and effectively.

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
