/*
	=======================================================================================
	CREATED DATE:	9/14/2016
	CREATED BY:		IGOR BURKOVYCH
	DESCRIPTION:	Updates record in User table with duplicate @nickname parameter validation.
	========================================================================================
	MODIFIED DATE:	
	MODIFIED BY:	
	DESCRIPTION:	
*/
CREATE PROCEDURE [dbo].[SP_User_Update]
	@userId UNIQUEIDENTIFIER,
	@nickname nvarchar(50)
AS
	IF(@userId IS NULL)
		THROW 51000, 'The parameter @userId is NULL.', 1;  

	IF(@nickname IS NULL)
		THROW 51000, 'The parameter @nickname is NULL.', 2;  

	IF(NOT EXISTS (SELECT NULL FROM [User] WITH(NOLOCK) WHERE [Id] = @userId))
		THROW 51000, 'The User record does not exist.', 3; 

	IF(EXISTS (SELECT NULL FROM [User] WITH(NOLOCK) WHERE [Nickname] = @nickname))
		THROW 51000, 'The User with specified Nickname already exists.', 4;  
		
	UPDATE 
		[User] 
	SET
		[Nickname] = @nickname,
		[ModifiedDate] = GETUTCDATE()
	OUTPUT 
		inserted.[Id], 
		inserted.[Nickname], 
		inserted.[CreatedDate], 
		inserted.[ModifiedDate]
	WHERE 
		[Id] = @userId

RETURN 0;