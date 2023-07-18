package com.microshop.microservice.order.controllers;


import com.microshop.microservice.order.exceptions.NotFoundException;
import com.microshop.microservice.order.models.OrderRequest;
import com.microshop.microservice.order.models.OrderResponse;
import com.microshop.microservice.order.services.OrderService;
import lombok.RequiredArgsConstructor;

import org.slf4j.LoggerFactory;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.util.List;

@RequiredArgsConstructor
@RestController
@RequestMapping("/api/orders")
public class OrdersController {

    private final Logger logger = LoggerFactory.getLogger(OrdersController.class);

    private final OrderService orderService;
    @PostMapping
    @ResponseStatus(HttpStatus.CREATED)
    public ResponseEntity<OrderResponse> placeOrder(@RequestBody OrderRequest orderRequest) {
        try {
            logger.info("Placing order: {}", orderRequest);
            OrderResponse orderResponse = orderService.createOrder(orderRequest);
            return ResponseEntity.status(HttpStatus.CREATED).body(orderResponse);
        } catch (Exception ex) {
            logger.error("Error placing order", ex);
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).build();
        }
    }

    @GetMapping
    @ResponseStatus(HttpStatus.OK)
    public ResponseEntity<List<OrderResponse>> getOrders() {
        try {
            logger.info("Getting all orders");
            var orders = orderService.getOrders();
            return ResponseEntity.ok(orders);
        } catch (NotFoundException e) {
            return ResponseEntity.notFound().build();
        } catch (Exception ex) {
            logger.error("Error getting orders",ex);
            return new ResponseEntity<>(HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }

    @GetMapping("/{orderNumber}")
    @ResponseStatus(HttpStatus.OK)
    public ResponseEntity<OrderResponse> getOrder(@PathVariable String orderNumber) {
        try {
            logger.info("Getting all order details for order {}", orderNumber);
            var order = orderService.getOrder(orderNumber);
            return new ResponseEntity<OrderResponse>(order, HttpStatus.OK);
        } catch (NotFoundException e) {
            return ResponseEntity.notFound().build();
        } catch (Exception ex) {
            logger.error("Error getting a order",ex);
            return new ResponseEntity<>(HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }

    @GetMapping("/customer/{customerId}")
    @ResponseStatus(HttpStatus.OK)
    public ResponseEntity<List<OrderResponse>> getOrdersByCustomerId(@PathVariable int customerId) {
        try {
            var orders = orderService.getOrdersByCustomerId(customerId);
            return ResponseEntity.ok(orders);
        } catch (NotFoundException e) {
            return ResponseEntity.notFound().build();
        } catch (Exception rex) {
            return new ResponseEntity<>(HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }

    @DeleteMapping("/{orderNumber}")
    @ResponseStatus(HttpStatus.NO_CONTENT)
    public ResponseEntity<String> deleteOrder(@PathVariable String orderNumber) {
        try {
            orderService.deleteOrder(orderNumber);
            return ResponseEntity.noContent().build();
        } catch (NotFoundException e) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body(e.getMessage());
        } catch (Exception rex) {
            return new ResponseEntity<>(HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }

}

