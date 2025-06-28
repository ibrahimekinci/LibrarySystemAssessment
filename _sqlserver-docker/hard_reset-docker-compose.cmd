@echo off
echo ==== DOCKER PROJECT HARD RESET ====
echo.

echo [1/4] Stopping and removing containers...
docker-compose down --volumes --remove-orphans

echo [2/4] Removing Docker network...
for /f "tokens=3" %%i in ('docker network ls ^| findstr "backend"') do (
    docker network rm %%i
)

echo [3/4] Removing volume...
docker volume rm sql-server_sql_data 2> nul || echo Volume already removed or doesn't exist

echo.
echo ==== RESET COMPLETE ====
pause