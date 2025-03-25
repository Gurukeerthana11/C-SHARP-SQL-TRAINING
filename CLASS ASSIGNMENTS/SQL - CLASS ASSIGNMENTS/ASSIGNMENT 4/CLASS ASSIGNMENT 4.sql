--CLASS ASSIGNMENT 4
use db;

--1. List unique departments of the EMP table. 
select distinct deptno from emp;

--2. List the name and salary of employees who earn more than 1500 and are in department 10 or 30. Label the columns Employee and Monthly Salary respectively.
select ename,sal from emp where sal > 1500 and deptno in (10,30)

--3. Display the name, job, and salary of all the employees whose job is MANAGER or  ANALYST and their salary is not equal to 1000, 3000, or 5000. 
select ename,job,sal from emp where job in ('manager','analyst') and sal not in (1000,3000,5000)

--4 Display the name, salary and commission for all employees whose commission amount is greater than their salary increased by 10%. 
select ename,sal,comm from emp where comm > sal*1.10;

--5. Display the name of all employees who have two Ls in their name and are in department 30 or their manager is 7782.
select ename from emp where ename like '%ll%' and deptno='30' or mgr_id=7782;

--6. Display the names of employees with experience of over 30 years and under 40 yrs. Count the total number of employees. 
select ename,FLOOR(DATEDIFF(DAY, hiredate, GETDATE())/ 365.25) from emp where FLOOR(DATEDIFF(DAY, hiredate, GETDATE())/ 365.25)  between 30 and 40;

--7.Retrieve the names of departments in ascending order and their employees in descending order.
select d.dname, e.ename from dept d join emp e on d.deptno = e.deptno order by d.dname asc, e.ename desc;
  
--8. Find out experience of MILLER. 
select floor(datediff(day,hiredate,getdate())/365.25) as"experience" from emp where ename='miller';

--9. Write a query to display all employee information where ename contains 5 or more characters
select * from emp where  len(ename) >=5;

--10. Copy empno, ename of all employees from emp table who work for dept 10 into a new table called emp10
select empno, ename into emp10 from emp where deptno = 10;
-- to display the above table -->select * from emp10;
