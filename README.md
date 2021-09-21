# Patient Management System

## Introduction
Patient Management System is web application to maintain the the patient information as well to maintain patient treatment history. The system also maintains the billing information associated with the patient.

## Features
1. List the patients
2. Add/Edit/Delete Patient Details
3. See the patient details and its treatment history
4. Add/Edit/Delete Treatment history
5. Pagination, search, sort on the listing pages
6. See the total billing for the day
7. Date filter to see the billing information for the date range
8. Add images to the treatment and also integrated image viewer to perform basic operations on the image.

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

Image Viewer Integration
![Billing Information Date Range Filter](https://github.com/ajinkyagadgil/patient-management-system/blob/main/Screens/ImageViewerIntegration.png)

## Steps to Run development environment
1. Open the solution file in PMSBackend folder.
2. Change the connection string appsettings.json file and publish the database project(you can find the PatientManagementSystem.publish.xml in the database project folder update it to point to database) which seeds the database with some values.
3. Run the solution which would run the .NET core API and that would open the Swagger UI to get the list of APIs.
4. Open the angular code from PMSUI folder and enter the command in the terminal 
```
npm start
```
5. Above steps would run development environment of .net core API and angular.

## Development
### Pre-requisites
1. .NET Core 3.1
2. Node.js
3. npm package manager
4. Install Angular CLI
5. MS SQL Server
### Built with
1. [Visual Studio 2019 Community](https://visualstudio.microsoft.com/downloads/)
2. [Visual Studio Code](https://code.visualstudio.com/)
3. [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet/3.1)
4. [Angular](https://angular.io/)
5. [MS SQL Server Community](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)


