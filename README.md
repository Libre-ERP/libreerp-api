# 🚀 LibreERP API

Minimal API backend developed in **.NET 8** to power the LibreERP platform.

## 🎯 Objective

Provide a clean, modular, and lightweight backend to serve:
- REST and RPC endpoints for frontend (React.js) and desktop client (WPF)
- Secure user authentication (JWT)
- Business logic for inventory, transactions, and sales

---

## ⚙️ Stack

- ASP.NET Core 8 (Minimal API)
- ADO.NET (Raw SQL access via SqlConnection)
- SQL Server
- JWT Authentication
- Swagger (OpenAPI)

---

## 📁 Project Structure

```bash
LibreERP.API/
├── Controllers/          # Minimal API endpoints
├── Data/
│   ├── SqlConnectionFactory.cs    # Centraliza creación de conexiones
│   └── CommandHelpers.cs          # Helpers para ejecutar SPs
├── Services/
├── DTOs/                 # Request/response models
├── Middlewares/
├── Program.cs
├── appsettings.json
└── README.md
