IF NOT EXISTS (SELECT 1 FROM Patient.PatientInformation)
	BEGIN
		INSERT INTO Patient.PatientInformation 
		VALUES ('583DC25D-3101-41C3-AB0C-1EF8F0775B5A', 'Gadgil Ajinkya', 24, '9673963779', 1, 'No history', 'Case1', NULL), 
		('583DC25D-3101-41C3-AB0C-1EF8F0775B5B', 'Kelkar Rucha', 31, '9673966305', 0, 'No history known', 'Case2', NULL)
	END