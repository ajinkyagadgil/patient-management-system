IF NOT EXISTS (SELECT 1 FROM [User].Roles)
	BEGIN
		INSERT INTO [User].Roles VALUES (NEWID(), 'Admin'), (NEWID(), 'User')
	END