package com.microshop.microservice.order.services;

import com.microshop.microservice.order.entities.Order;
import com.microshop.microservice.order.entities.OrderLineItem;
import com.microshop.microservice.order.exceptions.NotFoundException;
import com.microshop.microservice.order.models.OrderLineItemModel;
import com.microshop.microservice.order.models.OrderRequest;
import com.microshop.microservice.order.models.OrderResponse;
import com.microshop.microservice.order.repositories.OrderRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;
import java.util.Optional;
import java.util.UUID;
import java.util.stream.Collectors;

@Service
@RequiredArgsConstructor
@Transactional
public class OrderService {

    private final OrderRepository orderRepository;

    public List<OrderResponse> getOrders() {
        List<Order> orders = orderRepository.findAll();
        return orders.stream()
                .map(this::mapToOrderResponse)
                .collect(Collectors.toList());
    }

    public OrderResponse getOrder(String orderNumber) {
        Order order = orderRepository.findByOrderNumber(orderNumber)
                .orElseThrow(() -> new NotFoundException("Order not found with order number: " + orderNumber));

        return mapToOrderResponse(order);
    }

    public OrderResponse getOrdersByCustomerId(int customerId) {
        Order order = orderRepository.findByCustomerId(customerId)
                .orElseThrow(() -> new NotFoundException("Order not found with customer number: " + customerId));

        return mapToOrderResponse(order);
    }

    public OrderResponse createOrder(OrderRequest orderRequest) {
        Order order = new Order();
        order.setOrderNumber(UUID.randomUUID().toString());
        order.setCustomerId(orderRequest.getCustomerId());
        order.setOrderDate(orderRequest.getOrderDate());
        order.setOrderAmount(orderRequest.getOrderAmount());

        List<OrderLineItem> orderLineItems = orderRequest.getOrderLineItemModelList()
                .stream()
                .map(model -> mapToOrderLineItem(model, order))
                .toList();

        order.setOrderLineItemList(orderLineItems);
        var savedOder = orderRepository.save(order);
        return mapToOrderResponse(savedOder);
    }

    public void deleteOrder(String orderNumber) throws NotFoundException {
        Optional<Order> orderOptional = orderRepository.findByOrderNumber(orderNumber);
        if (orderOptional.isEmpty()) {
            throw new NotFoundException("Order not found");
        }
        Order order = orderOptional.get();
        orderRepository.delete(order);
    }

    private OrderLineItem mapToOrderLineItem(OrderLineItemModel model, Order order) {
        OrderLineItem orderLineItem = new OrderLineItem();
        orderLineItem.setUnitPrice(model.getUnitPrice());
        orderLineItem.setDiscount(model.getDiscount());
        orderLineItem.setQuantity(model.getQuantity());
        orderLineItem.setProductId(model.getProductId());
        orderLineItem.setOrder(order); // Set the order object
        return orderLineItem;
    }

    private OrderResponse mapToOrderResponse(Order order) {
        OrderResponse response = new OrderResponse();
        response.setOrderNumber(order.getOrderNumber());
        response.setCustomerId(order.getCustomerId());
        response.setOrderDate(order.getOrderDate());
        response.setOrderAmount(order.getOrderAmount());

        List<OrderLineItemModel> lineItems = order.getOrderLineItemList().stream()
                .map(this::mapToOrderLineItemModel)
                .collect(Collectors.toList());
        response.setOrderLineItemModelList(lineItems);
        return response;
    }

    private OrderLineItemModel mapToOrderLineItemModel(OrderLineItem orderLineItem) {
        OrderLineItemModel model = new OrderLineItemModel();
        model.setProductId(orderLineItem.getProductId());
        model.setUnitPrice(orderLineItem.getUnitPrice());
        model.setQuantity(orderLineItem.getQuantity());
        model.setDiscount(orderLineItem.getDiscount());
        return model;
    }
    
}
