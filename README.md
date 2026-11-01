# BulkyBook – E-Commerce Bookstore Web Application

![BulkyBook Banner](https://res.cloudinary.com/dtspre1ab/image/upload/v1793465301/Bulkybook_uqjztu.png)

## Project Overview

**BulkyBook** is a full-featured E-Commerce web application developed using **ASP.NET Core MVC (.NET 8)**.This project implements enterprise-level design patterns, secure user authentication and authorization, shopping cart management, order processing, and online payment integration via Stripe.

The application serves as an online bookstore where customers can browse books, manage shopping carts, place orders, and track order statuses. Administrators and employees have access to management features for handling product inventories, categories, companies, user roles, and order fulfillment.

---

## Key Features

- **User Authentication & Role-Based Authorization:** Secure registration and login powered by ASP.NET Core Identity, featuring role-based access control (Admin, Employee, Customer).
- **Catalog & Product Management:** Full CRUD operations for product categories, products with image uploads, and company profiles.
- **Interactive Shopping Cart:** Dynamic cart management allowing users to adjust item quantities, calculate multi-tier pricing based on customer types, and proceed to checkout.
- **Order Processing & Management:** End-to-end order workflow covering order placement, payment verification, processing, shipping, delivery, and cancellation.
- **Stripe Payment Gateway Integration:** Secure online payment processing using Stripe Checkout.
- **Order Status Tracking:** Order status updates reflecting different states (Pending, Approved, Processing, Shipped, Cancelled, Refunded).
- **User Management Dashboard:** Administrative tools for managing user accounts, locking users, changing roles, and managing access permissions.

---

## Technology Stack

- **Framework:** ASP.NET Core MVC (.NET 8)
- **Language:** C#
- **Database & ORM:** Microsoft SQL Server, Entity Framework Core (Code-First Migrations)
- **Authentication:** ASP.NET Core Identity
- **Payment Gateway:** Stripe API
- **Frontend:** Razor Views, HTML5, CSS3, Bootstrap, JavaScript, jQuery, DataTables
- **Version Control:** Git & GitHub

---

## Project Architecture / Solution Structure

The solution follows a structured N-tier architectural layout, organizing concerns into distinct projects to maintain separation of responsibilities, testability, and scalability.

```text
BulkyBook/
│
├── Bulky.DataAccess/
│   ├── Data/
│   ├── DbInitializer/
│   ├── Migrations/
│   └── Repository/
│
├── Bulky.Models/
│   ├── Models/
│   └── ViewModels/
│
├── Bulky.Utility/
│
└── BulkyWeb/
    ├── Areas/
    ├── Controllers/
    ├── Views/
    ├── wwwroot/
    ├── appsettings.json
    └── Program.cs
```

### Project Responsibilities

- **`Bulky.DataAccess`:** Contains Entity Framework Core DbContext, database entities, repository implementations (Unit of Work pattern), and database migrations. Manages data persistence, database connections, and LINQ queries.

- **`Bulky.Models`:** Houses domain models, view models, and Data Transfer Objects (DTOs). Defines the data schema, relational mappings, and validation attributes required to transfer data between controllers and views.

- **`Bulky.Utility`:** Centralizes cross-cutting utility constants, user roles, order status strings, Stripe configurations, email senders, and application-wide helper classes.

- **`BulkyWeb` (Presentation Layer):** The primary ASP.NET Core MVC web application containing controllers, views, view models, authentication filters, routing, and static assets. Handles HTTP requests, user interactions, and UI rendering.

---

## Application Screenshots

### 1. Customer Storefront

#### Home Page

![Home Page](https://res.cloudinary.com/dtspre1ab/image/upload/v1793507356/Screenshot_From_2026-11-01_10-28-09_rkka5h.png)

The main storefront where customers can browse available books and explore the bookstore.

#### Product Details

![Product Details](https://res.cloudinary.com/dtspre1ab/image/upload/v1793521306/Screenshot_From_2026-11-01_14-21-08_obkurd.png)

Displays selected book information, description, author, ISBN, pricing tiers, and add-to-cart functionality.

---

### 2. Login & Authentication

The application uses **ASP.NET Core Identity** to provide secure user authentication and role-based authorization.

#### 2.1 User Login

Allows registered users to securely sign in to their accounts.

![User Login](https://res.cloudinary.com/dtspre1ab/image/upload/v1793507261/Screenshot_From_2026-11-01_10-11-19_z2lmhp.png)

#### 2.2 User Registration

Allows new customers to create an account.

![User Registration](https://res.cloudinary.com/dtspre1ab/image/upload/v1793507294/Screenshot_From_2026-11-01_10-26-47_svhxka.png)

#### 2.3 Role-Based Authorization

The application supports three roles:

- Admin
- Employee
- Customer

Each role has access to specific application features based on its permissions.

---

### 3. Admin Dashboard

The Admin Dashboard provides a centralized management area. Its navigation is organized into separate sections so administrators can manage different parts of the bookstore.

#### 3.1 Dashboard Overview

The dashboard serves as the main administrative entry point for accessing bookstore management features.

![Dashboard Overview](https://res.cloudinary.com/dtspre1ab/image/upload/v1793507260/Screenshot_From_2026-11-01_10-11-39_dtyxsr.png)

#### 3.2 Order Management

Order Management allows administrators and employees to review orders and handle order-related operations.

##### 3.2.1 Order List

![Order List](https://res.cloudinary.com/dtspre1ab/image/upload/v1793507266/Screenshot_From_2026-11-01_10-11-56_tqfbcm.png)

Displays order-related information.

##### 3.2.2 Order Details

![Order Details](https://res.cloudinary.com/dtspre1ab/image/upload/v1793522289/d711b8da-5b4a-4cfe-98f5-d8e0780a143f.png)

Provides detailed information about a selected order, including customer and order information.

#### 3.3 Product Management

Product Management provides administrative control over the bookstore's book inventory.

##### 3.3.1 Product List / Inventory

![Product List](https://res.cloudinary.com/dtspre1ab/image/upload/v1793507276/Screenshot_From_2026-11-01_10-12-25_yit4jn.png)

Displays the product inventory and available product management actions.

##### 3.3.2 Edit Product

![Edit Product](https://res.cloudinary.com/dtspre1ab/image/upload/v1793507288/Screenshot_From_2026-11-01_10-18-00_ge8ejq.png)

Allows administrators to update existing product information.

##### 3.3.3 Delete Product

![Delete Product](https://res.cloudinary.com/dtspre1ab/image/upload/v1793507279/Screenshot_From_2026-11-01_10-18-13_b1fw81.png)

Shows the product deletion interface.

#### 3.4 Category Management

Administrators can manage the categories used to organize books in the store.

##### 3.4.1 Category List

![Category List](https://res.cloudinary.com/dtspre1ab/image/upload/v1793507289/Screenshot_From_2026-11-01_10-19-48_lndxj6.png)

Displays the available product categories with administrative actions.

##### 3.4.2 Edit Category

![Edit Category](https://res.cloudinary.com/dtspre1ab/image/upload/v1793523415/d5ca6b3c-4bb0-4d80-b1f7-8c4f694c2138.png)

Allows administrators to modify existing category information.

##### 3.4.3 Delete Category

![Delete Category](https://res.cloudinary.com/dtspre1ab/image/upload/v1793523548/cce79890-4542-41d5-ab38-169ea5fbef45.png)

Shows the category deletion interface.

#### 3.5 User Management

The application includes administrative user management and role-based access control for Admin, Employee, and Customer accounts.

##### 3.5.1 User List & Lock User

![User List and Lock User](https://res.cloudinary.com/dtspre1ab/image/upload/v1793507288/Screenshot_From_2026-11-01_10-20-20_xhgzpz.png)

Allows administrators to view user accounts and manage user access.

##### 3.5.2 Change User Role

![Change User Role](https://res.cloudinary.com/dtspre1ab/image/upload/v1793507297/Screenshot_From_2026-11-01_10-20-30_i4tni3.png)

Allows administrators to change a user's assigned role.

##### 3.5.3 Change User Password

![Change User Password](https://res.cloudinary.com/dtspre1ab/image/upload/v1793507293/Screenshot_From_2026-11-01_10-20-44_semaml.png)

Provides an administrative interface for changing a user's password.

---

### 4. Shopping Cart & Checkout Workflow

#### 4.1 Shopping Cart

![Shopping Cart](https://res.cloudinary.com/dtspre1ab/image/upload/v1793507341/Screenshot_From_2026-11-01_10-28-39_mqfkti.png)

Customers can review cart items, update quantities, remove products, and view the subtotal.

#### 4.2 Checkout Summary

![Checkout Summary](https://res.cloudinary.com/dtspre1ab/image/upload/v1793522103/45e43494-9d9f-4de3-9781-de8574977975.png)

Customers review their shipping and billing information before proceeding with payment.

#### 4.3 Order Confirmation

![Order Confirmation](https://res.cloudinary.com/dtspre1ab/image/upload/v1793526461/dfa6ba61-f184-4107-bbda-f2309735698c.png)

Displays order confirmation information after successful order placement.

---

## Installation Guide

Follow these steps to set up and run the BulkyBook application locally.

### Prerequisites

Make sure the following tools are installed on your machine:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or SQL Server Express
- [Git](https://git-scm.com/)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

### 1. Clone the Repository

Open your terminal and run:

```bash
git clone https://github.com/shafiulsa/BulkyWebApp.git
```

Navigate to the project directory:

```bash
cd BulkyWebApp
```

### 2. Configure the Database Connection

Open `BulkyWeb/appsettings.json` and update the `DefaultConnection` connection string according to your SQL Server configuration.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=BulkyBook;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Replace `YOUR_SERVER_NAME` with your SQL Server instance name.

If you use SQL Server authentication, configure the connection string with your SQL Server username and password instead.

### 3. Restore Dependencies

Run the following command from the solution root directory:

```bash
dotnet restore
```

### 4. Install Entity Framework Core Tools

If you haven't installed the EF Core CLI tools, run:

```bash
dotnet tool install --global dotnet-ef
```

If the tool is already installed, update it:

```bash
dotnet tool update --global dotnet-ef
```

### 5. Apply Database Migrations

From the solution root directory, execute:

```bash
dotnet ef database update --project Bulky.DataAccess --startup-project BulkyWeb
```

This applies the existing Entity Framework Core migrations and creates or updates the database.

### 6. Run the Application

Navigate to the web project:

```bash
cd BulkyWeb
```

Run the application:

```bash
dotnet run
```

Open the local URL displayed in your terminal to access the BulkyBook application.

### 7. Configure Stripe Payments

To test the checkout and payment workflow, configure your Stripe API credentials using the configuration structure defined in the project.

- Use your Stripe test-mode API keys during local development.
- Keep secret API keys private.
- Never commit API keys or other sensitive credentials to GitHub.

---

**Note:** Make sure SQL Server is running and the database connection string is configured correctly before applying migrations or starting the application.

---

## Author

**Shafiul Islam**

- **GitHub:** [github.com/shafiulsa](https://github.com/shafiulsa)
- **LinkedIn:** [linkedin.com/in/shafiul05](https://www.linkedin.com/in/shafiul05)
