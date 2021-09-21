IF NOT EXISTS (SELECT 1 FROM Patient.PatientInformation)
	BEGIN
		INSERT INTO Patient.PatientInformation 
		VALUES ('583DC25D-3101-41C3-AB0C-1EF8F0775B5A', 'John', 'Smith', 'jsmith@gmail.com', 24, '9673963779', 2, 'No history', 'Case1'), 
		('C5F809AF-484D-4100-A793-2690F17BA832', 'James','Jones', 'jones@gmail.com', 57, '9673966305', 2, 'Dieebtic', 'Case2'),
		('C5F809AF-484D-4100-A793-2690F17BA833', 'Nick', 'Taylor','nick@taylor.in', 32, '967963779', 2, 'No history known', 'Case3'),
		('C5F809AF-484D-4100-A793-2690F17BA834', 'Mary', 'Brown',NULL, 22, '9673966305', 1, 'No history known', 'Case4'),
		('C5F809AF-484D-4100-A793-2690F17BA835', 'Patricia','A',NULL, 28, '9673966305', 1, 'No history known', 'Case5'),
		('C5F809AF-484D-4100-A793-2690F17BA836', 'Michael', 'Davies',NULL, 62, '9673966305', 2, 'No history known', 'Case6'),
		('C5F809AF-484D-4100-A793-2690F17BA837', 'William','Johnson','wjohnson@gmail.com', 61, '9673966305', 2, 'No history known', 'Case7'),
		('C5F809AF-484D-4100-A793-2690F17BA838', 'Sarah', 'Baker','sarahbaker@gmail.com', 60, '9673966305', 1, 'No history known', 'Case8'),
		('C5F809AF-484D-4100-A793-2690F17BA839', 'Lisa','Green',NULL, 24, '9673966305', 1, 'No history known', 'Case9'),
		('C5F809AF-484D-4100-A793-2690F17BA840', 'Matthew','Johnson',NULL, 85, '9673966305', 2, 'No history known', 'Case10'),
		('C5F809AF-484D-4100-A793-2690F17BA841', 'Steven', 'Hall','halls@gmail.com', 65, '9673966305', 2, 'No history known', 'Case11'),
		('C5F809AF-484D-4100-A793-2690F17BA842', 'Joshua','Lewis','jlewis@gmail.com', 31, '9673966305', 2, 'No history known', 'Case12')
	END