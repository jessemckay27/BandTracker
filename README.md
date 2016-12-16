1> CREATE DATABASE band_tracker;
2> GO

1> USE band_tracker;
3> GO

1> CREATE TABLE venues (id INT IDENTITY(1,1), location VARCHAR(255));
2> GO

1> CREATE TABLE bands (id INT IDENTITY(1,1), name VARCHAR(255));
2> GP
1> CREATE TABLE venues_bands (id INT IDENTITY(1,1), venue_id INT, band_id INT);
2> GO
