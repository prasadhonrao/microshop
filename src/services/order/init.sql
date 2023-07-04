-- DROP DATABASE order_db;

-- CREATE DATABASE order_db;

USE order_db;

CREATE TABLE orders (
  order_number varchar(255) NOT NULL,
  PRIMARY KEY (order_number)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


CREATE TABLE order_line_items (
  id bigint(20) NOT NULL AUTO_INCREMENT,
  order_number varchar(255) NOT NULL,
  product_id varchar(255) DEFAULT NULL,
  unit_price int(11) DEFAULT NULL,
  quantity int(11) DEFAULT NULL,
  discount float DEFAULT NULL,
  PRIMARY KEY (id),
  CONSTRAINT FK_ORDER_LINE_ITEM_ORDER FOREIGN KEY (order_number) REFERENCES orders (order_number) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

