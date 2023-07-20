package com.microshop.microservice.order.config;

import com.rabbitmq.client.BuiltinExchangeType;
import com.rabbitmq.client.Channel;
import com.rabbitmq.client.Connection;
import com.rabbitmq.client.ConnectionFactory;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Configuration;

import javax.annotation.PostConstruct;
import java.io.IOException;
import java.util.concurrent.TimeoutException;


@Configuration
public class RabbitMQConfig {

    @Value("${spring.rabbitmq.host}")
    private String rabbitMQHost;

    @Value("${spring.rabbitmq.port}")
    private int rabbitMQPort;

    private static final String NEW_ORDER_QUEUE_NAME = "new_order_queue";
    private static final String ORDER_EXCHANGE_NAME = "order_exchange";

    @PostConstruct
    public void setupQueue() {
        ConnectionFactory factory = new ConnectionFactory();
        factory.setHost(rabbitMQHost);
        factory.setPort(rabbitMQPort);

        try (Connection connection = factory.newConnection();
             Channel channel = connection.createChannel()) {
            // Declare the exchange
            channel.exchangeDeclare(ORDER_EXCHANGE_NAME, BuiltinExchangeType.FANOUT);

            // Declare the queue
            channel.queueDeclare(NEW_ORDER_QUEUE_NAME, true, false, false, null);

            // Bind the queue to the exchange
            channel.queueBind(NEW_ORDER_QUEUE_NAME, ORDER_EXCHANGE_NAME, "");

            // Add any additional queue setup or bindings here if needed
        } catch (IOException | TimeoutException e) {
            // Handle exceptions or log errors if any
            e.printStackTrace();
        }
    }
}