-- DROP DATABASE order_db_dc;

CREATE DATABASE order_db_dc;

USE order_db_dc;

CREATE TABLE orders (
  order_number varchar(255) NOT NULL,
  customer_id int,
  order_date date,
  order_amount decimal(10, 2),
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

INSERT INTO orders (order_number, customer_id, order_date, order_amount)
VALUES ('ORD-001', 1, '2023-07-01', 100.00),
      ('ORD-002', 2, '2023-07-02', 30.00),
      ('ORD-003', 1, '2023-07-03', 100.00);

INSERT INTO order_line_items (order_number, product_id, unit_price, quantity, discount)
VALUES ('ORD-001', 'PROD-001', 10.00, 10, 0.0),
      ('ORD-001', 'PROD-002', 20.00, 3, 0.0),
      ('ORD-002', 'PROD-003', 15.00, 2, 0.0),
      ('ORD-003', 'PROD-001', 10.00, 10, 0.0);
