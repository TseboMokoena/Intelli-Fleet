CREATE TABLE VEHICLE
(VEHICLE_ID INTEGER NOT NULL IDENTITY(1,1), 
VEHICLE_REG VARCHAR(MAX),
VEHICLE_TYPE VARCHAR(MAX),
VEHICLE_SIZE VARCHAR(MAX),
PRIMARY KEY (VEHICLE_ID),
);