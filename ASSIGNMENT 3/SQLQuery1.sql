use db;
--1.Retrieve a list of MANAGERS
select * from emp where job = 'manager';

--2. Find out the names and salaries of all employees earning more than 1000 per month.
select ename,sal from emp where sal > 1000;

--3. Display the names and salaries of all employees except JAMES. 
select ename,sal from emp where ename not like 'james';

--4.Find out the details of employees whose names begin with ‘S’. 
select ename from emp where ename like 'S%';

--5. Find out the names of all employees that have ‘A’ anywhere in their name. 
select ename from emp where ename like '%A%';

--6. Find out the names of all employees that have ‘L’ as their third character in their name.
select ename from emp where ename like '__L%'

--7. Compute daily salary of JONES. 
select sal/30 as "daily salary of jones" from emp where ename='jones';

--8. Calculate the total monthly salary of all employees. 
select sum(sal) as"total salary" from emp;

--9. Print the average annual salary .
select avg( sal*12 ) as "average annual salary" from emp;

--10. Select the name, job, salary, department number of all employees except  SALESMAN from department number 30. 
 select ename,job,sal,deptno from emp where job !='SALESMAN' and deptno='30';