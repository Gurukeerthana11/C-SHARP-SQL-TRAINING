USE HEXADB
CREATE TABLE Clients (
    Client_ID INT PRIMARY KEY,
    Cname VARCHAR(40) NOT NULL,
    Address VARCHAR(30),
    Email VARCHAR(30) UNIQUE,
    Phone BIGINT,
    Business VARCHAR(20) NOT NULL
);
create table departments (
    deptno int primary key,
    dname varchar(15) not null,
    loc varchar(20)
);
create table employees (
    empno int primary key,
    ename varchar(20) not null,
    job varchar(15),
    salary decimal(10, 2) check (salary > 0),
    deptno int,
    constraint fk_dept foreign key (deptno) references departments(deptno)
);
create table projects (
    project_id int primary key,
    descr varchar(30) not null,
    start_date date,
    planned_end_date date,
    actual_end_date date ,
    budget int,
    client_id int,
    constraint fk_client foreign key (client_id) references clients(client_id)
);
create table empprojecttasks (
    project_id int,
    empno int,
    start_date date,
    end_date date,
    task varchar(25) not null,
    status varchar(15) not null,
    primary key (project_id, empno),
    constraint fk_project foreign key (project_id) references projects(project_id),
    constraint fk_employee foreign key (empno) references employees(empno)
);
insert into clients values (1001, 'ACME Utilities', 'Noida', 'contact@acmeutil.com', 9567880032, 'Manufacturing');
insert into clients values (1002, 'Trackon Consultants', 'Mumbai', 'consult@trackon.com', 8734210090, 'Consultant');
insert into clients values (1003, 'MoneySaver Distributors', 'Kolkata', 'save@moneysaver.com', 7799886655, 'Reseller');
insert into clients values (1004, 'Lawful Corp', 'Chennai', 'justice@lawful.com', 9210342219, 'Professional');

insert into departments values (10, 'Design', 'Pune');
insert into departments values (20, 'Development', 'Pune');
insert into departments values (30, 'Testing', 'Mumbai');
insert into departments values (40, 'Document', 'Mumbai');

insert into employees values (7001, 'Sandeep', 'Analyst', 25000, 10);
insert into employees values (7002, 'Rajesh', 'Designer', 30000, 10);
insert into employees values (7003, 'Madhav', 'Developer', 40000, 20);
insert into employees values (7004, 'Manoj', 'Developer', 40000, 20);
insert into employees values (7005, 'Abhay', 'Designer', 35000, 10);
insert into employees values (7006, 'Uma', 'Tester', 30000, 30);
insert into employees values (7007, 'Gita', 'Tech. Writer', 30000, 40);
insert into employees values (7008, 'Priya', 'Tester', 35000, 30);
insert into employees values (7009, 'Nutan', 'Developer', 45000, 20);
insert into employees values (7010, 'Smita', 'Analyst', 20000, 10);
insert into employees values (7011, 'Anand', 'Project Mgr', 65000, 10);

insert into projects values (401, 'Inventory', '2011-04-01', '2011-10-01', '2011-10-31', 150000, 1001);
insert into projects values (402, 'Accounting', '2011-08-01', '2012-01-01', null, 500000, 1002);
insert into projects values (403, 'Payroll', '2011-10-01', '2011-12-31', null, 75000, 1003);
insert into projects values (404, 'Contact Mgmt', '2011-11-01', '2011-12-31', null, 50000, 1004);

insert into empprojecttasks values (401, 7001, '2011-04-01', '2011-04-20', 'System Analysis', 'Completed');
insert into empprojecttasks values (401, 7002, '2011-04-21', '2011-05-30', 'System Design', 'Completed');
insert into empprojecttasks values (401, 7003, '2011-06-01', '2011-07-15', 'Coding', 'Completed');
insert into empprojecttasks values (401, 7004, '2011-07-18', '2011-09-01', 'Coding', 'Completed');
insert into empprojecttasks values (401, 7006, '2011-09-03', '2011-09-15', 'Testing', 'Completed');
insert into empprojecttasks values (401, 7009, '2011-09-18', '2011-10-05', 'Code Change', 'Completed');
insert into empprojecttasks values (401, 7008, '2011-10-06', '2011-10-16', 'Testing', 'Completed');
insert into empprojecttasks values (401, 7007, '2011-10-06', '2011-10-22', 'Documentation', 'Completed');
insert into empprojecttasks values (401, 7011, '2011-10-22', '2011-10-31', 'Sign off', 'Completed');
insert into empprojecttasks values (402, 7010, '2011-08-01', '2011-08-20', 'System Analysis', 'Completed');
insert into empprojecttasks values (402, 7002, '2011-08-22', '2011-09-30', 'System Design', 'Completed');
insert into empprojecttasks values (402, 7004, '2011-10-01', null, 'Coding', 'In Progress');

SELECT * FROM Employees;
SELECT * FROM CLIENTS;
SELECT * FROM PROJECTS;
SELECT * FROM EmpProjectTasks;
