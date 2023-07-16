FROM mcr.microsoft.com/mssql/server:2022-latest

RUN echo "********************************"
RUN echo "DEV DATABASE"
RUN echo "********************************"

ARG PROJECT_DIR=/tmp/devdatabase
RUN mkdir -p $PROJECT_DIR
WORKDIR $PROJECT_DIR

COPY sql/dev/db.sql ./
COPY sql/dev/wait-for-it.sh ./
COPY sql/dev/entrypoint.sh ./
COPY sql/dev/setup.sh ./

CMD ["/bin/bash", "entrypoint.sh"]
