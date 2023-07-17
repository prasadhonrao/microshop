# Customer Microservice API Documentation

## Introduction

This documentation provides an overview of the Customer Microservice API, which is responsible for managing customer information. The API allows users to perform operations such as adding new customers, updating existing customers, deleting customers, and finding customers based on specific conditions.

## Local DB Setup Instructions

docker network create microshop-network

docker run -d --rm --name customer-db \
  -p 1433:1433 \
  --network microshop-network \
  -e "ACCEPT_EULA=Y" \
  -e "MSSQL_SA_PASSWORD=M!cr@sh@pDEV" \ 
  thegeekspad/microshop-customer-microservice-db

docker run -d --rm --name customer-ms \
  -p 8080:80 \
  --network microshop-network \
  -e ASPNETCORE_ENVIRONMENT=Production \
  -e SA_PASSWORD=M!cr@sh@pDEV \
  thegeekspad/microshop-customer-microservice

