package com.microshop.microservice.product.controllers;

import com.microshop.microservice.product.ProductNotFoundException;
import org.springframework.beans.BeanUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import com.microshop.microservice.product.models.Product;
import com.microshop.microservice.product.services.ProductService;

import java.util.List;

@RestController
@RequestMapping("/product")
public class ProductsController {

    @Autowired
    ProductService productService;

    @GetMapping
    @ResponseStatus(HttpStatus.OK)
    public ResponseEntity<List<Product>> list() {
        return new ResponseEntity<List<Product>>(productService.list(), HttpStatus.OK);
    }

    @GetMapping(value = "{productId}")
    @ResponseStatus(HttpStatus.OK)
    public ResponseEntity<Product> get(@PathVariable Integer productId) {
        try {
            var product = productService.getProductById(productId);
            return new ResponseEntity<Product>(product, HttpStatus.OK);
        } catch (ProductNotFoundException e) {
            return ResponseEntity.notFound().build();
        } catch (RuntimeException rex) {
            return new ResponseEntity<>(HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }

    @PostMapping
    @ResponseStatus(HttpStatus.CREATED)
    public ResponseEntity<Product> create(@RequestBody final Product product) {
        Product createdProduct = productService.create(product);
        return ResponseEntity.status(HttpStatus.CREATED).body(createdProduct);
    }


    @DeleteMapping("/{productId}")
    public ResponseEntity<Void> deleteProduct(@PathVariable Integer productId) {
        try {
            productService.deleteProduct(productId);
            return ResponseEntity.noContent().build();
        } catch (ProductNotFoundException e) {
            return ResponseEntity.notFound().build();
        }
    }

    @RequestMapping(value = "{productId}", method = RequestMethod.PUT)
    @ResponseStatus(HttpStatus.OK)
    public ResponseEntity<Product> update(@PathVariable Integer productId, @RequestBody Product product) {
        try {
            Product updatedProduct = productService.updateProduct(productId, product);
            return ResponseEntity.ok(updatedProduct);
        } catch (ProductNotFoundException e) {
            return ResponseEntity.notFound().build();
        }
    }
}
