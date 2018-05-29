CREATE TABLE VEHICLE_DRIVER
(DRIVER_ID INTEGER NOT NULL IDENTITY(1,1), 
VEHICLE_ID INTEGER NOT NULL, 
PRIMARY KEY (DRIVER_ID,VEHICLE_ID),
FOREIGN KEY (DRIVER_ID) REFERENCES DRIVERS (DRIVER_ID),
FOREIGN KEY (VEHICLE_ID) REFERENCES VEHICLE (VEHICLE_ID)
); 