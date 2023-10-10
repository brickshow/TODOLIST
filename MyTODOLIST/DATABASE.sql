create database TODOLIST



create table TaskTable (
taskID int not null identity (1,1) primary key,
taskTitle varchar(100) not null,
startDate datetime not null,
dueDate datetime not null,
dateCompleted datetime
)

select * from TaskTable

insert into TaskTable (taskTitle, startDate, dueDate) values 
('Assignment', '10/10/2023', '10/10/2023')


alter table TaskTable
alter column dueDate date

