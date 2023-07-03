package com.microshop.microservice.order.entities;

import jakarta.persistence.*;
import lombok.*;

@NoArgsConstructor
@AllArgsConstructor
@Getter
@Setter
@Entity
@Table(name = "order_line_items")
public class OrderLineItem {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    private String productId;
    private float unitPrice;
    private int quantity;
    private float discount;

    @ManyToOne
    @JoinColumn(name = "order_number")
    private Order order;
}
