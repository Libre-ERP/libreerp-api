# 🚀 LibreERP API (Under Development)

Minimal API backend developed in **.NET 8** to power the LibreERP platform.

⚠️ **Note:** LibreERP is still in active development. Features may change frequently, and some modules are not yet production-ready. Contributions and feedback are welcome!

## 🎯 Objective

Provide a clean, modular, and lightweight backend to serve:

- REST and RPC endpoints for the frontend (React.js) and desktop client (WPF)
- Secure user authentication using JWT
- Business logic for inventory, transactions, and sales management

---

## ⚙️ Stack

- ASP.NET Core 8 (Minimal API)
- ADO.NET (Raw SQL access via `SqlConnection`)
- SQL Server
- JWT Authentication
- Swagger (OpenAPI)

---

## 📁 Project Structure

```bash
LibreERP.API/
├── Controllers/              # Minimal API endpoints
├── Data/
│   ├── SqlConnectionFactory.cs    # Centralizes SQL connection creation
│   └── CommandHelpers.cs          # Helpers for executing stored procedures
├── Services/                # Business logic and service layer
├── DTOs/                    # Request/response data models
├── Middlewares/             # Custom middleware components
├── Program.cs               # Application entry point
├── appsettings.json         # Configuration settings
└── README.md
