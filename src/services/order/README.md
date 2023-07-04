# Getting Started


docker network create order-network

docker run --name orderdb --net order-network -e MYSQL_ROOT_PASSWORD=mysql -p 3307:3306 -d mysql


docker run -d `
--name orderapi `
--net order-network `
-p 9090:8080 `
-e MYSQL_HOST=orderdb `
-e MYSQL_PORT=3306 `
-e MYSQL_USER=root `
-e MYSQL_PASSWORD=mysql `
-e MYSQL_DB=order_db `
thegeekspad/microshop-order-microservice

