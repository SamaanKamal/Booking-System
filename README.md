# Booking-System

## Overview

The Booking System is a simple application that allows users to book resources for specific time periods. It manages various resources, such as laptops and projectors, ensuring availability and preventing booking conflicts.

## Features

- View available resources
- Book resources based on availability
- Simple conflict validation
- Seeded initial data for testing
- Display success and error messages based on booking status


## Prerequisites

Make sure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download/dotnet) (version 8.0 or later)
- SQLite (for database storage)
- Node.js
- [npm](https://www.npmjs.com/) (Node package manager, usually comes with Node.js)
  
## Getting Started

Follow these steps to set up and run the application.

### 1. Clone the Repository

```bash
git clone https://github.com/SamaanKamal/Booking-System.git
cd Booking-System
```

### For Backend:
### 1. Navigate to the Backend Directory
Change to the directory where the backend code is located:

```bash
cd Backend
cd Booking System
cd Booking Sysetm
```
### 2. Restore NuGet Packages

```bash
dotnet restore
```
### 3.Apply Database Migrations

```bash
dotnet ef database update
```
### 4.run the project
```bash
dotnet run
```

### For Frontend:
### 1. Navigate to the Frontend Directory
Change to the directory where the frontend code is located:

```bash
cd Frontend
cd Booking-System
```
### 2. Install Dependencies
Run the following command to install the necessary packages:
```bash
npm install
```
### 3. Run the Application
You can now run the application with:
```bash
npm run dev
```

### Access the application 
now you can access the application 
Access the Application
Once you run both the backend and frontend projects, open your browser and navigate to:

Booking System: http://localhost:5173
Here you will find a list of resources, and you can start booking based on date and quantity validation.

Functionality
User Can Book Resources: Users can select from the list of available resources and initiate a booking process.

Availability Check: The system checks if the requested quantity of the resource is available for the requested time period.

Error Handling:

If the requested resource is unavailable, an error message is displayed to the user.
Upon successful booking, a success message is shown.
Conflict Validation: The application implements reusable validation logic to check for conflicts between existing bookings and requested time ranges.

Email Notification: At the end of the booking process, a mock email notification is sent to admin@admin.com, which is represented by a console message:

```css
EMAIL SENT TO admin@admin.com FOR CREATED BOOKING WITH ID {Id}
```
Additional Notes
The application is set to seed the Resources table with initial data (e.g., laptops, projectors) upon startup.
Ensure that your database file (e.g., booking_system.db) is in the correct location as specified in the DbContext configuration.
Contributing
Feel free to submit issues or pull requests if you have suggestions for improvements or bug fixes.

License
This project is licensed under the MIT License.

```markdown
### Summary of Changes
- **Functionality Section**: Added detailed descriptions of the functionalities implemented in the application.
- **Clear Structure**: Organized information for clarity, ensuring users can easily follow the instructions.

Let me know if you need any further modifications or additions!
```
