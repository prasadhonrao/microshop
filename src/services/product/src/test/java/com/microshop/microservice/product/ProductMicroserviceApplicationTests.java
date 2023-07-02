package com.microshop.microservice.product;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.microshop.microservice.product.entities.Product;
import com.microshop.microservice.product.models.ProductRequest;
import com.microshop.microservice.product.repositories.ProductRepository;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.AutoConfigureMockMvc;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.MediaType;
import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.context.DynamicPropertyRegistry;
import org.springframework.test.context.DynamicPropertySource;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.request.MockMvcRequestBuilders;
import org.testcontainers.containers.MongoDBContainer;
import org.testcontainers.junit.jupiter.Container;
import org.testcontainers.junit.jupiter.Testcontainers;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.*;

@SpringBootTest
@Testcontainers
@AutoConfigureMockMvc
@DirtiesContext(classMode = DirtiesContext.ClassMode.BEFORE_EACH_TEST_METHOD)
class ProductMicroserviceApplicationTests {

	@Container
	static MongoDBContainer mongoDBContainer = new MongoDBContainer("mongo:latest");

	@Autowired
	private MockMvc mockMvc;

	@Autowired
	private ObjectMapper objectMapper;

	@Autowired
	private ProductRepository productRepository;
	@DynamicPropertySource
	static void setProperties(DynamicPropertyRegistry dynamicPropertyRegistry) {
		dynamicPropertyRegistry.add("spring.data.mongodb.uri", mongoDBContainer::getReplicaSetUrl);
	}
	@Test
	void shouldCreateProduct() throws Exception {
		ProductRequest productRequest = ProductRequest.builder()
				.productName("Test Product")
				.productPrice(9.99F)
				.categoryId(1L)
				.supplierId(1L)
				.discontinued(1)
				.build();
		String productRequestString = objectMapper.writeValueAsString(productRequest);
		mockMvc.perform(MockMvcRequestBuilders.post("/api/products")
					.contentType(MediaType.APPLICATION_JSON)
					.content(productRequestString))
				.andExpect(status().isCreated());

		Assertions.assertEquals(1, productRepository.findAll().size());

	}

	@Test
	void shouldGetProductById() throws Exception {
		ProductRequest productRequest = ProductRequest.builder()
				.productName("Test Product")
				.productPrice(9.99F)
				.categoryId(1L)
				.supplierId(1L)
				.discontinued(1)
				.build();
		String productRequestString = objectMapper.writeValueAsString(productRequest);
		mockMvc.perform(MockMvcRequestBuilders.post("/api/products")
				.contentType(MediaType.APPLICATION_JSON)
				.content(productRequestString));

		// Get the first product's ID from the database
		Product product = productRepository.findAll().get(0);
		String productId = product.getProductId();

		// Perform the GET request to the /api/products/{productId} endpoint
		mockMvc.perform(MockMvcRequestBuilders.get("/api/products/{productId}", productId))
				.andExpect(status().isOk())
				.andExpect(content().contentType(MediaType.APPLICATION_JSON))
				.andExpect(jsonPath("$.productId").value(productId))
				.andExpect(jsonPath("$.productName").value("Test Product"))
				.andExpect(jsonPath("$.productPrice").value(9.99F));
	}

}
