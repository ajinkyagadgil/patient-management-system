IF NOT EXISTS (SELECT 1 FROM Patient.PatientInformation)
	BEGIN
		INSERT INTO Patient.PatientInformation 
		VALUES ('583DC25D-3101-41C3-AB0C-1EF8F0775B5A', 'Ajinkya', 'Gadgil', 'ajinkyargadgil@gmail.com', 24, '9673963779', 2, 'No history', 'Case1', NULL), 
		('C5F809AF-484D-4100-A793-2690F17BA832', 'Jyoti','Gadgil', 'jrgadgil@gmail.com', 57, '9673966305', 1, 'Dieebtic', 'Case2', NULL),
		('C5F809AF-484D-4100-A793-2690F17BA833', 'Pranav', 'Gadgil','pranavgadgil@praha.in', 32, 'Blood pressure', 2, 'No history known', 'Case3', NULL),
		('C5F809AF-484D-4100-A793-2690F17BA834', 'Vishwas', 'Pagare',NULL, 22, '9673966305', 2, 'No history known', 'Case4', NULL),
		('C5F809AF-484D-4100-A793-2690F17BA835', 'Yogesh','A',NULL, 28, '9673966305', 2, 'No history known', 'Case5', NULL),
		('C5F809AF-484D-4100-A793-2690F17BA836', 'Suresh', 'Ketkar',NULL, 62, '9673966305', 2, 'No history known', 'Case6', NULL),
		('C5F809AF-484D-4100-A793-2690F17BA837', 'Nandu','Vaishampayan','nandy@gmail.com', 61, '9673966305', 2, 'No history known', 'Case7', NULL),
		('C5F809AF-484D-4100-A793-2690F17BA838', 'Milind', 'Rajpathak','milind@gmail.com', 60, '9673966305', 2, 'No history known', 'Case8', NULL),
		('C5F809AF-484D-4100-A793-2690F17BA839', 'Ani','J',NULL, 24, '9673966305', 1, 'No history known', 'Case9', NULL),
		('C5F809AF-484D-4100-A793-2690F17BA840', 'Manda','Kunte',NULL, 85, '9673966305', 1, 'No history known', 'Case10', NULL),
		('C5F809AF-484D-4100-A793-2690F17BA841', 'Shirish', 'Deshpande','shirsh@gmail.com', 65, '9673966305', 2, 'No history known', 'Case11', NULL),
		('C5F809AF-484D-4100-A793-2690F17BA842', 'Rucha','Kelkar','ruchak219@gmail.com', 31, '9673966305', 1, 'No history known', 'Case12', NULL)
	END