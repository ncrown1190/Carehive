CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1, 1),
	UserName NVARCHAR(100),
	LoginId nvarchar(50) NOT NULL,
	Email nvarchar(100) Not NULL,
    PasswordHash VARBINARY(MAX) NOT NULL,
	Phone nvarchar(15),
    Role NVARCHAR(50) NOT NULL,
	Address NVARCHAR(255) NULL,
    CreatedDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE Doctors (
    DoctorId INT PRIMARY KEY IDENTITY(1, 1),
    UserId INT NOT NULL UNIQUE,
    Specialty NVARCHAR(100),   -- e.g., Cardiologist, Dentist
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

CREATE TABLE Appointments (
    AppointmentId INT PRIMARY KEY IDENTITY,
    PatientId INT NOT NULL,
    DoctorId INT NOT NULL,
    AppointmentDate date,
	AppointmentTime Time,
    Status NVARCHAR(50) DEFAULT 'Pending', -- Pending, Confirmed, Completed, Cancelled
    FOREIGN KEY (PatientId) REFERENCES Users(UserId),
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId)
);

CREATE TABLE Schedules (
    ScheduleId INT PRIMARY KEY IDENTITY,
    DoctorId INT NOT NULL,
	scheduleDate date not null,
    AvailableFrom time not null,
    AvailableTo TIME not null,
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId)
);

CREATE TABLE Payments (
    PaymentId INT PRIMARY KEY IDENTITY(1, 1),
    AppointmentId INT NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL,
	PaymentStatus NVARCHAR(50) DEFAULT 'Pending', -- Paid, Pending, Failed
    PaymentDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (AppointmentId) REFERENCES Appointments(AppointmentId)
);

insert into Users(UserName, LoginId, Email, passwordHash, phone, Role, Address)
Values('Nahid Taj', 'nahida', 'nahid@nah.com', HASHBYTES('SHA2_256','hello123'), '554-433-2211', 'Patient', 'Somewhere Detroit');

insert into Users(UserName, LoginId, Email, passwordHash, phone, Role, Address)
Values('Dr. Akram Shetty', 'shetty', 'shettyd@nah.com', HASHBYTES('SHA2_256','shetty@123'), '554-433-2212', 'Doctor', '123 Green st Detroit');

insert into Doctors(userId, Specialty)
Values(2, 'ENT');

insert into Users(UserName, LoginId, Email, passwordHash, phone, Role, Address)
Values('Dr. Emily Carter', 'carter', 'carterd@nah.com', HASHBYTES('SHA2_256','carter@123'), '554-433-2213', 'Doctor', '126 Green st Detroit');

insert into Doctors(userId, Specialty)
Values(3, 'Family medicine');

Insert Into Appointments(PatientId, DoctorId, AppointmentDate, AppointmentTime, Status)
Values(1, 2, '2025-04-27',  '10:00:00', 'confirmed');

insert into Users(UserName, LoginId, Email, passwordHash, phone, Role, Address)
Values('Priy Ajay', 'ajay', 'ajay@nah.com', HASHBYTES('SHA2_256','ajai@123'), '554-433-2215', 'Patient', '125 Green st Detroit');

Insert Into Appointments(PatientId, DoctorId, AppointmentDate, AppointmentTime, Status)
Values(4, 1, '2025-04-28',  '11:00:00', 'confirmed');

insert into Users(UserName, LoginId, Email, passwordHash, phone, Role, Address)
Values('Dr.Amolia Tylor', 'tylor', 'tylord@nah.com', HASHBYTES('SHA2_256','tylor@123'), '544-433-2212', 'Doctor', '123 Green st Detroit');

insert into Users(UserName, LoginId, Email, passwordHash, phone, Role, Address)
Values('Dr.Amy John', 'amy', 'amyjohnd@nah.com', HASHBYTES('SHA2_256','john@123'), '644-433-2212', 'Doctor', '1256 Gost st Detroit');

insert into Users(UserName, LoginId, Email, passwordHash, phone, Role, Address)
Values('Khol Parmar', 'parmar', 'parmar@nah.com', HASHBYTES('SHA2_256','parmar@123'), '676-433-2212', 'Patient', '1433 white street Detroit MI');

insert into Doctors(userId, Specialty)
Values(5, 'dentist');

insert into Doctors(userId, Specialty)
Values(6, 'Cardiologist');

insert into Doctors(userId, Specialty)
Values(7, 'Orthopedics');

 insert into Users(UserName, LoginId, Email, passwordHash, phone, Role, Address)
Values('Mariya Nasir', 'mariya', 'mariya@nah.com', HASHBYTES('SHA2_256','maria@123'), '676-444-2212', 'Patient', '1433 black street Detroit MI');

 insert into Users(UserName, LoginId, Email, passwordHash, phone, Role, Address)
Values('Dr. Allen Bist', 'allen', 'allen@nah.com', HASHBYTES('SHA2_256','allen123@'), '567-488-2244', 'Doctor', '1433 Field view street Detroit MI');

insert into Users(UserName, LoginId, Email, passwordHash, phone, Role, Address)
Values('Andrea Tim', 'Andrea', 'andrea@nah.com', HASHBYTES('SHA2_256','andrea@123'), '554-433-7788', 'Admin', '456 Green St Detroit MI');

insert into Users(UserName, LoginId, Email, passwordHash, phone, Role, Address)
Values('David Montu', 'Montu', 'montu@gmail.com', HASHBYTES('SHA2_256','montu@123'), '556-678-9923', 'Patient', 'Westland MI');