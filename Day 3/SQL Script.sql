create database employeeDB

use employeeDB

create table employeeDetails
(
	empNo int primary key,
	empName varchar(20),
	empDesigantion varchar(20),
	empSalary int,
	empIsPermenant bit
)

insert into employeeDetails values(101,'Karan','Sales',6000,1)
insert into employeeDetails values(102,'Kiran','Sales',6000,1)
insert into employeeDetails values(103,'Mohan','Accounts',6000,1)
insert into employeeDetails values(104,'Priya','Sales',6000,0)

select * from employeeDetails



create table deptinfo
(
	dNo int primary key,
	dName varchar(20),
	dLocation varchar(20),
	dEmail varchar(20)
)

insert into deptinfo values(1,'Accounts','Mumbai','accounts@myorg.com')
insert into deptinfo values(2,'Sales','Pune','sales@myorg.com')
insert into deptinfo values(3,'HR','New York','hr@myorg.com')
insert into deptinfo values(4,'IT','London','it@myorg.com')
insert into deptinfo values(5,'Transport','Bangalore','trans@myorg.com')

alter table employeedetails add dept int
alter table employeedetails add constraint fk_dept foreign key(dept) references deptinfo

select * from employeeDetails






























