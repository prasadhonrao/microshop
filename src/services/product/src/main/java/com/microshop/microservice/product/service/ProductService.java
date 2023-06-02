package com.microshop.microservice.product.service;

import lombok.RequiredArgsConstructor;
import lombok.extern.slf4j.Slf4j;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.microshop.microservice.product.model.Product;
import com.microshop.microservice.product.repository.ProductRepository;

import java.util.List;

@Service
@RequiredArgsConstructor
@Slf4j
public class ProductService {

    @Autowired
    ProductRepository productRepository;

    public List<Product> list() {
        return productRepository.findAll();
    }

    public Product get(Integer productId) {
        return productRepository.findByProductId(productId);
    }

    public List<Product> get(String productName) {
        return productRepository.findByProductName(productName);
    }

    public Product create(Product product) {
        log.info("Product {} saved successfully", product.getProductId());
        // flush will actually store it in DB...only save will save it in local context
        return productRepository.saveAndFlush(product);
    }

    public void delete(Integer productId) {
        productRepository.deleteById(productId);
    }

    public Product update(Product product) {
        return productRepository.saveAndFlush(product);
    }
}

