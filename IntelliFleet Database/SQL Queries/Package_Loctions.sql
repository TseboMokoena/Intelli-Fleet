CREATE TABLE PACKAGE_LOCATIONS
(PACKAGE_ID INT NOT NULL IDENTITY(1,1),
LOCATION_ID INTEGER,
LOC_TIME TIME ,
LOC_DATE DATE,
PRIMARY KEY(PACKAGE_ID,LOCATION_ID),
FOREIGN KEY(PACKAGE_ID) REFERENCES PACKAGES(PACKAGE_ID),
FOREIGN KEY(LOCATION_ID) REFERENCES LOCATIONS(LOCATION_ID)
); 