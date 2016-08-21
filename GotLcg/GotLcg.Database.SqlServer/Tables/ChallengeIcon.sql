﻿CREATE TABLE [dbo].[ChallengeIcon]
(
	[Id] INT NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL,
    [CreatedDate] DATETIME2 NOT NULL CONSTRAINT [DEF_ChallengeIcon_CreatedDate] DEFAULT GETUTCDATE(), 
    [ModifiedDate] DATETIME2 NOT NULL CONSTRAINT [DEF_ChallengeIcon_ModifiedDate] DEFAULT GETUTCDATE(),
	CONSTRAINT [PK_ChallengeIcon] PRIMARY KEY CLUSTERED ([Id] ASC)
)
