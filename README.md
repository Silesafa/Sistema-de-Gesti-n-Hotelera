# 🏨 Hotel Management System — RESTful Web API & ASP.NET Core MVC

This project corresponds to the second stage of the hotel management system development for the **Fundamentals of Web Programming (Code 03075)** course at Universidad Estatal a Distancia (UNED).

The solution evolves the architecture into a decoupled model utilizing an **independent RESTful Web API** for business logic and in-memory storage, consumed by an **ASP.NET Core MVC** web client.

---

## 🛠️ Tech Stack & Tools

- **IDE:** Visual Studio Community 2026
- **Language Framework:** C# / .NET 10.0
- **Services:** ASP.NET Core Web API (RESTful Services)
- **Web UI:** ASP.NET Core MVC
- **Persistence:** In-Memory Storage / Cache
- **Architecture:** Model-View-Controller (MVC) + HTTP Client-Server

---

## 🚀 Architecture & Modules

The solution consists of two primary projects within the same `.sln` file:

### 1. 📡 RESTful Services Project (`Proyecto2API`)
Exposes HTTP endpoints (GET, POST, PUT, DELETE) to manage business entities:
- **Employees:** Complete CRUD operations for staff management.
- **Customers:** Complete CRUD operations for customer records.
- **Rooms:** Complete CRUD operations and room status management.
- **Reservations:** Reservation logic, automated fare calculation, discount rules, VAT (13%), reservation statuses, and in-memory date overlap validation.

### 2. 💻 Web MVC Project (`Proyecto1MVC`)
Presentation layer that consumes the RESTful API via `HttpClient`:
- **Navigation:** Seamless menu navigation across Customers, Employees, Rooms, and Reservations.
- **Search Modules:** Independent search functionalities by ID, room number, or reservation code.
- **Validations:** Enforcement of business logic within the UI and constraint handling (e.g., preventing the deletion of customers/rooms with active reservations).

---

## ⚙️ Getting Started

1. Clone the repository:
   ```bash
   git clone [https://github.com/Silesafa/Sistema-de-Gesti-n-Hotelera.git](https://github.com/Silesafa/Sistema-de-Gesti-n-Hotelera.git)
