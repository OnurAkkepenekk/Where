CREATE TRIGGER [User_Add_Trigger]
	ON [dbo].[Users]
	FOR INSERT
	AS
	DECLARE @UserId int, @OperationClaimId INT;
	IF exists(SELECT * FROM Users) and exists (SELECT * FROM OperationClaims)
	BEGIN
		SET @UserId = (SELECT TOP 1 Id FROM Users ORDER BY Id DESC);
		SET @OperationClaimId = 1;
		INSERT INTO UserOperationClaims VALUES (@UserId,@OperationClaimId);
	END
