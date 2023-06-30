package com.microshop.microservice.product.controllers;

import java.util.HashMap;
import java.util.Map;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/api/products")
public class HomeController {
    @Value("${api.version}")
    private String apiVersion;

    @GetMapping
    @RequestMapping("/version")
    public Map<String, String> getApiVersion() {
        var map = new HashMap<String, String>();
        map.put("api.version", apiVersion);
        return map;
    }
}
