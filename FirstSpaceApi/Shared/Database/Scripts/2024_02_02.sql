-- Role enum
ALTER TABLE [User]
ADD Role INT CHECK (Role IN (0, 1, 2))

-- Make user id guid
-- Drop the existing primary key constraint if it exists
ALTER TABLE [User] DROP CONSTRAINT PK_User;

-- Alter the column to be of type UNIQUEIDENTIFIER with a DEFAULT constraint
ALTER TABLE [User]
ADD UserId  uniqueidentifier default newid() PRIMARY KEY ;

-- ADMIN Entry 
INSERT INTO [firstSpaceDb].[dbo].[User] ( [FirstName]
      ,[MiddleName]
      ,[LastName]
      ,[UserName]
      ,[Email]
      ,[Password]
      ,[CreatedDate]
      ,[ModifiedDate]
      ,[CreatedBy]
      ,[ModifiedBy]
      ,[Role]
)
  Values (
   'Admin', '', '','admin_firstspace', 'admin@firstspace.com', 'Password1', GETUTCDATE(), GETUTCDATE(),'System generated', 'System generated', 2
  );