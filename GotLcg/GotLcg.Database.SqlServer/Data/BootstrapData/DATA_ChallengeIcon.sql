/*** Will be added to Post-Deployment script. Contains [ChallengeIcon] bootstrap data. ***/

DECLARE @challengeIconData AS TABLE
(
	[Id] TINYINT NOT NULL,
	[Name] NVARCHAR(10) NOT NULL
);

INSERT INTO @challengeIconData ([Id], [Name]) VALUES
	(1, 'Military'),
	(2, 'Intrigue'),
	(3, 'Power');

 MERGE 
	INTO [ChallengeIcon] AS target
	USING @challengeIconData AS source
	ON (target.[Id] = source.[Id])

	WHEN MATCHED THEN
		UPDATE SET [Name] = source.[Name], [ModifiedDate] = GETUTCDATE()
		
	WHEN NOT MATCHED BY TARGET THEN
		INSERT ([Id], [Name]) VALUES (source.[Id], source.[Name])

	WHEN NOT MATCHED BY SOURCE THEN
		DELETE;

PRINT('[ChallengeIcon] bootstrap data is added.');