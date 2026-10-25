# Staff Management Web App

A small ASP.NET Core MVC web app that lets a system administrator sign in and manage a list of staff members: add, view, edit and delete staff records.

Built as a university project in 2026.

## Features

- **Admin login and logout.** A single administrator account signs in through a login form. The signed-in state is kept in an ASP.NET Core session.
- **Protected staff pages.** Every staff page checks the session and sends visitors who are not signed in back to the login page.
- **Staff CRUD.** List all staff members, add a new member, edit an existing one and delete one.
- **Staff record fields.** Staff ID, full name, email, position and unit.
- **Layered structure.** Models, a service layer (`StaffService`) registered through dependency injection, MVC controllers and Razor views.

## Tech stack

- C# / .NET 10
- ASP.NET Core MVC with Razor views
- ASP.NET Core session state (in-memory distributed cache)
- Bootstrap 5 and jQuery (bundled in `wwwroot/lib`)

## Project structure

```
.
├── Controllers/
│   ├── AccessController.cs   # Admin login and logout
│   └── StaffController.cs    # Staff list, create, edit and delete
├── Models/
│   ├── StaffMember.cs        # Staff record
│   └── SystemAdmin.cs        # Admin credentials model
├── Services/
│   └── StaffService.cs       # Staff list operations (singleton)
├── Views/
│   ├── Access/Login.cshtml
│   ├── Staff/Index.cshtml, Create.cshtml, Edit.cshtml
│   └── Shared/_Layout.cshtml
├── wwwroot/                  # CSS, JS and client libraries
├── Program.cs                # Service registration and middleware pipeline
└── ITEHAProject.csproj
```

## Running locally

Prerequisite: the [.NET 10 SDK](https://dotnet.microsoft.com/download).

```bash
git clone https://github.com/codePexx-ZA/staff-management-web-app.git
cd staff-management-web-app
dotnet run
```

Then open http://localhost:5219 (or https://localhost:7180 with the `https` launch profile: `dotnet run --launch-profile https`).

Sign in with the demo admin account:

| Username | Password   |
|----------|------------|
| `admin`  | `password` |

## Notes and limitations

This was built to demonstrate MVC structure, dependency injection and session-based access control, so some parts are intentionally simple:

- Staff data is stored **in memory** in a singleton service, so it resets whenever the app restarts. There is no database.
- The admin credentials are hard-coded demo values and the password is compared in plain text. A production version would use ASP.NET Core Identity (or another identity provider) with hashed passwords.
- There is no server-side input validation, and staff IDs are entered manually.

Possible next steps: persist staff with EF Core and PostgreSQL, add ASP.NET Core Identity, add model validation and anti-forgery checks, and add unit tests for `StaffService`.
