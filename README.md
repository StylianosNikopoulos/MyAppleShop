# MyAppleShop

MyAppleShop is a .NET MVC e-commerce application that allows users to browse, purchase iPhones and Apple Watches. It features integration with Stripe for payment processing and a separate admin API for managing inventory.

## Introduction

MyAppleShop is a comprehensive e-commerce solution built using ASP.NET MVC. The application allows registered users to:

- **Browse**: Navigate through available iPhones and Apple Watches.
- **Purchase**: Purchase products using Stripe.

Administrators have access to a dedicated API, `MyAppleShopApi`, where they can:

- **Create**: Add new iPhone and Apple Watch products.
- **Read**: View product details.
- **Update**: Modify existing products.
- **Delete**: Remove products from the inventory.

Both the user-facing MVC application and the admin API are included in the same repository and are fully integrated.


### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (Version 6.0 or later recommended)
- [Visual Studio](https://visualstudio.microsoft.com/downloads/) or another .NET-compatible IDE
- [Stripe API Keys](https://stripe.com/docs/keys) for payment processing

### Clone the Repository

```bash
git clone https://github.com/StylianosNikopoulos/MyAppleShop.git
cd MyAppleShop
