/*
	=======================================================================================
	CREATED DATE:	9/14/2016
	CREATED BY:		IGOR BURKOVYCH
	DESCRIPTION:	Deletes record from User table.
	========================================================================================
	MODIFIED DATE:	
	MODIFIED BY:	
	DESCRIPTION:	
*/
CREATE PROCEDURE [dbo].[SP_User_Delete]
	@userId UNIQUEIDENTIFIER
AS
	IF(@userId IS NULL)
		THROW 51000, 'The parameter @userId is NULL.', 1;   

	IF(NOT EXISTS (SELECT NULL FROM [User] WITH(NOLOCK) WHERE [Id] = @userId))
		THROW 51000, 'The User record does not exist.', 2; 
		
	DELETE FROM 
		[User] 
	WHERE 
		[Id] = @userId

RETURN 0;