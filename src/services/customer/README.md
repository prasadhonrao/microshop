# Customer Microservice API Documentation

## Introduction

This documentation provides an overview of the Customer Microservice API, which is responsible for managing customer information. The API allows users to perform operations such as adding new customers, updating existing customers, deleting customers, and finding customers based on specific conditions.

## Setup Instructions

docker run -d --name microshop-customer-db -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=M!cr@sh@p" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest

## Base URL

The base URL for all API endpoints is: `https://your-domain.com/api/customers`

## Authentication

Authentication is required to access the Customer Microservice API. Please refer to the authentication documentation for details on how to obtain an access token.

## Error Handling

The API follows standard HTTP status codes to indicate the success or failure of a request. In case of an error, the response will include an error message in the body along with the appropriate HTTP status code.

## Endpoints

### Get All Customers

Retrieves a list of all customers.

**Endpoint**: `GET /api/customers`

#### Parameters

None

#### Response

- `200 OK` - Returns an array of customer objects in the response body.
- `401 Unauthorized` - If the request is not authenticated.

### Get Customer by ID

Retrieves a specific customer by their ID.

**Endpoint**: `GET /api/customers/{id}`

#### Parameters

- `id` (path parameter) - The ID of the customer to retrieve.

#### Response

- `200 OK` - Returns the customer object in the response body.
- `404 Not Found` - If the customer with the specified ID does not exist.
- `401 Unauthorized` - If the request is not authenticated.

### Add New Customer

Adds a new customer.

**Endpoint**: `POST /api/customers`

#### Request Body

- `name` (string, required) - The name of the customer.
- `email` (string, required) - The email address of the customer.
- `phone` (string) - The phone number of the customer.

#### Response

- `201 Created` - Returns the newly created customer object in the response body.
- `400 Bad Request` - If the request body is missing required fields.
- `401 Unauthorized` - If the request is not authenticated.

### Update Customer

Updates an existing customer.

**Endpoint**: `PUT /api/customers/{id}`

#### Parameters

- `id` (path parameter) - The ID of the customer to update.

#### Request Body

- `name` (string, required) - The updated name of the customer.
- `email` (string, required) - The updated email address of the customer.
- `phone` (string) - The updated phone number of the customer.

#### Response

- `200 OK` - Returns the updated customer object in the response body.
- `404 Not Found` - If the customer with the specified ID does not exist.
- `400 Bad Request` - If the request body is missing required fields.
- `401 Unauthorized` - If the request is not authenticated.

### Delete Customer

Deletes a customer.

**Endpoint**: `DELETE /api/customers/{id}`

#### Parameters

- `id` (path parameter) - The ID of the customer to delete.

#### Response

- `204 No Content` - If the customer is successfully deleted.
- `404 Not Found` - If the customer with the specified ID does not exist.
- `401 Unauthorized` - If the request is not authenticated.
