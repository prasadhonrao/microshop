package com.microshop.microservice.product.models;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class ProductRequest {
    private String productName;
    private Long supplierId;
    private Long categoryId;
    private Float productPrice;
    private Integer discontinued;
}
