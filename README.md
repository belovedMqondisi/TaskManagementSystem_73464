
# Task Management System

**Project ID:** 73464

A web-based Task Management System developed using ASP.NET Core MVC, C#, Entity Framework Core, and SQLite.

The application allows users to create, view, update, delete, and organize tasks. Each task can be assigned to a registered user and given a priority level.

## Features

- Create and view users
- Create tasks with a title and description
- Assign tasks to users
- Set task priorities: High, Medium, or Low
- Edit existing tasks
- Delete tasks with confirmation
- Sort tasks by creation date or priority
- Store data persistently using SQLite
- Responsive interface using Bootstrap and custom CSS
- Server-side MVC architecture

## Technologies Used

| Technology | Purpose |
|------------|---------|
| ASP.NET Core MVC (.NET 10) | Web application framework |
| C# | Backend programming |
| Entity Framework Core 10 | Database operations |
| SQLite | Local database |
| Razor Views | Dynamic HTML pages |
| Bootstrap | Responsive UI components |
| HTML and CSS | Interface design |
| Cursor | Development environment |

## Project Structure

```text
TaskManagementSystem_73464/
|
|-- Controllers/
|   |-- HomeController.cs
|   |-- TasksController.cs
|   |-- UsersController.cs
|
|-- Models/
|   |-- Data/
|   |   |-- ApplicationDbContext.cs
|   |-- AppUser.cs
|   |-- TaskItem.cs
|
|-- Views/
|   |-- Home/
|   |-- Shared/
|   |-- Tasks/
|   |-- Users/
|
|-- Migrations/
|-- wwwroot/
|   |-- css/
|   |   |-- site.css
|
|-- Program.cs
|-- appsettings.json
|-- TaskManagementSystem_73464.csproj
|-- README.md
```

## Database Design

The application uses two main entities.

### User

- Id
- Name
- Email

### Task

- Id
- Title
- Description
- Priority
- CreatedAt
- AppUserId

### Relationship

One user can be assigned multiple tasks.

Each task is associated with a user through the `AppUserId` foreign key.

## Installation and Setup

### Prerequisites

- .NET 10 SDK
- Cursor or Visual Studio Code
- Git (optional)

### 1. Clone the Repository

```bash
git clone https://github.com/YOUR_USERNAME/TaskManagementSystem_73464.git
cd TaskManagementSystem_73464
```

Replace `YOUR_USERNAME` with your GitHub username.

### 2. Restore Dependencies

```bash
dotnet restore
```

### 3. Apply Database Migrations

```bash
dotnet ef database update
```

If the Entity Framework CLI tool is not installed, run:

```bash
dotnet tool install --global dotnet-ef
```

### 4. Run the Application

```bash
dotnet run
```

Open the localhost URL displayed in the terminal.

## How to Use

### User Management

1. Open the Users page.
2. Click Add User.
3. Enter the user's name and email.
4. Save the user.

### Task Management

1. Open the Tasks page.
2. Click Add Task.
3. Enter the task title and description.
4. Select the priority level.
5. Assign the task to a user.
6. Save the task.

### Editing and Deleting

- Click Edit to modify an existing task.
- Click Delete to open the confirmation page.
- Confirm deletion to remove the task.

### Sorting

Use the sorting dropdown to organize tasks by date or priority.

## Testing

The application was manually tested for:

- Creating a user
- Displaying registered users
- Creating a task
- Assigning a task to a user
- Editing task details and priority
- Opening the deletion confirmation page
- Deleting a task
- Sorting tasks by priority
- Displaying stored data from SQLite

## Screenshots

Screenshots can be stored in a `screenshots` folder.

Recommended screenshots:

1. Task management dashboard
2. User management page
3. Add Task form
4. Edit Task form
5. Delete confirmation page
6. Task sorting by priority

## Security and Limitations

This application is intended as a local educational project.

It does not implement user authentication or role-based access control. Additional security measures would be required before deploying it publicly.

NuGet dependency vulnerability warnings should be reviewed and resolved before production use.

## Future Improvements

- User authentication and authorization
- Task completion status
- Due dates and reminders
- Search and filtering
- Dashboard statistics
- Automated testing

## Project Information

**Project:** TaskManagementSystem_73464

**Framework:** ASP.NET Core MVC

**Database:** SQLite

**Development Environment:** Cursor

**Project ID:** 73464
