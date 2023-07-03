package com.microshop.microservice.order.models;

import com.microshop.microservice.order.entities.Order;
import lombok.Data;

@Data
public class OrderLineItemModel {
    private String productId;
    private float unitPrice;
    private int quantity;
    private float discount;
}
