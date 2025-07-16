# 🧾 Internal Resource Booking System  
**Created by:** Mushiana Desmond  
**Role:** Junior ASP.NET Core Developer  
**Project Type:** Technical Assessment Case Study  

---

## 📌 Objective

To build a simple yet functional internal web application that allows employees to view available shared resources (e.g., meeting rooms, company cars, or equipment) and book them for specific time slots — eliminating double bookings and confusion.

---

## 🛠️ Technologies & Tools Used

| Technology / Tool | Version | Purpose |
|-------------------|---------|---------|
| .NET SDK          | `8.0.302` | Target framework for development (LTS and feature-rich) |
| ASP.NET Core MVC  | `8.0`     | Web framework using the Model-View-Controller pattern |
| C#                | Latest with .NET 8.0 | Backend logic and model handling |
| Entity Framework Core | `8.0.0` | ORM to interact with SQL Server using LINQ |
| MYSQL WORKBENCH | (System Installed) | Local development database |
| Pomelo.EntityFrameworkCore.MySql | `7.0.0` | MySQL support tested during experimentation (not used finally) |
| Microsoft.EntityFrameworkCore.SqlServer | `8.0.0` | SQL Server provider for EF Core |
| Microsoft.EntityFrameworkCore.Design | `8.0.0` | Enables migrations and design-time tools |
| Microsoft.VisualStudio.Web.CodeGeneration.Design | `8.0.0` | For scaffolding controllers and views |
| Bootstrap         | `5.x`    | Front-end styling for responsive layout |
| Git & GitHub      | N/A      | Version control and project tracking |

---

## ✅ Implementation Overview (Per Case Study)

### 🔹 1. Project Setup
- Created new ASP.NET Core **MVC** project using `.NET 8.0`.
- Configured **Entity Framework Core** with MYSQL WORKBENCH.
- Connection string stored in `appsettings.json`.
- Registered DbContext using `services.AddDbContext<ApplicationDbContext>()`.

---

### 🔹 2. Resource Management
- **Model**: `Resource.cs` with properties:  
  `Id`, `Name`, `Description`, `Location`, `Capacity`, `IsAvailable`
- **DbContext**: Registered `DbSet<Resource>` in `ApplicationDbContext.cs`
- **Migrations**:
  - Created and applied using `dotnet ef migrations add InitialCreate` and `dotnet ef database update`
- **CRUD Operations**:
  - Fully implemented: Create, Read (Index + Details), Update, Delete
- **Validation**:
  - Applied `[Required]` and custom rules like positive `Capacity`

---

### 🔹 3. Booking Management
- **Model**: `Booking.cs` with:  
  `Id`, `ResourceId`, `StartTime`, `EndTime`, `BookedBy`, `Purpose`
- **Relationship**: One-to-many with `Resource` (Foreign Key)
- **Migrations**: Applied to create `Bookings` table
- **Display**: 
  - Bookings listed in a separate view
  - **Home page** shows upcoming bookings with countdown (`X hours from now`)

---

## ✅ Booking Logic, UI, and Validation

### 🔸 Booking Creation Form
- Dropdown filtered to only show `IsAvailable == true` resources
- Inputs: `StartTime`, `EndTime`, `BookedBy`, `Purpose`
- Booking is **blocked** if resource is unavailable (checked server-side)

### 🔸 Conflict Detection
- Logic ensures:
  - No overlapping bookings for a resource
  - `EndTime > StartTime`
  - Booking window does not clash with another booking
- On conflict: User-friendly message shown

### 🔸 Server-side + Client-side Validation
- `[Required]`, `[StringLength]`, and datetime validation
- Enabled unobtrusive client-side validation via `_ValidationScriptsPartial.cshtml`

---

## 🎨 UI/UX Enhancements

- **Bootstrap 5** used throughout
- Clean, responsive layout for mobile/desktop
- `datetime-local` fields used for accurate booking time entry
- Navbar includes links to:
  - Resources
  - Bookings
  - Dashboard
- Dashboard/Home page shows:
  - Total resource count
  - Upcoming bookings
  - Action buttons

---

## 🧠 Code Quality & Best Practices

- Followed SOLID principles
- Used try-catch blocks to handle exceptions
- Used proper naming conventions
- Applied separation of concerns between models, views, and controllers
- Logical Git commits with meaningful messages

---

## 🔐 Features Not Implemented (By Design)

| Feature | Notes |
|--------|-------|
| User Authentication & Authorization | Only admin should manage resources. Planned but not implemented. |
| Role-based Access | Could restrict booking/editing to authorized users. |
| Audit Trail | Booking history/edit tracking not included. |
| Search/Filter | Filtering bookings by date/resource is not yet implemented. |
| Data Seeding | No initial data provided; could be added in future. |

---

## ⚠️ Challenges Faced

- **SDK Downgrade**: Had to uninstall EF Core tools version `9.x` and reinstall compatible `7.0.21`
- **Conflicting Dependencies**: EF Core packages defaulted to `8.0.0`, but manually managed version alignment
- **405 Errors**: Due to incorrect method signatures or routing issues in `Edit` form
- **500 Internal Errors**: From runtime mismatches and object-model view issues
- **EF Migrations**: Required several re-runs to sync model changes with database

---

## 📦 How to Run This Project

### 🧰 Prerequisites
- Visual Studio 2022+ or VS Code with C# extensions
- .NET 8.0 SDK installed
- MYSQL WORKBENCH installed 

---

### 🚀 Steps to Run Locally

```bash
# 1. Clone the repository
git clone https://github.com/Desmonddesco/ResourceBookingSystem-main

# 2. Navigate to project folder
cd ResourceBookingSystem

# 3. Apply migrations
dotnet ef database update

# 4. Run the application
dotnet run

---

### 🔗 MYSQL WORKBENCH Setup on Another Machine

- Ensure **MYSQL Workbench** is installed.

- Update the connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ResourceBookingDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}

## 🔄 Routing & Model Binding

**Routing Example:**  
`/Bookings/Edit/5`

**Model Binding Sample:**

```csharp
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Id,ResourceId,StartTime,EndTime,BookedBy,Purpose")] Booking booking)

## 📂 Submission Checklist

✅ **GitHub Repository:**  
➡️ [https://github.com/Desmonddesco/ResourceBookingSystem-main]

✅ Application Screenshots  
✅ LocalDB `.mdf` file or backup `.bak`  
✅ Zipped Project (for WeTransfer)  
✅ Final `README.md`

---

## ✅ Project Status

✅ Fully Functional  
✅ Meets all core requirements  
✅ Booking edit and cancel/delete are implemented  
✅ Tested and deployed locally  
✅ Git history clean and up-to-date  
✅ Project zipped and ready for submission

---

