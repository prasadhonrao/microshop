package com.microshop.microservice.product.repositories;


import com.microshop.microservice.product.entities.Product;
import org.springframework.data.mongodb.repository.MongoRepository;

public interface ProductRepository extends MongoRepository<Product, String> {
}