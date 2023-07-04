package com.microshop.microservice.order;

import com.microshop.microservice.order.entities.Order;
import com.microshop.microservice.order.repositories.OrderRepository;
import jakarta.annotation.PostConstruct;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Profile;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

@Component
@Profile("dev")
public class DataLoader {
    private final OrderRepository orderRepository;

    @Autowired
    public DataLoader(OrderRepository orderRepository) {
        this.orderRepository = orderRepository;
    }

    @PostConstruct
    public void loadDummyData() {
        // Load dummy data here
        List<Order> dummyOrders = createDummyOrders();
        orderRepository.saveAll(dummyOrders);
    }

    private List<Order> createDummyOrders() {
        List<Order> dummyOrders = new ArrayList<>();

        // Create and add dummy orders to the list
        // Add your desired dummy data here
        Order order1 = new Order();
        order1.setOrderNumber("ORD-001");
        // Set other properties

        Order order2 = new Order();
        order2.setOrderNumber("ORD-002");
        // Set other properties

        dummyOrders.add(order1);
        dummyOrders.add(order2);

        return dummyOrders;
    }
}
