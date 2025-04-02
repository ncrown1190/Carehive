Create Database AppointmentDb;

CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL, -- Store hashed passwords
    Role NVARCHAR(50) NOT NULL, -- Patient, Doctor, or Admin
    PhoneNumber NVARCHAR(15) NULL,
    Address NVARCHAR(255) NULL,
    CreatedDate DATETIME DEFAULT GETDATE()
);
CREATE TABLE Doctors (
    DoctorId INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    Specialty NVARCHAR(100) NOT NULL, -- e.g., Cardiologist, Dentist
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PhoneNumber NVARCHAR(15) NULL,
    AvailabilityStatus NVARCHAR(50) DEFAULT 'Available', -- Available, On Leave
    CreatedDate DATETIME DEFAULT GETDATE()
);
CREATE TABLE Appointments (
    AppointmentId INT PRIMARY KEY IDENTITY(1,1),
    PatientId INT NOT NULL,
    DoctorId INT NOT NULL,
    AppointmentDateTime DATETIME NOT NULL,
    Status NVARCHAR(50) DEFAULT 'Pending', -- Pending, Confirmed, Completed, Cancelled
    CreatedDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (PatientId) REFERENCES Users(UserId),
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId)
);
CREATE TABLE Schedules (
    ScheduleId INT PRIMARY KEY IDENTITY(1,1),
    DoctorId INT NOT NULL,
    Date DATE NOT NULL,
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    IsAvailable BIT DEFAULT 1, -- 1 for available, 0 for unavailable
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId)
);
CREATE TABLE Payments (
    PaymentId INT PRIMARY KEY IDENTITY(1,1),
    AppointmentId INT NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL,
    PaymentStatus NVARCHAR(50) DEFAULT 'Pending', -- Paid, Pending, Failed
    PaymentDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (AppointmentId) REFERENCES Appointments(AppointmentId)
);
INSERT INTO Users (FullName, Email, Password, Role, PhoneNumber, Address, CreatedDate)
VALUES 
('John Doe', 'john.doe@example.com', 'hashed_password_1', 'Patient', '123-456-7890', '123 Elm St', GETDATE()),
('Jane Smith', 'jane.smith@example.com', 'hashed_password_2', 'Patient', '234-567-8901', '456 Oak St', GETDATE()),
('Dr. Emily Carter', 'emily.carter@example.com', 'hashed_password_3', 'Doctor', '345-678-9012', '789 Maple St', GETDATE()),
('Admin User', 'admin@example.com', 'hashed_password_4', 'Admin', '456-789-0123', 'Admin Office', GETDATE());


INSERT INTO Doctors (FullName, Specialty, Email, PhoneNumber, AvailabilityStatus, CreatedDate)
VALUES 
('Dr. Emily Carter', 'Cardiologist', 'emily.carter@example.com', '345-678-9012', 'Available', GETDATE()),
('Dr. Michael Scott', 'Dentist', 'michael.scott@example.com', '567-890-1234', 'Available', GETDATE()),
('Dr. Rachel Green', 'Dermatologist', 'rachel.green@example.com', '678-901-2345', 'On Leave', GETDATE());

INSERT INTO Appointments (PatientId, DoctorId, AppointmentDateTime, Status, CreatedDate)
VALUES 
(1, 1, '2025-04-01 10:00:00', 'Pending', GETDATE()),
(2, 2, '2025-04-01 11:30:00', 'Confirmed', GETDATE()),
(1, 3, '2025-04-02 14:00:00', 'Completed', GETDATE());

INSERT INTO Schedules (DoctorId, Date, StartTime, EndTime, IsAvailable)
VALUES 
(1, '2025-04-01', '09:00:00', '17:00:00', 1),
(2, '2025-04-01', '10:00:00', '15:00:00', 1),
(3, '2025-04-02', '09:00:00', '12:00:00', 0);

INSERT INTO Payments (AppointmentId, Amount, PaymentStatus, PaymentDate)
VALUES 
(1, 150.00, 'Pending', GETDATE()),
(2, 200.00, 'Paid', GETDATE()),
(3, 75.50, 'Failed', GETDATE());