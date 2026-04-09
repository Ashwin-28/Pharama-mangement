# 🏥 Pharmacy Ordering System

Welcome to the **Pharmacy Ordering Website** repository! This is a Full-Stack application comprising a premium **Angular 21** frontend and a secure **ASP.NET Core 10 Web API** backend.

## 🛠 Tech Stack

- **Frontend:** Angular 21, TypeScript, Vanilla CSS (Premium & Responsive Design)
- **Backend:** ASP.NET Core 10 Web API, Entity Framework Core (SQLite default)
- **Security:** JWT (JSON Web Tokens), Role-Based Access Control (RBAC), ASP.NET Rate Limiting

---

## 📂 Project Structure

Below is the high-level directory structure for the entire workspace:

```text
Sam=parma/
│
├── 📁 backend/PharmacyAPI/                # ASP.NET Core 10 Web API
│   ├── 📁 Controllers/                    # API Endpoints
│   │   ├── AuthController.cs              # Register, Login, JWT generation
│   │   ├── MedicinesController.cs         # Browse medicines, admin stock management
│   │   └── OrdersController.cs            # Place orders, Admin workflow
│   ├── 📁 Data/                           # Database Context
│   │   └── AppDbContext.cs                # EF Core Database configuration
│   ├── 📁 Models/                         # Data Entities
│   │   ├── User.cs                        # ID, Role (Admin/Customer), Email, Password
│   │   ├── Medicine.cs                    # Price, Dosage, Packaging, RequiresPrescription
│   │   ├── Order.cs                       # Tracking Pending/Confirmed status and File Path
│   │   └── OrderItem.cs                   # Join table for medicines within an order
│   ├── 📁 Services/                       # Core Business Logic
│   │   ├── IAuthService.cs                # Authentication implementation
│   │   ├── IOrderService.cs               # Triggers automatic inventory deduction
│   │   └── IFileService.cs                # Handles saving uploaded prescriptions
│   ├── 📁 Uploads/                        # Temporarily stores uploaded prescriptions
│   ├── Program.cs                         # Configuration, Swagger, Auth, Rate Limiting setup
│   └── appsettings.json                   # Database connection string and JWT Secrets
│
└── 📁 frontend/pharmacy-app/              # Angular 21 Frontend
    ├── 📁 src/
    │   ├── 📁 app/
    │   │   ├── 📁 core/                   # Singleton services and interceptors
    │   │   │   ├── auth.guard.ts          # Protects Admin/Customer routes
    │   │   │   ├── jwt.interceptor.ts     # Attaches JWT to outgoing HTTP requests
    │   │   │   └── api.service.ts         # Base HTTP calls
    │   │   ├── 📁 features/               # Lazily loaded/standalone application features
    │   │   │   ├── 📁 admin/              # Admin Portal
    │   │   │   │   ├── dashboard/         # System overview
    │   │   │   │   ├── prescriptions/     # UI to validate Rx and change status to Confirmed
    │   │   │   │   └── inventory/         # Manage medicine catalog
    │   │   │   ├── 📁 customer/           # Customer Portal
    │   │   │   │   ├── catalog/           # Browse medicines and wellness features
    │   │   │   │   ├── cart/              # Checkout with file upload support
    │   │   │   │   └── orders/            # History and quick reorder
    │   │   │   └── 📁 auth/               # Access Control
    │   │   │       ├── login/             # Login page
    │   │   │       └── register/          # Register page
    │   │   ├── 📁 shared/                 # Reusable components (buttons, navbars, modals)
    │   │   │   └── components/
    │   │   ├── app.component.ts           # Root component
    │   │   └── app.routes.ts              # Global application routing rules
    │   ├── 📁 assets/                     # Images, global icons, mock prescriptions
    │   └── styles.css                     # Global design tokens (variables, typography)
    │
    ├── angular.json                       # Angular workspace configuration
    └── package.json                       # Frontend dependencies
```

---

## 🚀 Core Workflows

### 🛒 1. Placing an Order (Customer)
1. Registers/Logs in via the `AuthController`.
2. Adds prescription-required medicine to the cart.
3. Attaches an image at checkout; uploads file via `OrdersController.PlaceOrder`.
4. The system safely stores this data and marks the order as **`PendingValidation`**.

### ✅ 2. Prescription Validation (Admin)
1. Logs in as a user with the `Admin` role.
2. Visits `/admin/prescriptions` to review `PendingValidation` orders.
3. Views the corresponding file from `PharmacyAPI/Uploads/`.
4. Clicks **"Approve"**.
5. The `OrderService` transitions the order to **`Confirmed`** and simultaneously **deducts the requested stock amounts** from the related `Medicine` models.
