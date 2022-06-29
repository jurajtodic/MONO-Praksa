DROP TABLE Book
DROP TABLE Library

CREATE TABLE Library (
    LibraryID int NOT NULL PRIMARY KEY,
    Address varchar(255) NOT NULL,
    City varchar(255) NOT NULL
);

CREATE TABLE Book (
    BookID int NOT NULL PRIMARY KEY,
    Title varchar(255) NOT NULL,
    Author varchar(255) NOT NULL,
    Genre varchar(255) NOT NULL,
	ReleaseYear int NOT NULL,
	LibraryID int FOREIGN KEY REFERENCES Library(LibraryID)
);

INSERT INTO Library VALUES (0, 'Radiceva 4', 'Zagreb');
INSERT INTO Library VALUES (1, 'Osjecka 24', 'Vukovar');
INSERT INTO Library VALUES (2, 'Ul. Sv. Marka', 'Split');

INSERT INTO Book VALUES (0, 'The Hotel Nantucket', 'Elin Hilderbrand', 'Fiction',1978 ,0);
INSERT INTO Book VALUES (1, 'Battle for the American Mind', 'Pete Hegseth; David Goodwin', 'Nonfiction',2022 , 0);
INSERT INTO Book VALUES (2, 'Finding Me', 'Viola Davis', 'NonFiction',2012 , 0);

INSERT INTO Book VALUES (3, 'One Italian Summer', 'Rebecca Serle', 'Fiction',1986, 1);
INSERT INTO Book VALUES (4, 'Nightwork', 'Nora Roberts', 'Fiction',1865, 1);
INSERT INTO Book VALUES (5, 'Killing the Killers', 'Bill Reilly; Martin Dugard', 'NonFiction', 1999, 1);

INSERT INTO Book VALUES (6, 'The Storyteller', 'Dave Grohl', 'NonFiction',2002, 2);
INSERT INTO Book VALUES (7, 'Horse', 'Geraldine Brooks', 'Fiction',2000,  2);

--SELECT * FROM Library
--Select * FROM Book

--JOIN, GROUP BY, HAVING, INDEKSI, CONSTRAINT

SELECT Library.Address, Library.City, Book.Title, Book.Author
FROM Library
INNER JOIN Book ON Library.LibraryID=Book.BookID;

SELECT LibraryID, MIN(ReleaseYear)
FROM Book
GROUP BY LibraryID
HAVING MIN(ReleaseYear)>1900
ORDER BY MIN(ReleaseYear) DESC;



