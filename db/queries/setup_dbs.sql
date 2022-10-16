DROP TABLE passwords;
DROP TABLE accounts;

CREATE TABLE accounts (
	userId INT NOT NULL UNIQUE,
	username NVARCHAR(50) NOT NULL,
	email NVARCHAR(100) NOT NULL,
	PRIMARY KEY (userId)
);

CREATE TABLE passwords (
	userId INT NOT NULL UNIQUE,
	password NVARCHAR(50) NOT NULL,
	FOREIGN KEY (userId) REFERENCES accounts(userId)
);

BEGIN TRANSACTION; 

INSERT INTO [dbo].[accounts]
           ([userId]
           ,[username]
           ,[email])
     VALUES
           (0,
		   'admin',
		   'admin@email.com')
GO

INSERT INTO [dbo].[passwords]
           ([userId]
           ,[password])
     VALUES
           (0,
           'password')
GO

COMMIT; 

BEGIN TRANSACTION; 

INSERT INTO [dbo].[accounts]
           ([userId]
           ,[username]
           ,[email])
     VALUES
           (0,
		   'user1',
		   'user1@email.com')
GO

INSERT INTO [dbo].[passwords]
           ([userId]
           ,[password])
     VALUES
           (0,
           'password1')
GO

COMMIT; 