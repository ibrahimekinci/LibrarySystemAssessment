# 📚 Library System Assessment

A **.NET-based library management system** designed to streamline student and staff interactions with a library database.  
Built with **Windows Forms UI**, **ASP.NET Web Services**, and a **SQL Server backend** (Dockerized), the system supports:

- 🔐 User authentication
- 📖 Book and reference data management
- 📊 Borrowing/returning activity tracking
- 📜 Reporting and search functionalities

---

## 🔗 Repository

[**LibrarySystemAssessment on GitHub**](https://github.com/ibrahimekinci/LibrarySystemAssessment)

---

## 📑 Project Overview

This project replaces manual worksheet-based processes in a campus library with an IT-driven solution.  
It consists of two main components:

1. **Core Application (UI)**  
   - Developed in **Visual C#** (Windows Forms)
   - For student and staff interactions

2. **Web Services Layer**  
   - Developed in **ASP.NET**
   - Handles business logic & database operations
   - Replaces direct UI-to-database connections

**Technology Stack:**
- IDE: Visual Studio (Visual Web Developer & Visual C#)
- Database: SQL Server (Docker)
- Architecture: Layered (UI, BLL, DAL, Web Services)

---

## 🏗️ Project Structure

📦 LibrarySystemAssessment
│ .dockerignore
│ .gitignore
│ output.txt
│ README.md
│
├── .github/
│ └── workflows/
├── src/
│ ├── ui/
│ │ ├── LibrarySystemUI
│ ├── api/
│ │ ├── LibrarySystem.Abstractions
│ │ ├── LibrarySystem.BLL
│ │ ├── LibrarySystem.DAL
│ │ ├── LibrarySystem.Domain
│ │ └── LibrarySystem.WebApi
└── _sqlserver-docker/
│ .dockerignore
│ .env
│ docker-compose.yml
│ hard_reset-docker-compose.cmd
│ run.cmd
└── init/
├── entrypoint.sh
└── init.sql

markdown
Copy
Edit

---

## ⚙️ Features

### **User Interface (Windows Forms)**
- **Authentication** for students, staff, and managers
- **Staff/Manager Functions**:
  - Manage books, categories, authors, languages (Add/Edit/Delete)
  - Search and filter student activities
  - Update student details
- **Student Functions**:
  - Search/reserve books
  - Update personal details
  - View borrowing history
- Secure logout functionality

### **Web Services**
- Handles all CRUD operations
- Uses DataTables & basic data types for compatibility
- Acts as a middleware between UI and database

### **Database**
- **SQL Server** running in Docker
- Predefined schema via `init.sql`
- Tables for books, authors, languages, users, and activity logs

---

## 🚀 Getting Started

### 🧰 Requirements
- Docker
- Visual Studio (Visual Web Developer & Visual C#)
- .NET Framework (compatible version)
- SQL Server Client (e.g., SSMS)

### 📦 Installation
git clone https://github.com/ibrahimekinci/LibrarySystemAssessment.git
Open web services project in Visual Web Developer.

Open UI project in Visual C#.

🗄️ Database Setup
Option 1: Quick Start

Navigate to _sqlserver-docker/

Run run.cmd to start SQL Server and auto-initialize schema

Option 2: Manual Setup
cd _sqlserver-docker
docker compose up -d
Connect to SQL Server and run init/init.sql

🛠️ Assumptions
Database initialized from init.sql

Web services handle only basic data types / DataTables

Docker environment stable

👨‍💻 Author
İbrahim Ekinci — Software Developer, Melbourne AU