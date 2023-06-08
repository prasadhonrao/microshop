package com.microshop.microservice.product.controller;

import org.springframework.beans.BeanUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import com.microshop.microservice.product.model.Product;
import com.microshop.microservice.product.service.ProductService;

import java.util.List;

@RestController
@RequestMapping("/product")
public class ProductController {

    @Autowired
    ProductService productService;

    @GetMapping
    public ResponseEntity<List<Product>> list() {
        return new ResponseEntity<List<Product>>(productService.list(), HttpStatus.OK);
    }

    @GetMapping(value = "{productId}")
    public ResponseEntity<Product> get(@PathVariable Integer productId) {
        var product = productService.get(productId);
        if (product == null) {
            return new ResponseEntity<>(HttpStatus.NOT_FOUND);
        }
        return new ResponseEntity<Product>(product, HttpStatus.OK);
    }

//    @GetMapping(value = "{productName}")
//    public List<Product> get(@PathVariable String productName) {
//        var products = productService.get(productName);
//        return products;
//    }

    @PostMapping
    public Product create(@RequestBody final Product product) {#
        return productService.create(product);
    }

    @DeleteMapping(value = "{productId}")
    public void delete(@PathVariable Integer productId) {
        if (productService.get(productId) == null) {
            throw new RuntimeException("Product not found");
        }
        productService.delete(productId);
    }

    @RequestMapping(value = "{productId}", method = RequestMethod.PUT)
    public Product update(@PathVariable Integer productId, @RequestBody Product product) {

        if (productService.get(productId) == null) {
            throw new RuntimeException("Product not found");
        }

        if (product.getProductId() != null && product.getProductId() != productId) {
            throw new RuntimeException("Product id doesn't match");
        }

        Product existingProduct = productService.get(productId);
        BeanUtils.copyProperties(product, existingProduct, "product_id");
        return productService.update(existingProduct);
    }
}
