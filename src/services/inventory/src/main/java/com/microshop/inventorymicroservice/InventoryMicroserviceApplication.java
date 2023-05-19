package com.microshop.inventorymicroservice;

import com.microshop.inventorymicroservice.model.Inventory;
import com.microshop.inventorymicroservice.repository.InventoryRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
// import org.springframework.cloud.client.discovery.EnableDiscoveryClient;

@SpringBootApplication
// @EnableDiscoveryClient
@RequiredArgsConstructor
public class InventoryMicroserviceApplication implements CommandLineRunner {

	private final InventoryRepository inventoryRepository;

	public static void main(String[] args) {
		SpringApplication.run(InventoryMicroserviceApplication.class, args);
	}

	@Override
	public void run(String... args) throws Exception {
		Inventory iPhone = new Inventory();
		iPhone.setSkuCode("iPhone");
		iPhone.setQuantity(100);

		Inventory iPhone13Red = new Inventory();
		iPhone13Red.setSkuCode("iPhone13Red");
		iPhone13Red.setQuantity(0);

		inventoryRepository.save(iPhone);
		inventoryRepository.save(iPhone13Red);
	}
}
