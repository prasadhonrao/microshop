package com.microshop.microservice.product.services;

import com.microshop.microservice.product.ProductNotFoundException;
import lombok.RequiredArgsConstructor;
import lombok.extern.slf4j.Slf4j;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.microshop.microservice.product.models.Product;
import com.microshop.microservice.product.repositories.ProductRepository;

import java.util.List;
import java.util.Optional;

@Service
@RequiredArgsConstructor
@Slf4j
public class ProductService {

    @Autowired
    ProductRepository productRepository;

    public List<Product> list() {
        return productRepository.findAll();
    }

    public Product getProductById(Integer id) {
        Optional<Product> optionalProduct = productRepository.findById(id);
        if (optionalProduct.isPresent()) {
            return optionalProduct.get();
        } else {
            throw new ProductNotFoundException("Product not found with ID: " + id);
        }
    }

    public List<Product> get(String productName) {
        return productRepository.findByProductName(productName);
    }

    public Product create(Product product) {
        log.info("Product {} saved successfully", product.getProductId());
        // flush will actually store it in DB...only save will save it in local context
        return productRepository.saveAndFlush(product);
    }

    public void deleteProduct(Integer id) {
        Optional<Product> optionalProduct = productRepository.findById(id);
        if (optionalProduct.isPresent()) {
            productRepository.delete(optionalProduct.get());
        } else {
            throw new ProductNotFoundException("Product not found with ID: " + id);
        }
    }

    public Product updateProduct(Integer id, Product product) {
        Optional<Product> optionalProduct = productRepository.findById(id);
        if (optionalProduct.isPresent()) {
            product.setProductId(id);
            return productRepository.save(product);
        } else {
            throw new ProductNotFoundException("Product not found with ID: " + id);
        }
    }
}

