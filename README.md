#Band Tracker

#### _A website to add your bands and venues_

#### By _**Jesse McKay**_

## Description

_This page allows the user to add bands and venues to a list, then display which bands and venues are associated with each other_

## Specifications

_Band Tests_

| Test                                      | Input                       | Output                      |
|-------------------------------------------|-----------------------------|-----------------------------|
| Test if band database is empty            | Empty                       | 0                           |
| Test if two equal bands match by name     | "Grateful Dead"             | "Grateful Dead"             |
| Test if band saves to database            | "Grateful Dead"             | "Grateful Dead"             |
| Test if ID assigned when band is saved    | "Grateful Dead"             | 1                           |
| Test if venue is added to band            | "Cornell University         | "Cornell University"        |
| Test if gets list of all venues from band | "Grateful Dead, Pink Floyd" | "Grateful Dead, Pink Floyd" |
| Test if band found in database            | "Grateful Dead"             | "Grateful Dead"             |

_Venue Tests_

| Test                                       | Input                         | Output                      |
|--------------------------------------------|-------------------------------|-----------------------------|
| Test if venue database is empty            | Empty                         | 0                           |
| Test if two equal venues match by name     | "The Filmore"                 | "The Filmore"               |
| Test if venue saves to database            | "The Filmore"                 | "The Filmore"               |
| Test if ID assigned when venue is saved    | "The Filmore"                 | 1                           |
| Test if band is added to venue             | "Grateful Dead"               | "Grateful Dead"             |
| Test if gets list of all bands from venue  | "Grateful Dead, Pink Floyd"   | "Grateful Dead, Pink Floyd" |
| Test if venue found in database            | "The Filmore"                 | "The Filmore"               |

## Setup Instructions
* Clone the repository "BandTracker" to your computer
* Open Windows PowerShell
* Navigate to the folder where you cloned the repository
* Type the following commands to open sql command:  sqlcommand -S "(localdb)\mssqllocaldb)"

* Type the following commands to create the databases:
* 1> CREATE DATABASE band_tracker;
* 2> GO

* 1> USE band_tracker;
* 2> GO

* 1> CREATE TABLE venues (id INT IDENTITY(1,1), location VARCHAR(255));
* 2> GO

* 1> CREATE TABLE bands (id INT IDENTITY(1,1), name VARCHAR(255));
* 2> GO

* 1> CREATE TABLE bands_venues (id INT IDENTITY(1,1), venue_id INT, band_id INT);
* 2> GO

* 1> EXIT

* In PowerShell, run the command:  dnu restore
* In PowerShell, run the command:  dnx kestrel
* Open your web browser and enter "localhost:5004" into the web address bar

## Support and contact details

_Email rosecity27@comcast.net to contact the site creator._

## Technologies Used

_This project used HTML, Bootstrap, C#, Nancy, Razor, Xunit, Microsoft Powershell, Windows Operating System_

### License

*Please distribute freely!*
