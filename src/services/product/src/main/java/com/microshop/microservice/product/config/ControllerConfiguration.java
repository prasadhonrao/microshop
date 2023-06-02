package com.microshop.microservice.product.config;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.ResponseStatus;

import jakarta.validation.ConstraintViolationException;

@ControllerAdvice
public class ControllerConfiguration {
    @ExceptionHandler(ConstraintViolationException.class)
    @ResponseStatus(value= HttpStatus.BAD_REQUEST, reason = "not a valid request payload")
    public void notValid() {
        System.out.println("bad request");
        // add your custom code here.
    }
}
