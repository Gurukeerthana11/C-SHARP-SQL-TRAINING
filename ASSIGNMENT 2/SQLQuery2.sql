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
select * from emp where ename like 'A%';
select * from emp where mgr_id is null;
select ename,empno,sal from emp where sal >=1200 and sal<=1400;
select count(*) as "Number of Clerks Employed" from emp where job = 'clerk';
select avg(sal) as "avgsalary of clerk" from emp where job='clerk' ;
select avg(sal) as "avgsalary of salesman" from emp where job='salesman' ;
select avg(sal) as "avgsalary of manager" from emp where job='manager' ;
select avg(sal) as "avgsalary of analyst" from emp where job='analyst' ;
select avg(sal) as "avgsalary of president" from emp where job='president' ;
select ename from emp where sal=(select max(sal) from emp);
select ename from emp where sal=(select min(sal) from emp);
select * from dept where deptno not in (select distinct deptno from emp);
select ename,sal from emp where job='analyst' and sal>1200 and deptno='20' order by ename asc;
select sal from emp where ename in ('miller','smith');
select ename from emp where ename like 'A%' or ename like 'M%';
select ename, sal * 12 from emp where ename = 'smith';
select ename, sal from emp where sal not between 1500 and 2850;


