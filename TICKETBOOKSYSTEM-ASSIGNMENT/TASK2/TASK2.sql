--Tasks 2: Select, Where, Between, AND, LIKE: 

--1. Write a SQL query to insert at least 10 sample records into each table.
-- insert sample data into venue table
insert into venue (venue_id, venue_name, address) values
(1, 'Wankhede Stadium', 'Mumbai, India'),
(2, 'Bangalore Palace', 'Bangalore, India'),
(3, 'Sathyam Cinemas', 'Chennai, India'),
(4, 'EKA Arena', 'Ahmedabad, India'),
(5, 'Music Academy', 'Chennai, India'),
(6, 'Eden Gardens', 'Kolkata, India'),
(7, 'IMAX Theatre', 'Bangalore, India'),
(8, 'DY Patil Stadium', 'Delhi, India'),
(9, 'National Stadium', 'Delhi, India'),
(10, 'Habitat Centre', 'Delhi, India');
select* from venue;
-- insert sample data into event table
insert into event (event_id, event_name, event_date, event_time, venue_id, total_seats, available_seats, ticket_price, event_type) values
(1, 'IPL Match', '2025-04-15', '18:30:00', 1, 50000, 45000, 2000.00, 'sports'),
(2, 'Bollywood Concert', '2025-05-10', '19:00:00', 2, 6000, 5500, 1600.00, 'concert'),
(3, 'Tamil Movie Premiere', '2025-06-20', '21:00:00', 3, 300, 250, 600.00, 'movie'),
(4, 'Kabaddi League', '2025-07-12', '18:00:00', 4, 15000, 14000, 1000.00, 'sports'),
(5, 'Carnatic Music Night', '2025-08-05', '20:00:00', 5, 1000, 900, 1200.00, 'concert'),
(6, 'Cricket Test Match', '2025-09-10', '14:00:00', 6, 40000, 38000, 3000.00, 'sports'),
(7, 'Drama Play', '2025-10-25', '19:30:00', 7, 2000, 1800, 2400.00, 'movie'),
(8, 'Coldplay', '2025-11-05', '20:30:00', 8, 800, 750, 1400.00, 'concert'),
(9, 'Hockey Tournament', '2025-12-18', '16:00:00', 9, 12000, 11500, 1200.00, 'sports'),
(10, 'Comedy Show', '2026-01-22', '19:45:00', 10, 500, 450, 800.00, 'movie');
select* from event;

-- insert sample data into customer table
insert into customer (customer_id, customer_name, email, phone_number) values
(1, 'Amit', 'amit@example.com', '9876543210'),
(2, 'Priya', 'priya@example.com', '9876543211'),
(3, 'Rahul', 'rahul@example.com', '9876543212'),
(4, 'Sita', 'sita@example.com', '9876543213'),
(5, 'Vikram', 'vikram@example.com', '9876543214'),
(6, 'Neha', 'neha@example.com', '9876543215'),
(7, 'Rohan', 'rohan@example.com', '9876543216'),
(8, 'Kavita', 'kavita@example.com', '9876543217'),
(9, 'Arjun', 'arjun@example.com', '9876543218'),
(10, 'Divya', 'divya@example.com', '9876543219');
select*from customer

-- insert sample data into booking table
insert into booking (booking_id, customer_id, event_id, num_tickets, total_cost, booking_date) values
(1, 1, 1, 2, 200.00, '2025-03-10'),
(2, 2, 2, 4, 320.00, '2025-03-12'),
(3, 3, 3, 1, 30.00, '2025-03-15'),
(4, 4, 4, 3, 150.00, '2025-03-20'),
(5, 5, 5, 2, 120.00, '2025-03-22'),
(6, 6, 6, 5, 750.00, '2025-03-25'),
(7, 7, 7, 2, 240.00, '2025-03-28'),
(8, 8, 8, 4, 280.00, '2025-03-30'),
(9, 9, 9, 1, 60.00, '2025-04-01'),
(10, 10, 10, 3, 120.00, '2025-04-03');
select*from booking

--2. Write a SQL query to list all Events. 
select * from event;


--3. Write a SQL query to select events with available tickets. 
select * from event where available_seats > 0;


--4. Write a SQL query to select events name partial match with ‘cup’. 
select event_name from event where event_name like '%cup%';

--5. Write a SQL query to select events with ticket price range is between 1000 to 2500. 
select * from event where ticket_price > 1000 and ticket_price <2500

--6. Write a SQL query to retrieve events with dates falling within a specific range. 
select * from event  where event_date between '2025-01-01' and '2025-06-30';

--7. Write a SQL query to retrieve events with available tickets that also have "Concert" in their name. 
select *  from event  where available_seats > 0  and event_name like '%concert%';

--8. Write a SQL query to retrieve users in batches of 5, starting from the 6th user. 
select * from customer  order by customer_id  offset 5 rows fetch next 5 rows only;

--9. Write a SQL query to retrieve bookings details contains booked no of ticket more than 4. 
select * from booking where num_tickets > 4;

--10. Write a SQL query to retrieve customer information whose phone number end with ‘000’ 
select * from customer where phone_number like '%000'

--11. Write a SQL query to retrieve the events in order whose seat capacity more than 15000. 
select * from event where total_seats>15000;

--12. Write a SQL query to select events name not start with ‘x’, ‘y’, ‘z’
select * from event where event_name not like 'x%' and event_name not like 'y%' and event_name not like 'z%';
