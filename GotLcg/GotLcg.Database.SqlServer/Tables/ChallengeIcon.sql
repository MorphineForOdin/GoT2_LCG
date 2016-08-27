CREATE TABLE [dbo].[ChallengeIcon]
(
	[Id] INT NOT NULL, 
    [Name] NVARCHAR(10) NOT NULL,
    [CreatedDate] DATETIME2 NOT NULL CONSTRAINT [DC_ChallengeIcon_CreatedDate] DEFAULT GETUTCDATE(), 
    [ModifiedDate] DATETIME2 NOT NULL CONSTRAINT [DC_ChallengeIcon_ModifiedDate] DEFAULT GETUTCDATE(),
	CONSTRAINT [PK_ChallengeIcon] PRIMARY KEY CLUSTERED ([Id] ASC)
);