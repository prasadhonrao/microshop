package com.microshop.microservice.product.models;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.math.BigDecimal;

@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class ProductResponse {
    private String productId;
    private String productName;
    private Long supplierId;
    private Long categoryId;
    private Float productPrice;
    private Integer discontinued;
}

