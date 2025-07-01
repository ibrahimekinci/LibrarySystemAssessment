# Library System Assessment

## 📌 Project Repository  
🔗 **[LibrarySystemAssessment on GitHub](https://github.com/ibrahimekinci/LibrarySystemAssessment.git)**  
This project is a library management system built with SQL Server. Below you'll find instructions for setting up the database environment.

## Database Setup

### Prerequisites
- Docker installed on your Windows system

### Setup Instructions

#### Option 1: Quick Start
1. Navigate to `16303_Ibrahim_Ekinci_CMP1046_Assessment_01\_sqlserver-docker` directory
2. Simply double-click the `run.cmd` file to execute the setup automatically.

#### Option 2: Manual Setup
1. Navigate to `16303_Ibrahim_Ekinci_CMP1046_Assessment_01\_sqlserver-docker` directory in your command line
2. Run the command: `docker compose up -d`

### Database Schema Notes
If the database isn't created properly using my provided script (`init.sql`), please ensure the following fields are added to the User table:
- PhoneNumber
- Email

For reference, you can check this example:  
[mssql-docker-init-example on GitHub](https://github.com/ibrahimekinci/mssql-docker-init-example)

## Project Structure
The main database initialization script is located at:  
`16303_Ibrahim_Ekinci_CMP1046_Assessment_01\_sqlserver-docker\init\init.sql`