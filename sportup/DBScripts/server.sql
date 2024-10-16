-- Create the database
CREATE DATABASE sport_server;
GO

-- Select the database
GO

-- Create the users table
CREATE TABLE users (
    user_id INT IDENTITY(1,1) PRIMARY KEY, 
    username VARCHAR(50) NOT NULL UNIQUE,  -- Added UNIQUE constraint for username
    password VARCHAR(100) NOT NULL,
    picture_url VARCHAR(255),
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    phone_num VARCHAR(15),  -- Changed to VARCHAR to accommodate various phone formats
    home_num VARCHAR(10),
    street_name VARCHAR(100),
    city_name VARCHAR(50),
	urank INT,
    description TEXT,
);
GO

-- Create the event table
CREATE TABLE event (
    event_id INT IDENTITY(1,1) PRIMARY KEY,
    home_num VARCHAR(10),
    street_name VARCHAR(100),
    city_name VARCHAR(50),
    picture_url VARCHAR(255),
    sport VARCHAR(50) NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    description VARCHAR(max),
    ends_at DATETIME, 
    event_name VARCHAR(100) NOT NULL,
    crator_id INT NOT NULL,
    FOREIGN KEY (crator_id) REFERENCES users(user_id) ON DELETE NO ACTION,
);
GO

-- Create the user_to_event junction table (many-to-many relationship)
CREATE TABLE user_to_event (
    table_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    event_id INT,
    realtionship_type VARCHAR(8),
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE NO ACTION,
    FOREIGN KEY (event_id) REFERENCES event(event_id) ON DELETE NO ACTION
);
GO
-- Create the comment table
CREATE TABLE comment (
    comment_id INT IDENTITY(1,1) PRIMARY KEY,
    commenter_id INT,
    commented_on_id INT,
    comment TEXT,
    created_at DATETIME DEFAULT GETDATE(),
    rating INT CHECK (rating BETWEEN 1 AND 5),  -- Added constraint for rating range
    FOREIGN KEY (commenter_id) REFERENCES users(user_id) ON DELETE NO ACTION ,  -- Fixed foreign key reference
    FOREIGN KEY (commented_on_id) REFERENCES users(user_id) ON DELETE NO ACTION  -- Fixed foreign key reference
);
GO

CREATE TABLE chat_comment (
    comment_id INT IDENTITY(1,1) PRIMARY KEY,
    commenter_id INT,
    event_id INT,
    comment TEXT,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (commenter_id) REFERENCES users(user_id) ON DELETE NO ACTION ,  -- Fixed foreign key reference
    FOREIGN KEY (event_id) REFERENCES event(event_id) ON DELETE NO ACTION   -- Fixed foreign key reference
);
GO

CREATE TABLE report (
    report_id INT IDENTITY(1,1) PRIMARY KEY,
    reporter_id INT,
    target_id INT,
    comment TEXT,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (reporter_id) REFERENCES users(user_id) ON DELETE NO ACTION ,  -- Fixed foreign key reference
    FOREIGN KEY (target_id) REFERENCES users(user_id) ON DELETE NO ACTION ,  -- Fixed foreign key reference
  
);
GO


-- Create a login for the admin user
CREATE LOGIN [TaskAdminLogin] WITH PASSWORD = 'kukuPassword';
Go

-- Create a user in the TamiDB database for the login
CREATE USER [TaskAdminUser] FOR LOGIN [TaskAdminLogin];
Go

-- Add the user to the db_owner role to grant admin privileges
ALTER ROLE db_owner ADD MEMBER [TaskAdminUser];
Go

SELECT * FROM user_to_event
-- Insert values into the 'users' table
INSERT INTO users (username, password, picture_url, first_name, last_name, phone_num, home_num, street_name, city_name, urank, description) 
VALUES 
('john_doe', 'password123', 'https://example.com/pic1.jpg', 'John', 'Doe', '1234567890', '22', 'Main St', 'New York', 5, 'Active user and sports enthusiast.'),
('jane_smith', 'securePass!', 'https://example.com/pic2.jpg', 'Jane', 'Smith', '0987654321', '10', 'Elm St', 'Boston', 4, 'Frequent event organizer.'),
('mark_jones', 'pass1234', NULL, 'Mark', 'Jones', NULL, '50', 'Lake Ave', 'San Francisco', 3, 'Casual user interested in fitness.');

-- Insert values into the 'event' table
INSERT INTO event (home_num, street_name, city_name, picture_url, sport, created_at, description, ends_at, event_name, crator_id)
VALUES
('22', 'Main St', 'New York', 'https://example.com/event1.jpg', 'Basketball', GETDATE(), 'Friendly game at the community court.', DATEADD(day, 1, GETDATE()), 'Community Basketball', 1),
('10', 'Elm St', 'Boston', 'https://example.com/event2.jpg', 'Yoga', GETDATE(), 'Morning yoga session in the park.', DATEADD(day, 2, GETDATE()), 'Morning Yoga', 2);

-- Insert values into 'user_to_event' table
INSERT INTO user_to_event (user_id, event_id, realtionship_type) 
VALUES 
(1, 1, 'attend'), 
(1, 2, 'waiting'), 
(2, 1, 'attend'), 
(3, 2, 'attend');

-- Insert values into 'comment' table
INSERT INTO comment (commenter_id, commented_on_id, comment, created_at, rating) 
VALUES 
(1, 2, 'Great experience!', GETDATE(), 5), 
(2, 1, 'Very helpful user.', GETDATE(), 4), 
(3, 1, 'Needs improvement.', GETDATE(), 2);

-- Insert values into 'chat_comment' table
INSERT INTO chat_comment (commenter_id, event_id, comment, created_at) 
VALUES 
(1, 1, 'Looking forward to the event!', GETDATE()), 
(2, 1, 'Can’t wait!', GETDATE()), 
(3, 2, 'Any updates on the location?', GETDATE());

-- Insert values into 'report' table
INSERT INTO report (reporter_id, target_id, comment, created_at) 
VALUES 
(2, 1, 'Spamming in chats', GETDATE()), 
(3, 2, 'Inappropriate behavior', GETDATE());

--EF Code
/*
scaffold-DbContext "Server = (localdb)\MSSQLLocalDB;Initial Catalog=sport_server;User ID=TaskAdminLogin;Password=kukuPassword;" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Models -Context sportupDBContext -DataAnnotations -force
*/
