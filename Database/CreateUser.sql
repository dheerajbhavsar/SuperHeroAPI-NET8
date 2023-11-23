-- =======================================================================================
-- Create User as DBO template for Azure SQL Database and Azure Synapse Analytics Database
-- =======================================================================================
-- For login login_name, create a user in the database

CREATE USER [wap01cin] FROM EXTERNAL PROVIDER  WITH DEFAULT_SCHEMA=[dbo]
GO
-- =======================================================================================
-- Create Microsoft Entra User for Azure SQL Database and Azure Synapse Analytics Database
-- =======================================================================================
-- For login <login_name, sysname, login_name>, create a user in the database
-- CREATE USER <Microsoft_Entra_User, sysname, user_name>
--    [   { FOR | FROM } LOGIN <Microsoft_Entra_Principal_Login, sysname, login_name>  ]  
--    | FROM EXTERNAL PROVIDER
--    [ WITH DEFAULT_SCHEMA = <default_schema, sysname, dbo> ]
-- GO

-- Add user to the database owner role
EXEC sp_addrolemember N'db_datareader', N'wap01cin'
GO
EXEC sp_addrolemember N'db_datawriter', N'wap01cin'
GO
