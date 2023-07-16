FROM mcr.microsoft.com/mssql/server:2022-latest

RUN echo "********************************"
RUN echo "PROD DATABASE"
RUN echo "********************************"

ARG PROJECT_DIR=/tmp/devdatabase
RUN mkdir -p $PROJECT_DIR
WORKDIR $PROJECT_DIR

COPY sql/prod/db.sql ./
COPY sql/prod/wait-for-it.sh ./
COPY sql/prod/entrypoint.sh ./
COPY sql/prod/setup.sh ./

CMD ["/bin/bash", "entrypoint.sh"]



