DROP DATABASE eCatalog

CREATE DATABASE eCatalog


drop table GrupeStudiu
drop table Studenti
drop table ProfesoriMaterii
drop table Materii
DROP TABLE Profesori


CREATE TABLE GrupeStudiu (
	IdGrupa int IDENTITY(1,1) PRIMARY KEY,
	NumeGrupa nvarchar(40) NOT NULL,
	An int NOT NULL,
)

CREATE TABLE Materii (
	IdMaterie int IDENTITY(30,1) PRIMARY KEY,
	NumeMaterie nvarchar(40) NOT NULL,
	An int NOT NULL
)

CREATE TABLE Profesori (
	IdProfesor int IDENTITY(100,1) PRIMARY KEY,
	Nume nvarchar(30) NOT NULL,
	Prenume nvarchar(30) NOT NULL,
	Username varchar(50) NOT NULL,
	Parola nvarchar(50) NOT NULL
)

CREATE TABLE ProfesoriMaterii(
	IdProfesorMaterie int IDENTITY(300,1) PRIMARY KEY,
	IdProfesor int FOREIGN KEY REFERENCES Profesori(IdProfesor),
	IdMaterie int FOREIGN KEY REFERENCES Materii(IdMaterie),
	IdGrupa int FOREIGN KEY REFERENCES GrupeStudiu(IdGrupa)
)


CREATE TABLE Studenti(
	IdStudent int IDENTITY(200,1) PRIMARY KEY,
	Nume nvarchar(30) NOT NULL,
	Prenume nvarchar(30) NOT NULL,
	Grupa nvarchar(40) NOT NULL,
	Username varchar(50) NOT NULL,
	Parola nvarchar(50) NOT NULL
)


INSERT INTO GrupeStudiu(NumeGrupa, An) VALUES
	('C111A', 1),
	('C111B',1),
	('C112A',2),
	('C113A',3),
	('C113B',3),
	('C113C',3),
	('C114A',4),
	('C114D',4)

INSERT INTO Profesori(Nume, Prenume, Username, Parola) VALUES
	('Togan', 'Mihai','mihai.togan','1234'),
	('Bereanu', 'Dana', 'dana.bereanu', '1234'),
	('Avram', 'Dan', 'dan.avram','1234'),
	('Marghescu', 'Andrei', 'andrei.marghescy','1234'),
	('Patriciu', 'Valeriu', 'valeriu.patriciu', '1234'),
	('Marzavan', 'Silvia', 'silvia.marzavan','1234'),
	('Margarit', 'Laurentiu', 'laurentiu.margarit','1234'),
	('Nita', 'Stefania', 'stefania.nita', '1234'),
	('Morogan', 'Luciana', 'luciana.morogan','1234'),
	('Bartis', 'Dana', 'dana.bartis','1234')

INSERT INTO Studenti(Nume, Prenume, Username, Parola, Grupa) VALUES
	('Prelipcean', 'Marius', 'marius.prelipcean', 'student','C113B'),
	('Banu', 'Teodora', 'teodora.banu', 'student', 'C113A'),
	('Vladescu', 'Andrei', 'andrei.vladescu', 'student', 'C114A'),
	('Valeca','Cristiana','valeca.cristiana', 'student','C114D'),	
	('Tonghioiu', 'Stefan','stefan.tonghioiu', 'student','C112A'),
	('Mihaiu', 'Valentin', 'valentin.mihaiu', 'student', 'C111A'),
	('Spiroiu', 'Maria', 'maria.spiroiu', 'student','C111B'),
	('Toader','Radu','radu.toader', 'student','C113C')

INSERT INTO Materii(NumeMaterie, An) VALUES
	('Programare',1),
	('Grafica',1),
	('Analiza',1),
	('Arhitecturi',2),
	('POO', 2),
	('Sisteme de Operare',2),
	('PSO',3),
	('Criptografie',3),
	('Ingineria Programarii',4),
	('Inteligenta Artificiala',4),
	('Aplicatii cu Baze de Date',3)


INSERT INTO ProfesoriMaterii(IdProfesor, IdMaterie, IdGrupa) VALUES
	(100,30,1),
	(100,30,2),
	(100,34,3),
	(100,38,7),
	(100,38,8),
	(101,37,4),
	(101,37,5),
	(101,37,6),
	(102,35,3),
	(102,36,4),
	(104,36,5),
	(104,36,6),
	(103,40,4),
	(104,35,3),
	(105,32,1),
	(105,32,2),
	(106,33,3),
	(107,40,5),
	(107,40,6),
	(108,39,7),
	(108,39,8),
	(109,31,1),
	(109,31,2)	


CREATE TABLE NoteStudenti(
	IdNota int PRIMARY KEY IDENTITY(200,1),
	 Nota float,
	IdStudent int FOREIGN KEY REFERENCES Studenti(IdStudent),
	IdProfesor int FOREIGN KEY REFERENCES Profesori(IdProfesor),
	IdMaterie int FOREIGN KEY REFERENCES Materii(IdMaterie)
)

INSERT INTO NoteStudenti(IdStudent, Nota, IdMaterie, IdProfesor) VALUES
	(200,10,37,101),
	(200,9,36,104),
	(201,7.6,36,102),
	(205,4,30,100),
	(202,5,39,108),
	(203,7,39,108),
	(204,3,33,106),
	(204,6,35,104),
	(206,4,30,100),
	(206,9,32,105),
	(207,8,36,104),
	(207,10,40,107)

INSERT INTO NoteStudenti(IdStudent, Nota, IdMaterie, IdProfesor) VALUES
	(200,8,36,104)

select * from Studenti
select * from GrupeStudiu
SELECT * FROM Profesori
SELECT * FROM Materii
select * from ProfesoriMaterii

SELECT P.Nume, P.Prenume,  m.NumeMaterie
FROM ProfesoriMaterii PM INNER JOIN Profesori P
ON PM.IdProfesor = P.IdProfesor INNER JOIN Materii m
on m.IdMaterie = pm.IdMaterie

SELECT * 
FROM Studenti s inner join GrupeStudiu gs
on s.Grupa = gs.NumeGrupa
where gs.An=3


SELECT p.IdProfesor, p.Nume, p.Prenume,m.IdMaterie, m.NumeMaterie, gs.IdGrupa, gs.NumeGrupa FROM ProfesoriMaterii pm 
inner join Profesori p 
on p.IdProfesor = pm.IdProfesor inner join
Materii m on m.IdMaterie=pm.IdMaterie inner join GrupeStudiu gs
on pm.IdGrupa = gs.IdGrupa 


select s.IdStudent, s.Nume, s.Prenume, gs.IdGrupa, gs.NumeGrupa from Studenti s inner join GrupeStudiu gs
on s.Grupa = gs.NumeGrupa


select (s.Nume+' '+s.Prenume) as Student, m.NumeMaterie, ns.Nota, (p.Nume+' ' + p.Prenume) as Profesor 
from NoteStudenti ns inner join studenti s
on ns.IdStudent=s.IdStudent inner join Materii m on
ns.IdMaterie = m.IdMaterie inner join Profesori p on
p.IdProfesor = ns.IdProfesor

select  gs.NumeGrupa, m.NumeMaterie, ns.Nota 
from NoteStudenti ns inner join Studenti s 
on ns.IdStudent = s.IdStudent inner join GrupeStudiu gs 
on s.Grupa=gs.NumeGrupa inner join Materii m
on m.IdMaterie=ns.IdMaterie
where m.NumeMaterie='PSO'


select Nota from NoteStudenti ns inner join Studenti s
on ns.IdStudent = s.IdStudent inner join Materii m
on ns.IdMaterie=m.IdMaterie
where m.NumeMaterie = 'PSO' and s.Username = 'marius.prelipcean'

select * from NoteStudenti
select * from Studenti
select * from Materii
select * from Profesori
select * from ProfesoriMaterii
select * from GrupeStudiu

select gs.NumeGrupa, m.NumeMaterie  from ProfesoriMaterii pm inner join Profesori p
on pm.IdProfesor = p.IdProfesor inner join GrupeStudiu gs
on pm.IdGrupa = gs.IdGrupa inner join Materii m 
on pm.IdMaterie = m.IdMaterie
where p.Username = 'mihai.togan' and gs.NumeGrupa = 'C111A'

select * from Studenti

select s.Nume+' '+s.Prenume as NumeStudent, ns.Nota, m.NumeMaterie from NoteStudenti ns inner join Studenti s
on ns.IdStudent = s.IdStudent inner join Materii m
on ns.IdMaterie = m.IdMaterie inner join Profesori p
on ns.IdProfesor = p.IdProfesor
where p.Username = 'mihai.togan' and s.Grupa ='C111A' and m.NumeMaterie='Programare'
 


update Studenti
set Parola='123'
where Username = 'marius.prelipcean'

select * from Materii

select * from Studenti s inner join GrupeStudiu gs
on s.Grupa = gs.NumeGrupa 
where gs.NumeGrupa = 'C113C' 


INSERT INTO NoteStudenti(IdStudent, Nota, IdMaterie, IdProfesor) VALUES
	(200,10,37,101),
	(200,9,36,104),
	(201,7.6,36,102),
	(205,4,30,100),
	(202,5,39,108),
	(203,7,39,108),
	(204,3,33,106),
	(204,6,35,104),
	(206,4,30,100),
	(206,9,32,105),
	(207,8,36,104),
	(207,10,40,107)

	//id student, nota, id materie, id profesor


	select m.IdMaterie from Materii m
	where m.NumeMaterie = 'Aplicatii cu Baze de Date'

	select * from Profesori