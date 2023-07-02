package com.microshop.microservice.product.controllers;

import com.microshop.microservice.product.ProductNotFoundException;
import com.microshop.microservice.product.models.ProductRequest;
import com.microshop.microservice.product.models.ProductResponse;
import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import com.microshop.microservice.product.entities.Product;
import com.microshop.microservice.product.services.ProductService;

import java.util.List;

@RestController
@RequiredArgsConstructor
@RequestMapping("/api/products")
public class ProductsController {

    private final ProductService productService;

    @GetMapping
    @ResponseStatus(HttpStatus.OK)
    public ResponseEntity<List<ProductResponse>> getProducts() {
        try {
            List<ProductResponse> products = productService.getAllProducts();
            return ResponseEntity.ok(products);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).build();
        }
    }

    @GetMapping(value = "{productId}")
    @ResponseStatus(HttpStatus.OK)
    public ResponseEntity<ProductResponse> getProduct(@PathVariable String productId) {
        try {
            var product = productService.getProductById(productId);
            return new ResponseEntity<ProductResponse>(product, HttpStatus.OK);
        } catch (ProductNotFoundException e) {
            return ResponseEntity.notFound().build();
        } catch (Exception rex) {
            return new ResponseEntity<>(HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }

    @PostMapping
    @ResponseStatus(HttpStatus.CREATED)
    public ResponseEntity<ProductResponse> createProduct(@RequestBody final ProductRequest productRequest) {
        try {
            ProductResponse productResponse = productService.createProduct(productRequest);
            return ResponseEntity.status(HttpStatus.CREATED).body(productResponse);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).build();
        }
    }

    @DeleteMapping("/{productId}")
    @ResponseStatus(HttpStatus.NO_CONTENT)
    public ResponseEntity<Void> deleteProduct(@PathVariable String productId) {
        try {
            productService.deleteProduct(productId);
            return ResponseEntity.noContent().build();
        } catch (ProductNotFoundException e) {
            return ResponseEntity.notFound().build();
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).build();
        }
    }

    @RequestMapping(value = "{productId}", method = RequestMethod.PUT)
    @ResponseStatus(HttpStatus.OK)
    public ResponseEntity<Product> updateProduct(@PathVariable String productId, @RequestBody Product product) {
        try {
            Product updatedProduct = productService.updateProduct(productId, product);
            return ResponseEntity.ok(updatedProduct);
        } catch (ProductNotFoundException e) {
            return ResponseEntity.notFound().build();
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).build();
        }
    }
}
