# Getting Started


docker network create order-api-dev-network

docker run --name order-db-dev-host --net order-api-dev-network -e MYSQL_ROOT_PASSWORD=mysql -p 3307:3306 -d mysql


docker run -d `
--name order-api-dev `
--net order-api-dev-network `
-p 7000:8080 `
-e DB_HOST=order-db-dev-host `
-e DB_PORT=3306 `
-e DB_USERNAME=root `
-e DB_PASSWORD=mysql `
-e DB_NAME=order_db_dev `
thegeekspad/microshop-order-microservice

