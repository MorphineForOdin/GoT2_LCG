/*
	=======================================================================================
	CREATED DATE:	9/14/2016
	CREATED BY:		IGOR BURKOVYCH
	DESCRIPTION:	Selects record from User table where Nickname is equal to @userId.
	========================================================================================
	MODIFIED DATE:	
	MODIFIED BY:	
	DESCRIPTION:	
*/
CREATE PROCEDURE [dbo].[SP_User_GetByNickname]
	@nickname NVARCHAR(50)
AS
	IF(@nickname IS NULL)
		THROW 51000, 'The parameter @nickname is NULL.', 1;   
		
	SELECT
		[Id],
		[Nickname],
		[CreatedDate],
		[ModifiedDate]
	FROM 
		[User] 
	WHERE 
		[Nickname] = @nickname

RETURN 0;