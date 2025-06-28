#!/bin/bash
set -e

# Start SQL Server in the background
echo "Starting SQL Server..."
/opt/mssql/bin/sqlservr &

# Wait 60 seconds to ensure SQL Server is fully up
echo "Waiting 60 seconds for SQL Server to stabilize..."
sleep 60
#!/bin/bash

# Verify sqlcmd exists
echo 'Checking for sqlcmd tool...'
if [ ! -f /opt/mssql-tools/bin/sqlcmd ]; then
  echo 'ERROR: sqlcmd not found at /opt/mssql-tools/bin/sqlcmd!';
  echo 'Attempting to install mssql-tools...';
  apt-get update && apt-get install -y mssql-tools unixodbc-dev;
  export PATH=\"$PATH:/opt/mssql-tools/bin\";
fi

# Wait for SQL Server to be ready
echo "Waiting for SQL Server to be ready..."
for i in {1..30}; do
  if /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "$MSSQL_SA_PASSWORD" -Q "SELECT 1" &>/dev/null; then
    echo "SQL Server is ready!"
    break
  else
    echo "Not ready yet (attempt $i/30)..."
    sleep 5
  fi
done

# Check for and execute initialization scripts
echo "Checking for initialization scripts..."
if [ -f /init/init.sql ]; then
  echo "✅ Found init.sql, executing..."
  if /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "$MSSQL_SA_PASSWORD" -i /init/init.sql; then
    echo "✅ init.sql executed successfully!"
  else
    echo "❌ Error executing init.sql!" >&2
    exit 1
  fi
else
  echo "⚠️ No init.sql found in /init directory"
fi

# Keep the container running
echo "Initialization complete, container is running..."
tail -f /dev/null