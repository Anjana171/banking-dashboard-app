# Banking Dashboard Application

## Overview
The Banking Dashboard Application is a full-stack web application built using .NET 8 for the backend and Blazor for the frontend. It provides users with a secure platform to manage their bank accounts, authenticate their identity, and transfer funds between accounts.

## Features
- User Authentication: Secure login and registration process.
- Account Management: View, create, update, and delete bank accounts.
- Fund Transfers: Transfer funds between accounts with validation.
- Dashboard: Overview of account balances and recent transactions.

## Project Structure
```
banking-dashboard-app
├── BankingDashboard.API          # Backend API project
│   ├── Controllers               # API controllers for handling requests
│   ├── Models                    # Data models for the application
│   ├── Services                  # Business logic services
│   ├── Data                      # Database context
│   ├── Program.cs                # Entry point for the API
│   └── appsettings.json          # Configuration settings
├── BankingDashboard.Client        # Frontend Blazor project
│   ├── Pages                     # Blazor components for different views
│   ├── Services                  # Services for API communication
│   ├── Shared                    # Shared components and layouts
│   ├── Program.cs                # Entry point for the client
│   └── App.razor                 # Root component for the Blazor application
└── BankingDashboard.sln          # Solution file
```

## Setup Instructions
1. Clone the repository:
   ```
   git clone <repository-url>
   ```
2. Navigate to the `BankingDashboard.API` directory and restore the dependencies:
   ```
   cd BankingDashboard.API
   dotnet restore
   ```
3. Set up the database connection in `appsettings.json`.
4. Run the API project:
   ```
   dotnet run
   ```
5. Navigate to the `BankingDashboard.Client` directory and restore the dependencies:
   ```
   cd ../BankingDashboard.Client
   dotnet restore
   ```
6. Run the client project:
   ```
   dotnet run
   ```

## Usage
- Access the application through the provided URL after running the projects.
- Use the login page to authenticate or register a new user.
- Navigate to the dashboard to view account details and perform fund transfers.

