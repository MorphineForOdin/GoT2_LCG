﻿CREATE TABLE [dbo].[Deck]
(
	[Id] UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR(50) NOT NULL,
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    [CreatedDate] DATETIME2 NOT NULL CONSTRAINT [DC_Deck_CreatedDate] DEFAULT GETUTCDATE(),
    [ModifiedDate] DATETIME2 NOT NULL CONSTRAINT [DC_Deck_ModifiedDate] DEFAULT GETUTCDATE(),
	CONSTRAINT [PK_Deck] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Deck_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
);