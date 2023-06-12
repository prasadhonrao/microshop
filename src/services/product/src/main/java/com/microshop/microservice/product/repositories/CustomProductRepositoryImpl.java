package com.microshop.microservice.product.repositories;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import jakarta.persistence.EntityManager;
import jakarta.persistence.PersistenceContext;

@Repository
public class CustomProductRepositoryImpl implements CustomProductRepository {

    @PersistenceContext
    @Autowired
    EntityManager entityManager;

    @Override
    public List<String> getCustomProducts() {
        return entityManager.createQuery("select p.productName from products p").getResultList();
    }
}
