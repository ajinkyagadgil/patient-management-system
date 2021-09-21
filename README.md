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
![Patient Listing](https://github.com/ajinkyagadgil/patient-management-system/blob/main/Screens/PatientListing.png | width=100)

