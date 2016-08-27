/*** Will be added to Post-Deployment script. Contains [CardType] bootstrap data. ***/

DECLARE @cardTypeData AS TABLE
(
	[Id] INT NOT NULL,
	[Name] NVARCHAR(10) NOT NULL
);

INSERT INTO @cardTypeData ([Id], [Name]) VALUES
	(1, 'Faction'),
	(2, 'Agenda'),
	(3, 'Plot'),
	(4, 'Character'),
	(5, 'Location'),
	(6, 'Attachment'),
	(7, 'Event');

 MERGE 
	INTO [CardType] AS target
	USING @cardTypeData AS source
	ON (target.[Id] = source.[Id])

	WHEN MATCHED THEN 
		UPDATE SET [Name] = source.[Name], [ModifiedDate] = GETUTCDATE()
		
	WHEN NOT MATCHED BY TARGET THEN
		INSERT ([Id], [Name]) VALUES (source.[Id], source.[Name])

	WHEN NOT MATCHED BY SOURCE THEN
		DELETE;

PRINT('[CardType] bootstrap data is added.');