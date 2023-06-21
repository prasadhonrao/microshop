# Customer Microservice API Documentation

## Introduction

This documentation provides an overview of the Customer Microservice API, which is responsible for managing customer information. The API allows users to perform operations such as adding new customers, updating existing customers, deleting customers, and finding customers based on specific conditions.

## Local DB Setup Instructions

docker run -d --rm --name MicroshopCustomerDb -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=M!cr@sh@p" -p 1431:1433 -d mcr.microsoft.com/mssql/server:2022-latest

