CREATE TABLE Project(
	Project_ID INT IDENTITY(101, 1) PRIMARY KEY NOT NULL,
	Project_Name NVARCHAR(100) NOT NULL,
	Project_StartDate DATE NOT NULL,
	Project_EndDate DATE NOT NULL,
	Project_Details NVARCHAR(300) NOT NULL	
);

insert into Project  Values('xyz', '2020-09-29', '2020-10-23', 'all');
insert into Project  Values('abc', '2020-09-29', '2021-12-03', 'alllllllll');
select * from Project;

CREATE TABLE Employee(
	Employee_ID INT IDENTITY(1001,1) PRIMARY KEY NOT NULL,
	Employee_Password NVARCHAR(30) NOT NULL,
	Employee_Name NVARCHAR(50) NOT NULL,
	Employee_Email NVARCHAR(50) unique NOT NULL,
	Employee_Phone_Number NVARCHAR(13) unique NOT NULL,
	Employee_Role NVARCHAR(30) NOT NULL,
	Manager_ID INT,
	Project_Id INT FOREIGN KEY references Project(Project_ID)
);

insert into Employee  Values('password', 'Amar', 'amar@gmail.com','8989789568','Analyst',1003,101);
insert into Employee  Values('pass', 'Amar  Kumar', 'apoddar@gmail.com','848849568','Analyst A4',1003,102);
insert into Employee  Values('passw', 'Amar  Kumar POddar', 'akpoddar@gmail.com','8458849568','Analyst A5',null,102);
select * from Employee;

drop table Employee_Project
CREATE TABLE Employee_Project(
	Employee_ID INT FOREIGN KEY references Employee(Employee_ID) ON DELETE SET NULL,
	Project_ID INT FOREIGN KEY references Project(Project_ID) ON DELETE CASCADE,
	Project_Manager_ID INT FOREIGN KEY references Employee(Employee_ID) ON DELETE NO ACTION
);

INSERT into Employee_Project values(1001, 101, 1003),(1002,102, 1003);
select * from Employee_Project;

drop table Attendance
CREATE TABLE Attendance(
	Attendance_ID INT IDENTITY PRIMARY KEY NOT NULL,
	Attedance_Type nvarchar(10) NOT NULL,
	Attedance_Date DATE NOT NULL,
	In_Time TIME(0) NOT NULL,
	Out_Time TIME(0) NOT NULL,
	Status_Of_Attendance NVARCHAR(10) NOT NULL,
	Status_Update_Date DATE NOT  NULL,
	Status_Updated_By INT FOREIGN KEY references Employee(EMPLOYEE_ID) ON DELETE NO ACTION,
	Employee_ID INT FOREIGN KEY references Employee(EMPLOYEE_ID) ON DELETE CASCADE,
	Manager_ID INT FOREIGN KEY references Employee(EMPLOYEE_ID) ON DELETE NO ACTION
);

insert into Attendance values('P','2020-09-29','08:30','16:00','A', '2020-08-16', 1003, 1001, 1003),
('ASDDD','2020-11-29','09:30','18:00','P', '2020-07-16', 1003, 1002, 1003);
select * from Attendance;

drop table Leave
CREATE TABLE Leave(
	Leave_Request_ID int IDENTITY PRIMARY KEY NOT NULL,
	LeaveType NVARCHAR(30) NOT NULL,
	NO_Of_Days int NOT NULL,
	Leave_Balance int NOT NULL,
	Leave_Date_From DATE NOT NULL,
	Leave_Date_To DATE NOT NULL,
	Leave_Status NVARCHAR(30) NOT NULL,
	Employee_ID INT FOREIGN KEY references Employee(EMPLOYEE_ID) ON DELETE CASCADE,
	Manager_ID INT FOREIGN KEY references Employee(EMPLOYEE_ID) ON DELETE NO ACTION

);

insert into Leave values('P',5,2,'2020-09-29','2020-09-30','pending',1001,1003),
('M',3,4,'2020-10-25','2020-10-30','Approved',1002,1003);
select * from Leave;


CREATE TABLE Admin(
	Admin_ID int IDENTITY(100001,1) PRIMARY KEY NOT NULL,
	Admin_Name NVARCHAR(30) NOT NULL,
	Admin_Password NVARCHAR(30) NOT NULL,
);

insert into Admin values('Amar','password'),('Kumar','pass');
select * from Admin;
select * from Leave;
Select * from Attendance;
Select * from Project;
select * from Employee;
Select * from Employee_Project;