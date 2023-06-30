package com.microshop.microservice.product.repositories;


import com.microshop.microservice.product.entities.Product;
import org.springframework.data.mongodb.repository.MongoRepository;

import java.util.List;

public interface ProductRepository extends MongoRepository<Product, String> {
}