SELECT * FROM Authors;
CREATE TABLE Account 
(
Id INT PRIMARY KEY IDENTITY,
Amount MONEY NOT NULL DEFAULT 0,

CONSTRAINT CK_Amount_Account CHECK(Amount >= 0 AND Amount < 10000)
);



INSERT INTO Account VALUES (5000)
INSERT INTO Account VALUES (9500);

SELECT * FROM Account;

CREATE TABLE CreditCard
(
Id INT PRIMARY KEY IDENTITY,
Owner NVARCHAR(50) NOT NULL,
PinCode INT NOT NULL,
CardNumber NVARCHAR(19) NOT NULL,
Money MONEY NOT NULL,

CONSTRAINT CK_CreditCard_Money CHECK(Money >= 0 AND Money <= 10000),
CONSTRAINT CK_CreditCard_PinCode CHECK(PinCode >= 1000 AND PinCode <= 9999),
CONSTRAINT CK_CreditCard_CardNumber CHECK(CardNumber LIKE '[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'),
);

INSERT INTO CreditCard (Owner, CardNumber, PinCode, Money) VALUES ('Vladimir Vinnik', '1234-1234-1234-1234', 1234, 5000)
INSERT INTO CreditCard (Owner, CardNumber, PinCode, Money) VALUES ('Yulia Botsman', '4321-4321-4321-4321', 4321, 8000)

SELECT * FROM CreditCard;

DROP TABLE CreditCard;

CREATE PROC MoneyTransfer 
@CardNumberSender NVARCHAR(19), 
@CardNumberReciver NVARCHAR(19),
@Quantity MONEY
AS
BEGIN
IF @Quantity > 0
BEGIN
--UPDATE CreditCard
--SET Money = Money - @Quantity
--WHERE CardNumber = @CardNumberSender

--UPDATE CreditCard
--SET Money = Money + @Quantity
--WHERE CardNumber = @CardNumberReciver

--PRINT ('Money sender succesfull')

			BEGIN TRANSACTION
			BEGIN TRY
			UPDATE CreditCard
			SET Money = Money - @Quantity
			WHERE CardNumber = @CardNumberSender
			
			UPDATE CreditCard
			SET Money = Money + @Quantity
			WHERE CardNumber = @CardNumberReciver
			
			COMMIT
			
			PRINT ('Money sender succesfull')
			END TRY
		BEGIN CATCH
		PRINT ('Error Transfer')
		ROLLBACK
		END CATCH
END
	ELSE
	BEGIN
	PRINT ('Quntity is negativ')
	END
END

SELECT * FROM CreditCard;

EXECUTE MoneyTransfer '1234-1234-1234-1234', '4321-4321-4321-4321', 4000;

DELETE  FROM CreditCard;

DROP PROC MoneyTransfer;

CREATE DATABASE TOPAcademy
use TOPAcademy
go

CREATE TABLE Students
(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Coins INT NOT NULL,
UserName VARCHAR(50) NOT NULL,
PasswordHash VARCHAR(50) NOT NULL,
Salt VARCHAR(100) NULL,

CONSTRAINT CK_Students_Coins CHECK (Coins > 0),
CONSTRAINT CK_Students_UserName UNIQUE (UserName)
)

CREATE TABLE Products
(
Id INT PRIMARY KEY IDENTITY,
Title NVARCHAR(50) NOT NULL,
Price INT NOT NULL,
Quantity INT NOT NULL,


CONSTRAINT CK_Products_Quantity CHECK (Quantity >= 0),
CONSTRAINT CK_Products_Price CHECK (Price >= 1)
)

insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Raimundo', 'Loadman', 40, 'rloadman0', 'WYcEYNyGe9');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Licha', 'McFarlan', 24, 'lmcfarlan1', 'VvT2TQK');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Quentin', 'Fowley', 40, 'qfowley2', 'K3hcK99NI');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Emelda', 'Simmons', 68, 'esimmons3', 'CiaWc0t1');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Sandye', 'Suggate', 18, 'ssuggate4', 'jHCSZ1AH');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Conchita', 'Fromant', 60, 'cfromant5', 'IZR9Mmo3Pr4');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Skyler', 'Vickerman', 93, 'svickerman6', 'jrJfU9GifUM');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Charin', 'McFadyen', 99, 'cmcfadyen7', 'nf0moQcXrFR7');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Yoko', 'Barnhart', 95, 'ybarnhart8', '12ly7Z');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Gregg', 'Jakubovski', 76, 'gjakubovski9', 'RfLOmU5qt3e');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Lexie', 'Bogeys', 67, 'lbogeysa', 'C2Xb9n');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Roderigo', 'Winnard', 83, 'rwinnardb', 'QSlxRX');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Erl', 'Bruford', 90, 'ebrufordc', 'RV304z');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Clo', 'Farrington', 17, 'cfarringtond', 'do73GjtU');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Bud', 'Chellam', 32, 'bchellame', 'cOMlSO4');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Arthur', 'Gregory', 78, 'agregoryf', 'gu3j2aaJJV4A');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Rosina', 'Coultard', 2, 'rcoultardg', 'FBN5oe');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Lindsey', 'Lintill', 29, 'llintillh', 'ouPaLVAj');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Cherilyn', 'Priddie', 32, 'cpriddiei', 'HucG1q9n');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Wells', 'Dunderdale', 36, 'wdunderdalej', 'oHAD0464S');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Urbano', 'Cottisford', 18, 'ucottisfordk', 'PDmP0ji8M');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Genvieve', 'Cuesta', 45, 'gcuestal', 'dRnH5KuTCs');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Morgan', 'Fuchs', 66, 'mfuchsm', 'lbu69Kb');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Bartlet', 'Andrin', 47, 'bandrinn', 'HbNGIWofiP');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Gerek', 'Boughton', 50, 'gboughtono', 'ymSl7Hg8G');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Koo', 'Schreurs', 9, 'kschreursp', 'nYbVCMN');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Ivonne', 'Shead', 50, 'isheadq', 'qXryTx');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Armando', 'Plott', 93, 'aplottr', 'DYDz5G');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Kaye', 'Cash', 35, 'kcashs', '1nOmYZMVqqA');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Gennifer', 'Harniman', 46, 'gharnimant', '6NWiJq');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Hobart', 'Hebron', 70, 'hhebronu', 'yW5dO1nrM');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Pamela', 'Crotch', 92, 'pcrotchv', '6dJt3ule2Xbq');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Judas', 'Konzel', 60, 'jkonzelw', '2U8VXNBIG');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Riley', 'Craig', 74, 'rcraigx', 'aUmWSwBXkpHX');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Danice', 'Kernaghan', 31, 'dkernaghany', 'tJJQ1J');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Jose', 'Stainburn', 19, 'jstainburnz', 'Yf1Ts7');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Winifred', 'Pulver', 60, 'wpulver10', 'uFh2pVEBD');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Debera', 'Cloutt', 96, 'dcloutt11', 'hhxkkn');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Glenn', 'O''Criane', 33, 'gocriane12', 'OwcuqjCl77fm');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Rod', 'Faveryear', 77, 'rfaveryear13', 'j1wd9iuhAphu');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Laina', 'Joutapavicius', 51, 'ljoutapavicius14', 'ePG30O1X');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Nettie', 'Hamber', 100, 'nhamber15', 'TirsZO');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Haleigh', 'Vallentine', 40, 'hvallentine16', 'XKhk6j');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Glynis', 'Iliff', 88, 'giliff17', 'PeoZdzojXF5x');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Beltran', 'Laugharne', 28, 'blaugharne18', 'lxjzLIQvSaCv');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Claudian', 'Glasscott', 30, 'cglasscott19', '3WxoWRxWf');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Sibilla', 'Stopforth', 83, 'sstopforth1a', 'vGffxBUaDpe');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Rennie', 'Coode', 47, 'rcoode1b', '1oKcgyjQlWm6');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Levey', 'Cash', 16, 'lcash1c', '9vAHgN');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Vina', 'Lutzmann', 85, 'vlutzmann1d', 'nsCZDxH');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Ofella', 'Cattermull', 45, 'ocattermull1e', 'DkbjZa07RUtM');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Clifford', 'Lebell', 77, 'clebell1f', 'EduSK4');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Joseph', 'Ledward', 99, 'jledward1g', '2lWhrBPT');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Ali', 'Southernwood', 96, 'asouthernwood1h', 'Ozpc2X');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Denise', 'Bergstram', 70, 'dbergstram1i', 'BWyrPQSn');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Pepito', 'Jennens', 93, 'pjennens1j', 'VFe3qKm20T2');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Ancell', 'Curtis', 98, 'acurtis1k', 'cbUEB1AWF');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Alia', 'Bransom', 44, 'abransom1l', '71DnqkruL9Be');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Noland', 'Winskill', 40, 'nwinskill1m', 'aIbJYNh');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Katlin', 'O''Fallone', 26, 'kofallone1n', 'eIgANeRDm');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Dagmar', 'Goering', 84, 'dgoering1o', 'o4VgaPfE');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Rudyard', 'Gyorffy', 55, 'rgyorffy1p', '7bD6WEHR');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Chet', 'Cruttenden', 40, 'ccruttenden1q', 'gBMPBABM');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Rivalee', 'Martynikhin', 41, 'rmartynikhin1r', 'cAEGvGF3Z');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Blondelle', 'Wolfinger', 1, 'bwolfinger1s', 'rIeZdTIJt1');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Vanda', 'Kingsbury', 36, 'vkingsbury1t', 'R3vxsC');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Ashlin', 'Dubbin', 94, 'adubbin1u', '49pzuLiV');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Doria', 'Jewett', 84, 'djewett1v', 'JdR8xWmLi3');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Armstrong', 'Larose', 75, 'alarose1w', 'VGdxeKEdvO');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Fionna', 'Disney', 9, 'fdisney1x', 'WRjZJUcF');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Tam', 'Slaughter', 30, 'tslaughter1y', 'VaSF7uOxyO');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Esdras', 'Baumford', 28, 'ebaumford1z', 'ZpF57rVu');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Papagena', 'Eversfield', 3, 'peversfield20', 'LFIJaen');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Doro', 'Caveill', 5, 'dcaveill21', '45KNMx88QdD');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Nathalia', 'Whyborn', 100, 'nwhyborn22', 'BwJxcC0S');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Karie', 'Govini', 26, 'kgovini23', 'q4Pf8VFRC');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Inesita', 'Wilder', 33, 'iwilder24', 'fjKBuI7p9e');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Tiertza', 'Vedmore', 61, 'tvedmore25', '4nYmiACavn');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Carly', 'Dixey', 97, 'cdixey26', 'dTC3cv8Zk');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Pietrek', 'Peepall', 11, 'ppeepall27', 'IMHy64lsKNI');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Agatha', 'Pope', 61, 'apope28', 'I4iT9d1Xf440');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Kristofer', 'Blunkett', 92, 'kblunkett29', 'Ez883Nb5x');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Reynard', 'Fossord', 15, 'rfossord2a', 'Xy9gRy');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Kahaleel', 'Carwithim', 91, 'kcarwithim2b', 'RTmLeBv');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Rich', 'Minnis', 51, 'rminnis2c', '69XbF1zP');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Spenser', 'Dixie', 69, 'sdixie2d', 'fUcaCYo9QX3');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Wolf', 'Deverose', 35, 'wdeverose2e', 'Re6dB7');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Alys', 'Chantillon', 45, 'achantillon2f', 'BdO61Kq6v1FK');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Boothe', 'Davidovsky', 21, 'bdavidovsky2g', '10o0d4RirJ');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Gregorius', 'Gyppes', 33, 'ggyppes2h', '3jwi5M2');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Jaynell', 'Pateman', 97, 'jpateman2i', 'UstgJaP8jLn');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Ruperta', 'Stribling', 80, 'rstribling2j', '4EmFSqMXmGeC');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Svend', 'Kowal', 94, 'skowal2k', 'SOJeHonG');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Devlen', 'Glowacz', 56, 'dglowacz2l', 'GKHMniDTk');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Liv', 'Treker', 96, 'ltreker2m', 'ejgBMAUbC3c3');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Nickie', 'Lawrenson', 85, 'nlawrenson2n', 'VuQroG');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Florencia', 'Fryer', 5, 'ffryer2o', 'GgkL0RJ');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Davine', 'Endecott', 96, 'dendecott2p', 'HO2ODwqvhf1K');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ('Trumaine', 'Lantaff', 97, 'tlantaff2q', '282kMopNhIoz');
insert into Students (FirstName, LastName, Coins, Username, PasswordHash) values ( 'Jaquenette', 'Brosoli', 48, 'jbrosoli2r', 'FlYO23OHsyzd');

SELECT * FROM Students;