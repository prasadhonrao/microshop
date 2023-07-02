package com.microshop.microservice.product.models;

import lombok.Builder;
import lombok.Data;

@Data
@Builder
public class ProductResponse {
    private String productId;
    private String productName;
    private Long supplierId;
    private Long categoryId;
    private Float productPrice;
    private Integer discontinued;
}

