FROM openjdk:11
MAINTAINER thegeekspad.com

RUN mkdir "/app"

WORKDIR /app

COPY target/

ENTRYPOINT ["top", "-b"]