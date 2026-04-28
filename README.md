# ALlyHub

<p align="center">
  <img src="Images/Logo.png" alt="ALlyHub Logo" width="180"/>
</p>

<p align="center">
  <strong>A freelancing marketplace connecting talented developers with clients who need them.</strong>
</p>

---

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Prerequisites](#prerequisites)
- [Installation & Setup](#installation--setup)
- [Configuration](#configuration)
- [Running the Project](#running-the-project)
- [Database Setup](#database-setup)
- [Testing](#testing)
- [Contributing](#contributing)
- [License](#license)

---

## Overview

**ALlyHub** is a full-stack web application built with ASP.NET MVC that bridges the gap between skilled developers and clients looking to hire talent. Clients can post projects and browse developer profiles, while developers can search for jobs, apply with a CV/cover letter, and manage their professional portfolio — all in one place.

The name *ALlyHub* reflects the platform's mission: to be an ally (and a hub) for both job seekers and potential clients.

---

## Features

### For Clients
- **Post Projects** – Create job postings with title, description, required skill set, budget, and duration.
- **Browse Developers** – Explore developer profiles, portfolios, skill sets, and work experience.
- **Review Applicants** – View all applicants for a posted project, download their attached files, and accept the best fit.
- **Handshake System** – Accept a developer to form a "handshake" agreement, locking in the collaboration.
- **Leave Reviews** – Rate and review developers upon project completion.
- **Search** – Search for developers by name or skill.

### For Developers
- **Browse Jobs** – Explore open project listings with filtering by skill and expertise level.
- **Apply for Jobs** – Submit applications with a cover letter, contact details, and an optional file (resume/portfolio).
- **Profile Management** – Maintain a detailed profile including bio, area of expertise, portfolio link, LinkedIn, Facebook, and work experience history.
- **Submit Deliverables** – Upload completed project files directly through the platform.
- **Leave Reviews** – Rate and review clients after project completion.
- **Search** – Search for projects by keyword.

### General
- **User Registration & Authentication** – Separate sign-up flows for Clients and Developers with session-based login.
- **Forgot Password / OTP Reset** – Recover account access via a one-time password sent to your registered email.
- **Email Notifications** – Automated email alerts on registration, profile updates, job applications, and acceptance.
- **Responsive UI** – Mobile-friendly design powered by Bootstrap 5.

---

## Tech Stack

| Layer | Technology |
|---|---|
| **Framework** | ASP.NET MVC 5 (.NET Framework 4.7.2) |
| **Language** | C# |
| **Database** | Microsoft SQL Server (SQL Express) |
| **ORM** | Entity Framework 6.5.1 |
| **Frontend** | HTML5, CSS3, Bootstrap 5, jQuery 3.7.1 |
| **UI Utilities** | Alertify.js, Swiper.js |
| **Email** | System.Net.Mail via Gmail SMTP |
| **Serialization** | Newtonsoft.Json 13.0.3 |
| **Build & Package** | MSBuild, NuGet |
| **IDE** | Visual Studio (recommended) |

---

## Project Structure

```
ALlyHub/
├── App_Start/              # MVC startup config (routes, bundles, filters)
├── ApplicantFiles/         # Uploaded applicant CV/portfolio files
├── Content/                # CSS stylesheets (Bootstrap, custom, Alertify themes)
├── Controllers/
│   └── HomeController.cs   # Single controller handling all routes
├── Data/                   # Data-access helper classes
│   ├── ApplicationHelper.cs
│   ├── ConnectDB.cs
│   ├── DatabaseHelper.cs
│   ├── FindtalentHelper.cs
│   ├── ProfileHelper.cs
│   ├── ProjectHelper.cs
│   └── SearchHelper.cs
├── DatabaseSQL/
│   └── Allyhub.sql         # Full database schema (tables, sample data)
├── Images/                 # Static image assets
├── JS/                     # Custom JavaScript files
├── Models/                 # C# model / view-model classes
│   ├── Applicant.cs
│   ├── FindTalentModel.cs
│   ├── Handshake.cs
│   ├── HandshakeProjectViewModel.cs
│   ├── LoginModel.cs
│   ├── ProfileModel.cs
│   ├── Project.cs
│   ├── RegisterModel.cs
│   └── Search.cs
├── Scripts/                # jQuery, Bootstrap JS, Alertify JS
├── Video/                  # Demo video asset
├── Views/
│   ├── Home/               # Razor views for all pages
│   └── Shared/             # Shared layout and error views
├── ALlyHub.csproj          # Project file
├── ALlyHub.sln             # Solution file
├── Global.asax(.cs)        # Application lifecycle entry point
├── SendMessage.cs          # Email helper (SMTP)
├── Web.config              # Application configuration (DB, SMTP, etc.)
└── packages.config         # NuGet package manifest
```

---

## Prerequisites

- **Windows** operating system (IIS Express is Windows-only)
- **Visual Studio 2019 / 2022** (Community edition or higher)
  - Workload: *ASP.NET and web development*
- **.NET Framework 4.7.2** Developer Pack
- **Microsoft SQL Server** (Express edition is sufficient) with SQL Server Management Studio (SSMS)
- **NuGet** (bundled with Visual Studio)
- A **Gmail account** (or other SMTP provider) for email notifications

---

## Installation & Setup

### 1. Clone the repository

```bash
git clone https://github.com/ashikulislamm/ALlyHub.git
cd ALlyHub
```

### 2. Open in Visual Studio

Double-click `ALlyHub.sln` to open the solution in Visual Studio.

### 3. Restore NuGet packages

Visual Studio will prompt you to restore packages on first open, or you can do it manually:

```
Tools → NuGet Package Manager → Manage NuGet Packages for Solution → Restore
```

Or via the NuGet CLI:

```bash
nuget restore ALlyHub.sln
```

---

## Configuration

### Database connection string

Open `Web.config` and update the `connectionStrings` section to point to your local SQL Server instance:

```xml
<connectionStrings>
  <add name="AllyhubEntities"
       connectionString="metadata=res://*/Models.DBmodel.csdl|res://*/Models.DBmodel.ssdl|res://*/Models.DBmodel.msl;
                         provider=System.Data.SqlClient;
                         provider connection string=&quot;
                           data source=YOUR_SERVER\SQLEXPRESS;
                           initial catalog=Allyhub;
                           integrated security=True;
                           trustservercertificate=True;
                           MultipleActiveResultSets=True;
                           App=EntityFramework&quot;"
       providerName="System.Data.EntityClient" />
</connectionStrings>
```

Replace `YOUR_SERVER\SQLEXPRESS` with your SQL Server instance name (e.g., `localhost\SQLEXPRESS`).

### Email (SMTP)

Open `SendMessage.cs` and fill in your Gmail credentials:

```csharp
var smtpClient = new SmtpClient("smtp.gmail.com")
{
    Port = 587,
    Credentials = new NetworkCredential("your-email@gmail.com", "your-app-password"),
    EnableSsl = true,
};
```

> **Note:** Use a [Gmail App Password](https://support.google.com/accounts/answer/185833) (not your regular Gmail password) when 2-Step Verification is enabled.

You can also update the sender address in the `From` field and in `Web.config` under `<mailSettings>`.

---

## Database Setup

1. Open **SQL Server Management Studio (SSMS)** and connect to your SQL Server instance.
2. Open and execute the schema file:
   ```
   DatabaseSQL/Allyhub.sql
   ```
   This script creates the `Allyhub` database and all required tables (`Users`, `Client`, `Developer`, `Skills`, `DeveloperSkill`, `Project`, `Applicant`, `Handshake`, `WorkExperience`, `Review`, etc.).

3. Verify the database and tables exist before running the application.

---

## Running the Project

### Development (IIS Express)

1. Set `ALlyHub` as the startup project in Visual Studio (right-click → *Set as Startup Project*).
2. Press **F5** (or click the green ▶ *IIS Express* button) to build and launch.
3. The browser will open at `https://localhost:44370/` by default.

### Production (IIS)

1. Publish the project:
   ```
   Build → Publish ALlyHub → Folder / Web Deploy
   ```
2. In IIS Manager, create a new site or application pointing to the published output folder.
3. Set the application pool to **.NET CLR v4.0**, *Integrated* pipeline mode.
4. Ensure the SQL Server service is running and the connection string in `Web.config` is updated for the production server.
5. Make sure the `ApplicantFiles/` and `UploadedFiles/` folders have **write permissions** for the IIS application pool identity.

---

## Testing

> **Note:** This project does not currently include an automated test suite.

Manual testing can be performed by:

1. Registering accounts as both a **Client** and a **Developer**.
2. Posting a project as a Client, then applying from a Developer account.
3. Accepting an applicant (handshake), submitting a project file, and exchanging reviews.
4. Testing the forgot-password OTP flow.

<!-- TODO: Add unit tests (e.g., MSTest or xUnit) for helper classes in the Data/ folder -->

---

## Contributing

Contributions are welcome! To get started:

1. **Fork** the repository on GitHub.
2. **Create a branch** for your feature or fix:
   ```bash
   git checkout -b feature/your-feature-name
   ```
3. **Commit** your changes with clear, descriptive messages.
4. **Push** your branch and open a **Pull Request** against the `main` branch.
5. Describe what your PR changes and why.

Please follow the existing code style and keep pull requests focused on a single concern.

---

## License

This repository does not currently include a license file. All rights are reserved by the author(s) unless otherwise stated.

<!-- TODO: Add a LICENSE file (e.g., MIT) if you wish to open-source this project -->

