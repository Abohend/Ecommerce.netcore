# E-Commerce Application

A full-featured E-Commerce web application built with ASP.NET Core MVC 8, Entity Framework Core, and Stripe for payment processing.

## 🌟 Features

- **User Authentication & Authorization**: Secure login, registration, and role management (Admin, Editor, Customer) using ASP.NET Core Identity.
- **Product Catalog**: Browse products, view details, and manage inventory.
- **Shopping Cart**: Add products to cart, update quantities, and prepare for checkout.
- **Order Management**: Checkout process, order tracking, and history.
- **Payment Processing**: Integrated with Stripe for secure and reliable credit card transactions.
- **Admin Dashboard**: Comprehensive admin panel to manage categories, products, users, and orders.
- **Responsive UI**: Modern, clean, and responsive design for both desktop and mobile devices.

## 🛠️ Built With

- **Framework**: .NET 8 / ASP.NET Core MVC
- **ORM**: Entity Framework Core 8
- **Database**: SQL Server
- **Authentication**: ASP.NET Core Identity
- **Payments**: Stripe Checkout via `Stripe.net`
- **Mapping**: AutoMapper
- **UI Components**: Razor Pages, Bootstrap, jQuery Unobtrusive Ajax

## 📂 Project Structure

The project follows a clean N-Tier architecture pattern:

- **`Ecommerce.Web`**: The presentation layer containing Controllers, Views (Razor), ViewModels, and UI-specific configuration.
- **`Ecommerce.Entities`**: The domain layer holding models, aggregate roots, and interface definitions (e.g., `IRepository`, `IUnitOfWork`).
- **`Ecommerce.Data`**: The data access layer containing the Entity Framework `DbContext`, Database Migrations, and repository implementations.
- **`Utilities`**: Shared resources, helpers, and constant configurations (e.g., Application Roles).

## 🚀 Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- SQL Server (LocalDB or full instance)
- A [Stripe Account](https://stripe.com/) for test/live payment API keys

### Installation & Configuration

1. **Clone the repository** (or open the local folder in your IDE):
   ```bash
   git clone <repository-url>
   cd Ecommerce.netcore
   ```

2. **Configure Database Connection**
   Open `Ecommerce.Web/appsettings.json` and ensure your `DefaultConnection` points to your active SQL Server instance:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=EcommerceDb;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```

3. **Configure Stripe API Keys**
   Add your Stripe Secret Key and Publishable Key to `Ecommerce.Web/appsettings.json`:
   ```json
   "Stripe": {
     "SecretKey": "sk_test_...",
     "PublishableKey": "pk_test_..."
   }
   ```

4. **Configure Default Admin Settings**
   In `appsettings.json`, confirm or update the admin credentials for initial database seeding:
   ```json
   "Admin": {
     "Name": "Admin User",
     "Email": "admin@example.com",
     "Password": "YourSecurePassword123!",
     "Phone": "1234567890"
   }
   ```

### Running the Application

1. Open a terminal and navigate to the Web project directory:
   ```bash
   cd Ecommerce.Web
   ```

2. Build the solution:
   ```bash
   dotnet build
   ```

3. Run the application:
   ```bash
   dotnet run
   ```

*Note: The application is configured to automatically apply any pending Entity Framework database migrations and seed default data (such as Roles and Admin user) upon startup.*

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.
1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is open-source and available under the terms of the MIT License.
