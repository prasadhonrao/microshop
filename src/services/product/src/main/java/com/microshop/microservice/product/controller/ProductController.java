package com.microshop.microservice.product.controller;

import org.springframework.beans.BeanUtils;
import org.springframework.beans.factory.annotation.Autowired;
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
    public List<Product> list() {
        return productService.list();
    }

    @GetMapping(value = "{productId}")
    public Product get(@PathVariable Integer productId) {
        var product = productService.get(productId);
        return product;
    }

    @GetMapping(value = "{productName}")
    public List<Product> get(@PathVariable String productName) {
        var products = productService.get(productName);
        return products;
    }

    @PostMapping
    public Product create(@RequestBody final Product product) {
        return productService.create(product);
    }

    @DeleteMapping(value = "{productId}")
    public void delete(@PathVariable Integer productId) {
        productService.delete(productId);
    }

    @RequestMapping(value = "{productId}", method = RequestMethod.PUT)
    public Product update(@PathVariable Integer productId, @RequestBody Product product) {
        Product existingProduct = productService.get(productId);
        BeanUtils.copyProperties(product, existingProduct, "product_id");
        return productService.update(existingProduct);
    }
}
