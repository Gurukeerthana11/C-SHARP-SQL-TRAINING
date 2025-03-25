--class assignment 5 -Subqueries and corelated sub queries
use db

--1. Write a SQL query to find those employees who receive a higher salary than the employee with ID 7566. Return their names
select ename from emp where sal > (select sal from emp where empno = 7566);

--2. Write a SQL query to find out which employees have the same designation as the employee whose ID is 7876. Return name, department no and job .
select ename, deptno, job from emp where job = (select job from emp where empno = 7876);

--3. Write a SQL query to find those employees who report to that manager whose name starts with a 'B' or 'C'. Return first name, employee ID and salary
select ename, empno, sal from emp where mgr_id in (select empno from emp where ename like 'B%' or ename like 'C%');

 