
# Employee Management - Angular 18 + .NET Core CRUD App

A full-stack CRUD web application using **Angular 18 Standalone** and **.NET 8 Web API**, with SQL Server database and optional seed data.

---

## 📁 Project Structure

```
employee-management/
├── backend/        → .NET Core Web API
├── frontend/       → Angular 18 App
├── database/       → SQL Server .bak file (optional)
└── README.md
```

---

## 🚀 Features

- Display paginated list of employees
- Create, edit, and delete employees
- Real-time search (by name, email, or position)
- Angular form validation with user feedback
- Clean, responsive Bootstrap UI

---

## 🧰 Technologies

- **Frontend**: Angular 18 (Standalone), Bootstrap 5
- **Backend**: .NET 8 Web API
- **Database**: SQL Server (with `.bak` file provided)

---

## ▶️ Run the App

### 🖥️ Backend (ASP.NET Core)

1. Navigate to:
   ```bash
   cd backend/EmployeeAPI
   ```
2. Update `appsettings.json` with your SQL Server connection string.
3. Run the backend API:
   ```bash
   dotnet run
   ```
4. API runs at `https://localhost:7093/api/employees`

---

### 🌐 Frontend (Angular)

1. Navigate to:
   ```bash
   cd frontend/employee-app
   ```
2. Install dependencies:
   ```bash
   npm install
   ```
3. Run Angular app:
   ```bash
   ng serve
   ```
4. Open in browser:
   [http://localhost:4200](http://localhost:4200)

---

## 🗃️ Database Setup

You have two options:

### 🅰️ Use `.bak` file (preferred)

1. Open SQL Server Management Studio (SSMS)
2. Right-click on "Databases" → `Restore Database...`
3. Choose "Device", and select `database/EmployeeDB.bak`
4. Click OK to restore

### 🅱️ Use SQL script

1. Use the provided `seed.sql` in the `database/` folder
2. Execute it in SSMS to create and populate the `Employees` table

---

## 🙋 Developed By

**Mostafa Alaa**  
[GitHub Profile](https://github.com/mustafa012588)
