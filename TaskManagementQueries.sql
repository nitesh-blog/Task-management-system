--verify schemas
Select *from sys.schemas where name= 'TaskManagement'

--User Table
Create Table TaskManagement.Users(
UserId int primary key identity(1,1),
Username nvarchar(50) not null unique,
Email nvarchar(100) not null unique,
passwordHash nvarchar(255) not null,
CreatedAt datetime default getDate()

);

--insert data for user table
insert into TaskManagement.Users(Username,Email,passwordHash,CreatedAt) values
('Jone_doe','jonedoe@gmail.com','jon@1234',GETDATE()),
('Admin','admin@gmail.com','admin@1234',GETDATE()),
('Jame_smith','jamesmith@gmail.com','jame@1234',GETDATE());
use TaskManagementDB;
select *from TaskManagement.Users;

--ROLES TABLE
CREATE TABLE TaskManagement.Roles(
RoleId INT PRIMARY KEY IDENTITY(1,1),
RoleName NVARCHAR(50) NOT NULL UNIQUE
);

--insert data in role table
insert into TaskManagement.Roles(RoleName) values ('Admin'),('Manager'),('User');
select *from TaskManagement.Roles;


--UserRoles Table
CREATE TABLE TaskManagement.UserRoles(
UserId INT NOT NULL,
RoleId INT NOT NULL,
PRIMARY KEY(UserId,RoleId),
FOREIGN KEY(UserId) REFERENCES TaskManagement.Users(UserId),
FOREIGN KEY (RoleId) REFERENCES TaskManagement.Roles(RoleId)
);

--insert data to userroles
insert into TaskManagement.UserRoles(UserId,RoleId) values (1,2);
insert into TaskManagement.UserRoles(UserId,RoleId) values (2,1);
insert into TaskManagement.UserRoles(UserId,RoleId) values (3,3);
select *from TaskManagement.UserRoles;

--Tasks Table
CREATE TABLE TaskManagement.Tasks(
TaskId INT PRIMARY KEY IDENTITY(1,1),
TaskName NVARCHAR(255) NOT NULL,
Description NVARCHAR(MAX),
CreatedBy INT NOT NULL,
AssignedTo INT NULL,
CreatedAt DATETIME DEFAULT GETDATE(),
DueDate DATETIME NULL,
Priority NVARCHAR(50) NOT NULL,
StatusId INT NOT NULL,
FOREIGN KEY (CreatedBy) REFERENCES TaskManagement.Users(UserId),
FOREIGN KEY (AssignedTo) REFERENCES TaskManagement.Users(UserId),
FOREIGN KEY (StatusId) REFERENCES TaskManagement.TaskStatus(StatusId)

);

--insert data in tsak table
insert into TaskManagement.Tasks(TaskName,Description,CreatedBy,AssignedTo,CreatedAt,DueDate,Priority,StatusId) values ('Task 1','Complete the project.',3,1,GETDATE(),'2024-10-05','High',1),('Task 2','Complete the project.',1,3,GETDATE(),'2024-12-08','Medium',2);
select * from TaskManagement.Tasks;

--Task Status Table
CREATE TABLE TaskManagement.TaskStatus(
StatusId INT PRIMARY KEY IDENTITY(1,1),
StatusName NVARCHAR(50) NOT NULL UNIQUE
);

insert into TaskManagement.TaskStatus(StatusName) values ('Pending'),('In Progress'),('Completed'),('Overdue');
select *from TaskManagement.TaskStatus;

--Task Assignment Table
CREATE TABLE TaskManagement.TaskAssignments(
TaskId INT NOT NULL,
UserId INT NOT NULL,
AssignedAt DATETIME DEFAULT GETDATE(),
PRIMARY KEY (TaskId,UserId),
FOREIGN KEY (TaskId) REFERENCES TaskManagement.Tasks(TaskId),
FOREIGN KEY (UserId) REFERENCES TaskManagement.Users(UserId),

);

--insert data in Task Assignment
insert into TaskManagement.TaskAssignments(TaskId,UserId,AssignedAt) values (5,1,GETDATE()),(6,3,GETDATE());
select *from TaskManagement.TaskAssignments;

--Task Comments Table
CREATE TABLE TaskManagement.TaskComments(
CommentId INT PRIMARY KEY IDENTITY(1,1),
TaskId INT NOT NULL,
UserId INT NOT NULL,
CommentText NVARCHAR(MAX) NOT NULL,
CreatedAt DATETIME DEFAULT GETDATE(),
FOREIGN KEY (TaskId) REFERENCES TaskManagement.Tasks(TaskId),
FOREIGN KEY (UserId) REFERENCES TaskManagement.Users(UserId),
);

--insert data in history table
insert into TaskManagement.TaskComments(TaskId,UserId,CommentText,CreatedAt) values (5,1,'Hi Jame i completed this task please review and closed this task.',GETDATE());
Select *from TaskManagement.TaskComments;
--Task History Table
CREATE TABLE TaskManagement.TaskHistory(
HistoryId INT PRIMARY KEY IDENTITY(1,1),
TaskId INT NOT NULL,
StatusId INT NOT NULL,
ChangedBy INT NOT NULL,
ChangedAt DATETIME DEFAULT GETDATE(),
FOREIGN KEY (TaskId) REFERENCES TaskManagement.Tasks(TaskId),
FOREIGN KEY (StatusId) REFERENCES TaskManagement.TaskStatus(StatusId),
FOREIGN KEY (ChangedBy) REFERENCES TaskManagement.Users(UserId)
);

--insert data in History Table
insert into TaskManagement.TaskHistory  (TaskId,StatusId,ChangedBy,ChangedAt) values (5,1,3,DATEADD(DAY,-3,GETDATE()));
select *from TaskManagement.TaskHistory;


use TaskManagementDB
--All Tables
--1
select *from TaskManagement.Users;
--2
select *from TaskManagement.Roles;
--3
select *from TaskManagement.UserRoles;
--4
select *from TaskManagement.TaskStatus;
--5
select *from TaskManagement.Tasks;
--6
select *from TaskManagement.TaskAssignments;
--7
select *from TaskManagement.TaskComments;
--8
select *from TaskManagement.TaskHistory;




-------------------------------------------------

SELECT TOP (1000) [UserId]
      ,[UserName]
      ,[Email]
      ,[PasswordHash]
      ,[CreatedAt]
  FROM [TaskManagementSystemDB].[dbo].[Users]

  insert into TaskManagementSystemDB.dbo.Users(UserName,Email,PasswordHash,CreatedAt) values
('Jone_doe','jonedoe@gmail.com','jon@1234',GETDATE()),
('Jame_smith','jamesmith@gmail.com','jame@1234',GETDATE());

  SELECT TOP (1000) [RoleId]
      ,[RoleName]
  FROM [TaskManagementSystemDB].[dbo].[Roles]

  insert into TaskManagementSystemDB.dbo.Roles(RoleName) values ('Admin'),('Manager'),('User');

  SELECT TOP (1000) [UserId]
      ,[RoleId]
  FROM [TaskManagementSystemDB].[dbo].[UserRoles]

insert into TaskManagementSystemDB.dbo.UserRoles(UserId,RoleId) values (1,2);
insert into TaskManagementSystemDB.dbo.UserRoles(UserId,RoleId) values (2,1);
insert into TaskManagementSystemDB.dbo.UserRoles(UserId,RoleId) values (3,3);


  SELECT TOP (1000) [TaskId]
      ,[TaskName]
      ,[Description]
      ,[CreatedAt]
      ,[DueDate]
      ,[Priority]
      ,[TaskStatusId]
      ,[TaskStatuses]
      ,[CreatedBy]
      ,[AssignedTo]
  FROM [TaskManagementSystemDB].[dbo].[Tasks]

  insert into TaskManagementSystemDB.dbo.Tasks(TaskName,Description,CreatedAt,DueDate,Priority,TaskStatusId,TaskStatuses,CreatedBy,AssignedTo) values ('Task 1','Complete the project.','2024-10-05','2024-10-20','High',1,'',1,3);

  SELECT TOP (1000) [TaskStatusId]
      ,[statusName]
  FROM [TaskManagementSystemDB].[dbo].[TaskStatuses]

  insert into TaskManagementSystemDB.dbo.TaskStatuses(statusName) values ('Pending'),('In Progress'),('Completed'),('Overdue');


SELECT TOP (1000) [TaskId]
      ,[UserId]
  FROM [TaskManagementSystemDB].[dbo].[TaskAssignments]

  insert into TaskManagementSystemDB.dbo.TaskAssignments(TaskId,UserId) values (4,1);


  SELECT TOP (1000) [TaskCommentId]
      ,[CommentText]
      ,[CreatedAt]
      ,[UserId]
      ,[TaskId]
  FROM [TaskManagementSystemDB].[dbo].[TaskComments]

  insert into [TaskManagementSystemDB].[dbo].TaskComments(CommentText,CreatedAt,UserId,TaskId) values ('Hi Jame i completed this task please review and closed this task.',GETDATE(),1,4);


  SELECT TOP (1000) [TaskHistoryId]
      ,[Description]
      ,[ChangedAt]
      ,[TaskId]
  FROM [TaskManagementSystemDB].[dbo].[TaskHistory]

  


