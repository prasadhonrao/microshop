package com.microshop.microservice.inventory.controller;

import java.util.HashMap;
import java.util.Map;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class HomeController {
    @Value("${version}")
    private String version;

    @GetMapping
    @RequestMapping("/")
    public Map<String, String> getVersion() {
        var map = new HashMap<String, String>();
        map.put("version", version);
        return map;
    }
}
