﻿CREATE TABLE Students 
(  
    Id INT PRIMARY KEY IDENTITY ,
    FirstName NVARCHAR(50) NOT NULL ,
	LastName NVARCHAR(50) NOT NULL  ,
	Age INT NOT NULL,
	
	CONSTRAINT CK_Students_FirstName CHECK(LEN(FirstName) > 0),
	CONSTRAINT CK_Students_Age CHECK(Age BETWEEN 0 AND 100)
);

SELECT * FROM Students

SELECT COUNT(*) FROM Students;

CREATE LOGIN TestApp WITH PASSWORD='12345678';
CREATE USER TestApp FOR LOGIN TestApp


CREATE LOGIN Test WITH PASSWORD='12345678';
CREATE USER Test2 FOR LOGIN Test

GRANT INSERT TO TestApp
GRANT UPDATE TO TestApp
GRANT DELETE TO TestApp
GRANT SELECT TO TestApp

DROP TABLE Students;