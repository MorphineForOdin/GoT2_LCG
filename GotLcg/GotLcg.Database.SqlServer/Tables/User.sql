﻿CREATE TABLE [dbo].[User]
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
	[Nickname] NVARCHAR(50) NOT NULL,
    [CreatedDate] DATETIME2 NOT NULL CONSTRAINT [DC_User_CreatedDate] DEFAULT GETUTCDATE(), 
    [ModifiedDate] DATETIME2 NOT NULL CONSTRAINT [DC_User_ModifiedDate] DEFAULT GETUTCDATE(),
	CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);