package com.microshop.microservice.order;

import com.microshop.microservice.order.entities.Order;
import com.microshop.microservice.order.entities.OrderLineItem;
import com.microshop.microservice.order.repositories.OrderRepository;
import jakarta.annotation.PostConstruct;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Profile;
import org.springframework.stereotype.Component;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

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
        // Clean existing data
        orderRepository.deleteAll();

        // Load dummy data here
        List<Order> dummyOrders = createDummyOrders();
        orderRepository.saveAll(dummyOrders);
    }

    private List<Order> createDummyOrders() {
        List<Order> dummyOrders = new ArrayList<>();

        // Create and add dummy orders to the list
        // Add your desired dummy data here
        Order order1 = new Order();
        order1.setOrderNumber(UUID.randomUUID().toString());
        order1.setCustomerId(1);
        order1.setOrderDate(LocalDate.of(2023, 7, 1));
        order1.setOrderAmount(100.0F);
        dummyOrders.add(order1);

        Order order2 = new Order();
        order2.setOrderNumber(UUID.randomUUID().toString());
        order2.setCustomerId(2);
        order2.setOrderDate(LocalDate.of(2023, 7, 2));
        order2.setOrderAmount(200.0F);
        dummyOrders.add(order2);

        Order order3 = new Order();
        order3.setOrderNumber(UUID.randomUUID().toString());
        order3.setCustomerId(3);
        order3.setOrderDate(LocalDate.of(2023, 7, 3));
        order3.setOrderAmount(300.0F);
        dummyOrders.add(order3);


        List<OrderLineItem> dummyLineItems = new ArrayList<>();

        OrderLineItem lineItem1 = new OrderLineItem();
        lineItem1.setProductId("PROD-001");
        lineItem1.setUnitPrice(10.0f);
        lineItem1.setQuantity(2);
        lineItem1.setDiscount(0.0f);
        lineItem1.setOrder(order1);
        dummyLineItems.add(lineItem1);

        OrderLineItem lineItem2 = new OrderLineItem();
        lineItem2.setProductId("PROD-002");
        lineItem2.setUnitPrice(20.0f);
        lineItem2.setQuantity(1);
        lineItem2.setDiscount(0.1f);
        lineItem2.setOrder(order1);
        dummyLineItems.add(lineItem2);

        order1.setOrderLineItemList(dummyLineItems);

        return dummyOrders;
    }
}
