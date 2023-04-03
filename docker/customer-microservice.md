# Customer MicroService Docker Commands

## Build the image from DockerFile

docker build -t thegeekspad/microshop-customer-microservice .

## Push the image to Docker Hub

docker push thegeekspad/microshop-customer-microservice

## Run container from the image

docker run -d -p 8080:80 --name customer-microservice thegeekspad/microshop-customer-microservice