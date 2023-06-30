package com.microshop.microservice.product.services;

import com.microshop.microservice.product.ProductNotFoundException;
import com.microshop.microservice.product.models.ProductRequest;
import com.microshop.microservice.product.models.ProductResponse;
import lombok.RequiredArgsConstructor;
import lombok.extern.slf4j.Slf4j;

import org.springframework.stereotype.Service;

import com.microshop.microservice.product.entities.Product;
import com.microshop.microservice.product.repositories.ProductRepository;

import java.util.List;
import java.util.Optional;

@Service
@RequiredArgsConstructor
@Slf4j
public class ProductService {

    private final ProductRepository productRepository;

    public List<ProductResponse> getAllProducts() {
        var products = productRepository.findAll();
        var productResponse = products.stream().map(p -> mapToProductResponse(p));
        return productResponse.toList();
    }

    private ProductResponse mapToProductResponse(Product p) {
        return ProductResponse.builder()
                .productId((p.getProductId()))
                .productName(p.getProductName())
                .productPrice(p.getProductPrice())
                .supplierId(p.getSupplierId())
                .categoryId(p.getCategoryId())
                .discontinued(p.getDiscontinued())
                .build();
    }

    public ProductResponse getProductById(String id) {
        Product product = productRepository.findById(id)
                .orElseThrow(() -> new ProductNotFoundException("Product not found"));
        return this.mapToProductResponse(product);
    }

    public ProductResponse createProduct(ProductRequest productRequest) {
        Product product = Product.builder()
                .productName(productRequest.getProductName())
                .productPrice(productRequest.getProductPrice())
                .supplierId(productRequest.getSupplierId())
                .categoryId(productRequest.getCategoryId())
                .discontinued(productRequest.getDiscontinued())
                .build();
        var savedProduct = productRepository.save(product);
        log.info("Product {} saved successfully", savedProduct.getProductId());
        return mapToProductResponse(savedProduct);
    }

    public void deleteProduct(String id) {
        Optional<Product> optionalProduct = productRepository.findById(id);
        if (optionalProduct.isPresent()) {
            productRepository.delete(optionalProduct.get());
        } else {
            throw new ProductNotFoundException("Product not found with ID: " + id);
        }
    }

    public Product updateProduct(String id, Product product) {
        Optional<Product> optionalProduct = productRepository.findById(id);
        if (optionalProduct.isPresent()) {
            product.setProductId(id);
            return productRepository.save(product);
        } else {
            throw new ProductNotFoundException("Product not found with ID: " + id);
        }
    }
}

