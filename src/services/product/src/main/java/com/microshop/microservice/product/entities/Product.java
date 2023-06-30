package com.microshop.microservice.product.entities;

import lombok.*;

import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;

@Document(value = "product")
@Data
@AllArgsConstructor
@NoArgsConstructor
@ToString
@Builder
public class Product {
    @Id
    private String productId;

    private String productName;

    private Long supplierId;

    private Long categoryId;

    private Float productPrice;

    private Integer discontinued;

}
