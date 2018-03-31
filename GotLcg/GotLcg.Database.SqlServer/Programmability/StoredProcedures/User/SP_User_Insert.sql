/*
	=======================================================================================
	CREATED DATE:	9/14/2016
	CREATED BY:		IGOR BURKOVYCH
	DESCRIPTION:	Inserts new record into User table with parameter validation.
	========================================================================================
	MODIFIED DATE:	
	MODIFIED BY:	
	DESCRIPTION:	
*/
CREATE PROCEDURE [dbo].[SP_User_Insert]
	@userId UNIQUEIDENTIFIER,
	@nickname nvarchar(50)
AS
	IF(@userId IS NULL)
		THROW 51000, 'The parameter @userId is NULL.', 1;  

	IF(@nickname IS NULL)
		THROW 51000, 'The parameter @nickname is NULL.', 2;  

	IF(EXISTS (SELECT NULL FROM [User] WITH(NOLOCK) WHERE [Id] = @userId OR [Nickname] = @nickname))
		THROW 51000, 'The User record already exists.', 3;  
	
	INSERT INTO [User] 
	(
		[Id], 
		[Nickname]
	)
	OUTPUT 
		inserted.[Id], 
		inserted.[Nickname], 
		inserted.[CreatedDate], 
		inserted.[ModifiedDate]
	VALUES 
	(
		@userId, 
		@nickname
	)

RETURN 0;