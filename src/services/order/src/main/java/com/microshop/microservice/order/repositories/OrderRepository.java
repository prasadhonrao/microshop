package com.microshop.microservice.order.repositories;

import com.microshop.microservice.order.entities.Order;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Optional;

public interface OrderRepository extends JpaRepository<Order, Long> {
    Optional<Order> findByOrderNumber(String orderNumber);
    Optional<Order> findByCustomerId(int customerId);

}
