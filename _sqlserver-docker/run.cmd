@echo off
echo ==== SQL SERVER WILL BE RUN====
echo.

docker compose up -d
echo looking at logs for mssql
docker compose logs -f mssql

echo.
echo ==== COMPLETED ====
pause