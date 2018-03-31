CREATE TABLE [dbo].[UserProfile]
(
	[UserId] UNIQUEIDENTIFIER NOT NULL,
	/*Add new optional properties for user here*/
    [CreatedDate] DATETIME2 NOT NULL CONSTRAINT [DC_UserProfile_CreatedDate] DEFAULT GETUTCDATE(),
    [ModifiedDate] DATETIME2 NOT NULL CONSTRAINT [DC_UserProfile_ModifiedDate] DEFAULT GETUTCDATE(),
	CONSTRAINT [PK_UserProfile] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_UserProfile_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
);