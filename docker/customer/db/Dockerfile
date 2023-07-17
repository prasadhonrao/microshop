FROM mcr.microsoft.com/mssql/server

# Set environment variables for SQL Server
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=M!cr@sh@pDEV

# Copy the database initialization script to the container
COPY init.sql /docker-entrypoint-initdb.d/

# Expose the SQL Server port
EXPOSE 1433

# Start the SQL Server service
CMD ["/opt/mssql/bin/sqlservr"]
