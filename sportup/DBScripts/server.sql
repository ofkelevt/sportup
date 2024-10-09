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
    FOREIGN KEY (crator_id) REFERENCES users(user_id) ON DELETE CASCADE,
);
GO

-- Create the user_to_event junction table (many-to-many relationship)
CREATE TABLE user_to_event (
    table_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    event_id INT,
    realtionship_type VARCHAR(8),
    FOREIGN KEY (user_id) REFERENCES users(user_id) ,
    FOREIGN KEY (event_id) REFERENCES event(event_id) ON DELETE CASCADE,
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


select * from report

insert into users values('idk','2042007o',NULL,'ofek','levy','0587333645','1','aviv','hod hasron',1,'cool');
insert into users values('idk1','2042007o1',NULL,'ofek','levy','05873336451','2','aviv1','hod hasron1',2,'cool1');
insert into event values(null,null,null,null,'tenis',null,null,null,'hi','1');
insert into user_to_event values('1','1','none');
insert into comment values('1','2','cool man',null,'5');
insert into chat_comment values('1','1','cool mate',null);
insert into report values('1','1','yo',null);
--EF Code
/*
scaffold-DbContext "Server = (localdb)\MSSQLLocalDB;Initial Catalog=sport_server;User ID=TaskAdminLogin;Password=kukuPassword;" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Models -Context sportupDBContext -DataAnnotations -force
*/
