# Patient Management System

## Introduction
Patient Management System is web application to maintain the the patient information as well to maintain patient treatment history. The system also maintains the billing information associated with the patient.

## Steps to Run development environment
1. Open the solution file in PMSBackend folder.
2. Change the connection string appsettings.json file and publish the database project(you can find the PatientManagementSystem.publish.xml in the database project folder update it to point to database) which seeds the database with some values.
3. Run the solution which would run the .NET core API and that would open the Swagger UI to get the list of APIs.
4. Open the angular code from PMSUI folder and enter the command in the terminal 
```
npm start
```
5. Above steps would run development environment of .net core API and angular.

## Screens
Patient Listing
![Patient Listing with pagination, filtering and sorting](https://github.com/ajinkyagadgil/patient-management-system/blob/main/Screens/PatientListing.png)

Searching
![Searching Patients on any value](https://github.com/ajinkyagadgil/patient-management-system/blob/main/Screens/Search.png)

Add/Edit patient Dialog
![Add/Edit Patient Dialog](https://github.com/ajinkyagadgil/patient-management-system/blob/main/Screens/EditPatient.png)

Patient Treatment Details
![Patient Treatment Details](https://github.com/ajinkyagadgil/patient-management-system/blob/main/Screens/PatientTreatmentDetails.png)

Add/Edit Treatment Dialog
![Add/Edit Treatment Dialog](https://github.com/ajinkyagadgil/patient-management-system/blob/main/Screens/EditTreatmentDialog.png)

Billing Listing for Day
![Add/Edit Treatment Dialog](https://github.com/ajinkyagadgil/patient-management-system/blob/main/Screens/BillingForTheDay.png)

Add/Edit Billing Dialog
![Add/Edit Billing Dialog](https://github.com/ajinkyagadgil/patient-management-system/blob/main/Screens/EditBilling.png)

Billing Information Date Range Filter
![Billing Information Date Range Filter](https://github.com/ajinkyagadgil/patient-management-system/blob/main/Screens/DateRangeFilterToFilterDates.png)

Delete Patient Confirmation
![Billing Information Date Range Filter](https://github.com/ajinkyagadgil/patient-management-system/blob/main/Screens/DeletePatient.png)


