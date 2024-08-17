# Healthcare Appointment Booking System

## Overview

This is a healthcare appointment booking system built using ASP.NET MVC (.NET 8) with a focus on n-tier architecture. The system enables patients to book appointments with doctors and manage their medical records. It incorporates robust authentication and authorization features, ensuring that both doctors and patients can securely access and manage their data.

## Features

- N-Tier Architecture: The project is structured with a clear separation of concerns, enhancing maintainability and scalability.
- Models: The system includes five core models:
  - Doctor: Manages the list of doctors available for appointments.
  - Patient: Allows patients to register, log in, and book appointments.
  - MedicalRecord: Doctors can add and manage medical records for their patients.
  - Appointments: Patients can view available time slots and book appointments.
  - AvailableTimeSlots: Shows doctors' available time slots for booking appointments.
- Authentication and Authorization: Implemented using ASP.NET Identity, with role-based access control for doctors and patients.
- Repository Pattern: Simplifies data access and improves testability.
- IUnitOfWork: Ensures atomicity of database operations, improving data consistency.
- AutoMapper: Streamlines object-to-object mapping between different layers.
- EF Core: Used for data mapping between the application and MSSQL Server database.
- Asynchronous Programming: Enhances performance and scalability by making use of async/await in data access layers.
- Notification Service: Provides real-time notifications for appointment updates and other important events, improving user engagement and communication.

## Getting Started

### Prerequisites

- .NET 8 SDK
- MSSQL Server

### Installation
1. Clone the repository:
2. Navigate to the project directory:
3. Restore NuGet packages:
4. Update the connection string in appsettings.json to point to your MSSQL Server instance.
5. Apply migrations to set up the database:
6. Run the application

## Usage

- Doctor:
  - Register and log in to manage patient medical records.
  - View and update available time slots.
- Patient:
  - Register and log in to view a list of doctors.
  - View available time slots and book appointments.
  - Access and review personal medical records.

## Technologies Used
- ASP.NET MVC (.NET 8)
- Entity Framework Core (EF Core)
- MSSQL Server
- ASP.NET Identity
- AutoMapper
- Repository Pattern
- IUnitOfWork

## Team Members
 - [Ahmed Elmaadawy](https://github.com/ahmedelmaadawy)
 - [Mohamed Mostafa Dohdoh](https://github.com/mohamedmoustafaeg)
 - [Mohamed Saber](https://github.com/muhamedsaber1234)
 - [Islam Ragab](https://github.com/ragaabislam)
 - [Abdelrahman Elbahnasawy](https://github.com/Abdelrhman066)

# Contact
For any inquiries or feedback, please contact me at ahmed.elmaadawy03@gmail.com.
