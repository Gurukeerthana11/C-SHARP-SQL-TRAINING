--TASK 1:Database Design

--1. Create the database named "TicketBookingSystem"  
create database TicketBookingSystem;


--2.Write SQL scripts to create the mentioned tables with appropriate data types, constraints, and relationships.Venu,Event,Customers,Booking
use TicketBookingSystem

-- create venue table
create table venue (
    venue_id int primary key,
    venue_name varchar(255) not null,
    address text not null
);
select * from  venue

-- create event table
create table event (
    event_id int primary key,
    event_name varchar(255) not null,
    event_date date not null,
    event_time time not null,
    venue_id int,
    total_seats int not null,
    available_seats int not null,
    ticket_price decimal(10,2) not null,
    event_type varchar(50) not null, 
    foreign key (venue_id) references venue(venue_id)
);

-- create customer table
create table customer (
    customer_id int primary key,
    customer_name varchar(255) not null,
    email varchar(255) unique not null,
    phone_number varchar(20) unique not null
);

-- create booking table
create table booking (
    booking_id int primary key,
    customer_id int,
    event_id int,
    num_tickets int not null,
    total_cost decimal(10,2) not null,
    booking_date datetime default getdate(),
    foreign key (customer_id) references customer(customer_id),
    foreign key (event_id) references event(event_id)
);

--3. Create an ERD (Entity Relationship Diagram) for the database. 


--4. Create appropriate Primary Key and Foreign Key constraints for referential integrity.  
-- primary key constraints
alter table venue add constraint pk_venue primary key (venue_id);
alter table event add constraint pk_event primary key (event_id);
alter table customer add constraint pk_customer primary key (customer_id);
alter table booking add constraint pk_booking primary key (booking_id);

-- foreign key constraints
alter table event add constraint fk_event_venue foreign key (venue_id) references venue(venue_id);
alter table booking add constraint fk_booking_customer foreign key (customer_id) references customer(customer_id);
alter table booking add constraint fk_booking_event foreign key (event_id) references event(event_id);

