/*
Kelompok 09 Teknet
*/

CREATE DATABASE TrackingVaksin
ON
	PRIMARY (NAME = TrackingVaksinPrimary,
	FILENAME = 'D:\Courses\4th Semester\Perkuliahan\Pemrograman Teknologi. NET\09_TrackingVaksin\TrackingVaksin.mdf',
	SIZE = 10MB,
	MAXSIZE = 20MB,
	FILEGROWTH = 20%)

LOG ON 
	(NAME = TrackingVaksinDBLog,
	FILENAME = 'D:\Courses\4th Semester\Perkuliahan\Pemrograman Teknologi. NET\09_TrackingVaksin\TrackingVaksin.ldf',
	SIZE = 30MB,
	MAXSIZE = 50MB,
	FILEGROWTH = 20%)

CREATE TABLE Login (
	id INT NOT NULL,
	Username VARCHAR (30) NOT NULL, 
	Passsword VARCHAR (30) NOT NULL,
	Role VARCHAR (20) NOT NULL

	PRIMARY KEY(id)
);

-- Dummy Data
INSERT INTO Login VALUES
	(1,'bpom', 'bpom123', 'BPOM'),
	(2,'rs', 'rs123', 'RS'),
	(3,'produsen', 'produsen123', 'Produsen');

SELECT * FROM LOGIN

CREATE TABLE Data_Penduduk (
	id INT NOT NULL Identity(1, 1),
	NIK VARCHAR(20) NOT NULL UNIQUE, 
	nama VARCHAR (30) NOT NULL,
	kelurahan VARCHAR (30) NOT NULL,
	kecamatan VARCHAR (30) NOT NULL,
	kota VARCHAR (50) NOT NULL,
	kode_pos INT NOT NULL

	PRIMARY KEY (id)
);

-- Dummy Data
INSERT INTO Data_Penduduk VALUES
	('11319019','Evan Sianipar', 'Marihat', 'Siantar Nauli', 'Pematangsiantar', '21129'),
	('11319028','Vicktor Naibaho', 'Tanah Jawa', 'Tanah Jawa', 'Tanah Jawa', '21130'),
	('11319037','Poibe Matondang', 'Tapanauli Utara', 'Tarutung', 'Tarutung', '21310'),
	('11319040','Ester Hutabarat', 'Tapanauli Utara', 'Tarutung', 'Tarutung', '21310');

SELECT * FROM Data_Penduduk;

CREATE TABLE Reg_Vaksin (
	id INT NOT NULL Identity(1, 1),
	kode VARCHAR (30) NOT NULL UNIQUE,
	jenis VARCHAR (30) NOT NULL

	PRIMARY KEY (id)
);

INSERT INTO Reg_Vaksin VALUES 
	('VAK001', 'Tablet'),
	('VAK002', 'Pil'),
	('VAK003', 'Bungkus');

SELECT * FROM Reg_Vaksin

CREATE TABLE LaporValidasiVaksin (
	idLapor INT IDENTITY (1, 1), 
    namaProdusen VARCHAR (50)NOT NULL,		
	deskripsi VARCHAR (50) NOT NULL,
	status bit NULL,
	id INT NULL UNIQUE, 
	PRIMARY KEY (idLapor),
	FOREIGN KEY (id) REFERENCES Reg_Vaksin(id)
);

INSERT INTO LaporValidasiVaksin VALUES 
	('PT. ANUGERAH','Kondisi Aman',0, 1),
	('PT. Jaya Makmur','Oke',0, 2);

SELECT * FROM LaporValidasiVaksin

CREATE TABLE Vaksin (
	idVak INT IDENTITY (1,1),
	status VARCHAR (20) NOT NULL

	PRIMARY KEY (idVak)
)

INSERT INTO Vaksin VALUES
	('Valid'),
	('Invalid');

SELECT * FROM Vaksin;

CREATE TABLE LaporTerimaVaksin (
	idTer INT IDENTITY (1,1),
	idLapor INT NULL,
	pengirim VARCHAR (50) NOT NULL,
	deskripsi VARCHAR (50) NULL,
	status bit NULL,
	idVak INT NULL

	PRIMARY KEY (idTer),
	FOREIGN KEY (idLapor) REFERENCES LaporValidasiVaksin(idLapor),
	FOREIGN KEY (idVak) REFERENCES Vaksin(idVak)
)

INSERT INTO LaporTerimaVaksin VALUES
	(1, 'RS. Murni Teguh', 'Mantap',0, 1),
	(2, 'RS. Vita Insani', 'Oke',0, 2);

SELECT * FROM LaporTerimaVaksin

CREATE TABLE CekValid (
	id INT IDENTITY (1,1),
	idRegVaksin INT NULL UNIQUE,
	status bit NULL,
	idPend INT NULL UNIQUE,
	idVak INT NULL

	PRIMARY KEY (id)
	FOREIGN KEY (idRegVaksin) REFERENCES Reg_Vaksin(id),
	FOREIGN KEY (idPend) REFERENCES Data_Penduduk(id),
	FOREIGN KEY (idVak) REFERENCES Vaksin(idVak)
)

INSERT INTO CekValid VALUES
	(1, 0, 1, 1),
	(2, 1, 2, 2);

SELECT * FROM CekValid

CREATE TABLE PenggunaanVaksin (
	idUsed INT IDENTITY (1,1),
	noRekamMedis VARCHAR (50) NOT NULL UNIQUE,
	status bit NULL,
	idRegVaksin INT NULL UNIQUE,
	idPend INT NULL

	PRIMARY KEY (idUsed),
	FOREIGN KEY (idRegVaksin) REFERENCES Reg_Vaksin(id),
	FOREIGN KEY (idPend) REFERENCES Data_Penduduk(id)
)

INSERT INTO PenggunaanVaksin VALUES
	('REK001', 0, 1, 1),
	('REK002', 1, 2, 2);

SELECT * FROM PenggunaanVaksin

