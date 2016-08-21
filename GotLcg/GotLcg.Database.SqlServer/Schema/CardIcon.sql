﻿CREATE TABLE [dbo].[CardIcon]
(
	[CardId] UNIQUEIDENTIFIER NOT NULL, 
    [ChallengeIconId] INT NOT NULL,  
    [CreatedDate] DATETIME2 NOT NULL CONSTRAINT [DEF_CardIcon_CreatedDate] DEFAULT GETUTCDATE(), 
    [ModifiedDate] DATETIME2 NOT NULL CONSTRAINT [DEF_CardIcon_ModifiedDate] DEFAULT GETUTCDATE(),
	CONSTRAINT [PK_CardIcon] PRIMARY KEY NONCLUSTERED ([CardId], [ChallengeIconId]), 
    CONSTRAINT [FK_CardIcon_Card] FOREIGN KEY ([CardId]) REFERENCES [Card]([Id]),
    CONSTRAINT [FK_CardIcon_ChallengeIcon] FOREIGN KEY ([ChallengeIconId]) REFERENCES [ChallengeIcon]([Id])
)