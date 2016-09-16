/*
	=======================================================================================
	CREATED DATE:	9/14/2016
	CREATED BY:		IGOR BURKOVYCH
	DESCRIPTION:	Selects record from User table where Id is equal to @userId.
	========================================================================================
	MODIFIED DATE:	
	MODIFIED BY:	
	DESCRIPTION:	
*/
CREATE PROCEDURE [dbo].[SP_User_Get]
	@userId UNIQUEIDENTIFIER
AS
	IF(@userId IS NULL)
		THROW 51000, 'The parameter @userId is NULL.', 1;   
		
	SELECT
		[Id],
		[Nickname],
		[CreatedDate],
		[ModifiedDate]
	FROM 
		[User] 
	WHERE 
		[Id] = @userId

RETURN 0;