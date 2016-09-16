/*
	=======================================================================================
	CREATED DATE:	9/14/2016
	CREATED BY:		IGOR BURKOVYCH
	DESCRIPTION:	Selects all records from User table.
	========================================================================================
	MODIFIED DATE:	
	MODIFIED BY:	
	DESCRIPTION:	
*/
CREATE PROCEDURE [dbo].[SP_User_GetAll]
AS
	
	SELECT
		[Id],
		[Nickname],
		[CreatedDate],
		[ModifiedDate]
	FROM 
		[User] 

RETURN 0;