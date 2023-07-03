package com.microshop.microservice.order.entities;

import jakarta.persistence.*;
import lombok.*;

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
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "order")
    private List<OrderLineItem> orderLineItemList;
}
