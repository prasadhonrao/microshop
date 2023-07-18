package com.microshop.microservice.order.models;

import lombok.Data;

import java.time.LocalDate;
import java.util.List;

@Data
public class OrderResponse {
    private String orderNumber;
    private int customerId;
    private LocalDate orderDate;
    private float orderAmount;
    private List<OrderLineItemModel> orderLineItemModelList;
}

