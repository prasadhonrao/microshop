package com.microshop.microservice.order.models;

import lombok.Data;

import java.util.List;

@Data
public class OrderResponse {
    private String orderNumber;
    private List<OrderLineItemModel> orderLineItemModelList;
}

