--CLASS ASSSIGNMENT 2
use db
create table dept (
    deptno int primary key,
    dname varchar(30),
    loc varchar(30)
);
create table emp (
    empno int primary key,
    ename varchar(20) not null,
    job varchar(20),
    mgr_id int,
    hiredate date,
    sal int,
    comm int,
    deptno int,
    constraint fk_dept foreign key (deptno) references dept(deptno)
);
insert into dept (deptno, dname, loc) 
values 
    (10, 'ACCOUNTING', 'NEW YORK'),
    (20, 'RESEARCH', 'DALLAS'),
    (30, 'SALES', 'CHICAGO'),
    (40, 'OPERATIONS', 'BOSTON');
insert into emp (empno, ename, job, mgr_id, hiredate, sal, comm, deptno)
values
    (7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800, null, 20),
    (7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30),
    (7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30),
    (7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975, null, 20),
    (7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30),
    (7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850, null, 30),
    (7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450, null, 10),
    (7788, 'SCOTT', 'ANALYST', 7566, '1987-04-19', 3000, null, 20),
    (7839, 'KING', 'PRESIDENT', null, '1981-11-17', 5000, null, 10),
    (7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30),
    (7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, null, 20),
    (7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950, null, 30),
    (7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000, null, 20),
    (7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, null, 10);
select*from emp;
select * from dept;
--1. List all employees whose name begins with 'A'. 
select * from emp where ename like 'A%';

--2. Select all those employees who don't have a manager. 
select * from emp where mgr_id is null;

--3. List employee name, number and salary for those employees who earn in the range 1200 to 1400. 
select ename,empno,sal from emp where sal >=1200 and sal<=1400;

--4.Give all the employees in the RESEARCH department a 10% pay rise. Verify that this has been done by listing all their details before and after the rise.
select  e.empno, e.ename, e.job, e.sal as "current salary", e.sal * 1.10 as "new salary", d.dname as "department" from emp e join dept d on e.deptno = d.deptno where d.dname = 'research';

--5.Find the number of CLERKS employed. Give it a descriptive heading. 
select count(*) as "Number of Clerks Employed" from emp where job = 'clerk';

--6. Find the average salary for each job type and the number of people employed in each job. 
select avg(sal) as "avgsalary of clerk" from emp where job='clerk' ;
select avg(sal) as "avgsalary of salesman" from emp where job='salesman' ;
select avg(sal) as "avgsalary of manager" from emp where job='manager' ;
select avg(sal) as "avgsalary of analyst" from emp where job='analyst' ;
select avg(sal) as "avgsalary of president" from emp where job='president' ;

--7. List the employees with the lowest and highest salary. 
select ename from emp where sal=(select max(sal) from emp);
select ename from emp where sal=(select min(sal) from emp);

--8. List full details of departments that don't have any employees. 
select * from dept where deptno not in (select distinct deptno from emp);

--9. Get the names and salaries of all the analysts earning more than 1200 who are based in department 20. Sort the answer by ascending order of name.
select ename,sal from emp where job='analyst' and sal>1200 and deptno='20' order by ename asc;

--10. For each department, list its name and number together with the total salary paid to employees in that department. 
select d.dname,d.deptno,sum(e.sal) as "total salary paid" from dept d   join emp e on d.deptno=e.deptno group by d.dname,d.deptno;

--11. Find out salary of both MILLER and SMITH.
select sal from emp where ename in ('miller','smith');

--12. Find out the names of the employees whose name begin with ‘A’ or ‘M’. 
select ename from emp where ename like 'A%' or ename like 'M%';

--13. Compute yearly salary of SMITH.
select ename, sal * 12 from emp where ename = 'smith';

--14. List the name and salary for all employees whose salary is not in the range of 1500 and 2850. 
select ename, sal from emp where sal not between 1500 and 2850;

--15. Find all managers who have more than 2 employees reporting to them
select mgr_id,count(empno) as "no of people mapped under a manager" from emp group by mgr_id having count(empno)>2  ;

