--PROJECT MODULE.......................................................>

CREATE PROCEDURE spViewProjectDetails
	@pId int
AS
BEGIN
	SET NOCOUNT OFF;
	SELECT Project.Project_ID, Project.Project_Name, Project.Project_StartDate, Project.Project_EndDate, 
	Project.Project_Details, Employee_Project.Employee_ID, Employee_Project.Project_Manager_ID 
	FROM Project JOIN Employee_Project
	on Project.Project_ID = Employee_Project.Project_ID
	Where Project.Project_ID = @pId;
END
GO
exec spViewProjectDetails 102;

CREATE PROCEDURE spAddProject
	@projectName NVARCHAR(100),
	@projectStartDate DATE,
	@projectEndDate DATE,
	@projectDetails NVARCHAR(300)
AS
BEGIN
	SET NOCOUNT OFF;
	INSERT INTO Project VALUES(@projectName, @projectStartDate, @projectEndDate, @projectDetails);
END
GO

exec spAddProject 'ABCD', '2020-09-18', '2020-10-19', 'ABCDEFGHIJKL';
select * from Project;


CREATE PROCEDURE spUpdateProject
	@pId int,
	@projectName NVARCHAR(100),
	@projectStartDate DATE,
	@projectEndDate DATE,
	@projectDetails NVARCHAR(300)
AS
BEGIN
	SET NOCOUNT OFF;
	UPDATE Project set Project_Name = @projectName, Project_StartDate = @projectStartDate, 
	Project_EndDate = @projectEndDate, Project_Details = @projectDetails where Project_ID = @pId;
END
GO


exec spUpdateProject @projectName ='aaa', @projectStartDate = '2020-08-05', @projectEndDate = '2020-09-08',
@projectDetails = 'abcdabcd', @pId =101;

select * from Project;


CREATE PROCEDURE spDeleteProject
	@pId int
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM Project where Project_ID = @pId;
END
GO

exec spDeleteProject 103;
select * from Project;

CREATE PROCEDURE spAssignProjectToEmployee
	@eId int,
	@pId int,
	@mId int
AS
BEGIN
	SET NOCOUNT OFF;
	INSERT INTO Employee_Project VALUES(@eId, @pId, @mId);
END
GO

exec spAssignProjectToEmployee 1002, 102, 1001;
select * from Employee_Project;


CREATE PROCEDURE spUpdateEmployeeOnProject
	@eId int,
	@pId int,
	@mId int
AS
BEGIN
	SET NOCOUNT OFF;
	UPDATE Employee_Project set Employee_ID = @eId, Project_Manager_ID = @mId where Project_ID = @pId; 
END
GO

exec spUpdateEmployeeOnProject @pId = 101, @eId = 1003, @mId = 1001

select * from Employee_Project ;


CREATE PROCEDURE spListProject
AS
BEGIN
	SET NOCOUNT OFF;
	SELECT Project_ID, Project_Name, Project_StartDate, Project_EndDate from Project
END
GO
exec spListProject;


--Attendance Module.....................................................................................

Create procedure spAddAttendance
	@Attedance_Type nvarchar(10),
	@Attedance_Date DATE,
	@In_Time TIME(0),
	@Out_Time TIME(0),
	@Status_Of_Attendance NVARCHAR(10),
	@Status_Update_Date DATE,
	@Status_Updated_By INT ,
	@Employee_ID INT,
	@Manager_ID int 
AS
BEGIN
	SET NOCOUNT OFF;
	insert into Attendance values(@Attedance_Type,@Attedance_Date,@In_Time,@Out_Time,
	@Status_Of_Attendance,@Status_Update_Date, @Status_Updated_By,@Employee_ID,@Manager_ID);
END
GO
 
 exec spAddAttendance 'aa','2020-08-08','20:00:00','20:00:00','gaa','2020-08-6',1001,1002,1001;
 select * from Attendance;

 /*-------------------------modify attendance------------------------*/

 Create procedure spModifyAttendance
	@aId int,
	@Attedance_Type nvarchar(10),
	@Attedance_Date DATE,
	@In_Time TIME(0),
	@Out_Time TIME(0),
	@Status_Of_Attendance NVARCHAR(10),
	@Status_Update_Date DATE,
	@Status_Updated_By INT,
	@Employee_ID INT,
	@Manager_ID int 
as 
BeGIN
 SET NOCOUNT OFF;
	update Attendance set Attedance_Type = @Attedance_Type,
	Attedance_Date= @Attedance_Date,
	In_Time= @In_Time,
	Out_Time= @Out_Time,
	Status_Of_Attendance = @Status_Of_Attendance,
	Status_Update_Date= @Status_Update_Date,
	Status_Updated_By = @Status_Updated_By,
	Employee_ID = @Employee_ID,
	Manager_ID = @Manager_ID 
	where Attendance_ID = @aId;
 END
 
 exec spModifyAttendance @Attedance_Type ='aaa',@Attedance_Date='2020-08-08',@In_Time='20:00:00',
 @Out_Time='20:00:00',@Status_Of_Attendance='ga',@Status_Update_Date ='2020-08-06',
 @Status_Updated_By=1001, @Employee_ID=1002,
 @Manager_ID=1001 , @aId = 3;

 select * from Attendance;

 /*---------------------delete Attendance---------------------------*/

 CREATE PROCEDURE spDeleteAttendance
	@aId int
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM Attendance where Attendance_ID = @aId;
END
GO

exec spDeleteAttendance 3;
select * from attendance;

/*---------------------------------attandanceDetailsDisplay------------------------*/

CREATE PROCEDURE spAttendanceDetailsDisplay

AS
BEGIN
	SET NOCOUNT OFF;
	select * from Attendance;
END
GO

exec spAttendanceDetailsDisplay ;


/*---------------------------------ApproveRejectAttendance--------------------------*/

CREATE PROCEDURE spApproveRejectAttendanceRequest
	@aId int,
	@Status_Of_Attendance varchar(10)
AS
BEGIN
	SET NOCOUNT OFF;
	update Attendance set Status_Of_Attendance = @Status_Of_Attendance where Attendance_ID = @aId; 
END
GO

exec spApproveRejectAttendanceRequest @status_Of_Attendance = 'p', @aId = 8;
select * from Attendance;


--=======================================================================================

--Request Leave
CREATE PROCEDURE spRequestLeave  
	@LeaveType NVARCHAR(30),
	@NoOfDays int,
	@LeaveBalance int,
	@LeaveDateFrom  Date,
	@LeaveDateTo Date,
	@Status nvarchar(30),
	@eId  int,
	@mId int
AS
BEGIN
	
	SET NOCOUNT OFF;
	INSERT INTO Leave VALUES(@LeaveType, @NoOfDays, @LeaveBalance, @LeaveDateFrom, @LeaveDateTo,@Status, @eId, @mId);
END
GO
select * from Employee;
Exec spRequestLeave 'x',5,5,'2020-10-12','2020-10-17','Pending',1002,1001;
Exec spRequestLeave 'p',2,3,'2020-10-12','2020-10-14','Accepted',1003,1001;
Exec spRequestLeave 'm',3,5,'2020-10-12','2020-10-15','Rejected',1004,1001;
Exec spRequestLeave 'p',1,4,'2020-10-12','2020-10-13','Pending',1002,1001;

select * from leave;


--Check Status of Leave Request
CREATE PROCEDURE spStatusOfLeave
  @LeaveRequestId int

As
Begin 
Set Nocount OFF;

select Leave_Status from Leave where leave.Leave_Request_ID=@LeaveRequestId;
END
GO

exec spStatusOfLeave 3


--Delete Leave Request
CREATE PROCEDURE spDeleteLeaveRequest
 @LeaveRequestId int

 As
Begin 
Set Nocount OFF;

delete  from Leave where leave.Leave_Request_ID=@LeaveRequestId;
END
GO

exec spDeleteLeaveRequest 3;

select * from Leave;


-- Modify requested leave
Create PROCEDURE spModifyLeaves 
  @LeaveRequestId int,
  @LeaveType NVARCHAR(30),
	@NoOfDays int,
	@LeaveBalance int,
	@LeaveDateFrom  Date,
	@LeaveDateTo Date,
	@Status nvarchar(30),
	@eId  int,
	@mId int
 As
Begin 
Set Nocount OFF;

UPDATE Leave  
            SET    LeaveType=  @LeaveType,  
                   NO_Of_Days = @NoOfDays,  
                   Leave_Balance = @LeaveBalance,  
                   Leave_Date_From = @LeaveDateFrom ,
				   Leave_Date_To=@LeaveDateTo,
				   Leave_Status=@Status,
				   Employee_ID=@eId,
				  Manager_ID =@mId
            WHERE  Leave_Request_ID = @LeaveRequestId 
END
GO

exec spModifyLeaves 2,'mm',5,08,'2020-11-12','2020-11-17','Accepted',1002,1001;

select * from Leave;


--Leave Credit
CREATE PROCEDURE spLeaveBalance

As
Begin 
Set Nocount OFF;

select Leave_Balance  from Leave ;
END
GO


--Leave History
Create Procedure spLeaveHistory
	 @EmployeeID int
 As
Begin 
Set Nocount OFF;

select * from Leave where Employee_ID=@EmployeeID;
END
GO


--List of Leave request in pending status
Create Procedure spApproveRejectLeaveRequest
	
 As
Begin 
Set Nocount OFF;

select * from Leave where Leave_Status  like'%Pending%' ;
END
GO

Exec spApproveRejectLeaveRequest;

--List of Requested Leaves
Create Procedure spListOfRequestedLeaves
	
 As
Begin 
Set Nocount on;

select * from Leave;
END
GO

exec spListOfRequestedLeaves;




/* Employee Module---------------------add employee-----------------------*/

CREATE PROCEDURE spAddEmployee	
	@Employee_Name NVARCHAR(50),
	@Employee_Email NVARCHAR(50) ,
	@Employee_Phone_Number NVARCHAR(13),
	@Employee_Role NVARCHAR(30),
	@Employee_Status NVARCHAR(10),
	@Employee_Password NVARCHAR(30),
	@mId INT,
	@pId INT 
AS
BEGIN
	SET NOCOUNT OFF;
	INSERT INTO Employee VALUES(@Employee_Name, @Employee_Email, @Employee_Phone_Number,
	@Employee_Role, @Employee_Status, @Employee_Password, @mId, @pId);
END
GO

exec spAddEmployee 'dhara', 'dhara@gmail.com','8888888888','Analyst','Active', 'password',1001,101;
select * from employee;

/*-----------------Delete Employee -------------------------*/
-- here i face some issue.................

--The DELETE statement conflicted with the REFERENCE constraint "FK__Employee___Emplo__29572725". The conflict occurred in database "Project_DB", table "dbo.Employee_Project", column 'Employee_ID'.

CREATE PROCEDURE spDeleteEmployee
	@eId int
AS
BEGIN
	SET NOCOUNT OFF;
	UPDATE Employee  SET Employee_Status = 'Inactive' where Employee_ID = @eId;
END
GO

select * from Employee

exec spDeleteEmployee 1003; 
select * from employee;
select * from Attendance;


/*---------------------------Modify employee details -----------------------------*/

CREATE PROCEDURE spModifyEmployeeDetails
	@eId int,
	@Employee_Name NVARCHAR(50),
	@Employee_Email NVARCHAR(50) ,
	@Employee_Phone_Number NVARCHAR(13),
	@Employee_Role NVARCHAR(30),
	@Employee_Status NVARCHAR(10),
	@Employee_Password NVARCHAR(30) ,
	@Manager_ID INT,
	@Project_Id INT 
AS
BEGIN
	SET NOCOUNT OFF;
	update Employee set  Employee_Name=@Employee_Name,
	Employee_Email=@Employee_Email,
	Employee_Phone_Number=@Employee_Phone_Number,
	Employee_Role=@Employee_Role,
	Employee_Status = @Employee_Status,
	Employee_Password=@Employee_Password,
	Manager_ID=@Manager_ID,
	Project_Id=@Project_Id
	where Employee_ID = @eId;
END
GO

exec spModifyEmployeeDetails 
@eId = 1002,
	@Employee_Name ='dhara',
	@Employee_Email = 'radha@gmail.com' ,
	@Employee_Phone_Number= '4545676765',
	@Employee_Role ='manager',
	@Employee_Status = 'Active',
	@Employee_Password = 'asdasd' ,
	@Manager_ID =1001,
	@Project_Id =101; 


	select * from employee;

	/*--------------------------login logout ---------------------------*/



CREATE PROCEDURE spLoginEmployee
	@eId int,
	@password nvarchar(10)
AS
BEGIN
	SET NOCOUNT OFF;
	select * from employee where Employee_ID = @eId and Employee_Password =@password;
END
GO

exec spLoginEmployee 1002, asdasd;


CREATE PROCEDURE spLoginAdmin
	@adminId int,
	@password nvarchar(10)
AS
BEGIN
	SET NOCOUNT OFF;
	select * from Admin where Admin_ID = @adminId and Admin_Password = @password;
END
GO

exec spLoginAdmin 100001, password;










