﻿IF NOT EXISTS (SELECT 1 FROM [User].Roles)
	BEGIN
		INSERT INTO [User].Roles VALUES ('C5F809AF-484D-4100-A793-2690F17BA837', 'Admin'), ('C5F809AF-484D-4100-A793-2690F17BA838', 'User')
	END