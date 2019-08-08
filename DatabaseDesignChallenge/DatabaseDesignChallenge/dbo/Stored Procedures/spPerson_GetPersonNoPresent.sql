CREATE PROCEDURE [dbo].[spPerson_GetPersonNoPresent]
	
AS
Begin

	SELECT *
	From dbo.Person
	Where PresentId is null;

End
