package com.microshop.microservice.order.entities;

import jakarta.persistence.*;
import lombok.*;

import java.time.LocalDate;
import java.util.List;

@Entity
@Table(name = "orders")
@NoArgsConstructor
@AllArgsConstructor
@Getter
@Setter
public class Order {
    @Id
    @Column(name = "order_number")
    private String orderNumber;

    @Column(name = "customer_id")
    private int customerId;

    @Column(name = "order_date")
    private LocalDate orderDate;

    @Column(name = "order_amount")
    private float orderAmount;

    @OneToMany(cascade = CascadeType.ALL, mappedBy = "order")
    private List<OrderLineItem> orderLineItemList;
}
