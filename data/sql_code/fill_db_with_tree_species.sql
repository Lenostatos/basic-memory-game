PRAGMA foreign_keys = ON;

DELETE FROM "File_Info";
DELETE FROM "File_Type";
DELETE FROM "Item";

INSERT INTO "Item" VALUES 
	(1, 'Pine'),
	(2, 'Oak'),
	(3, 'Spruce'),
	(4, 'Black Alder'),
	(5, 'Birch')
;

INSERT INTO "File_Type" VALUES
	(1, 'text'),
	(2, 'png'),
	(3, 'jpeg'),
	(4, 'mp3')
;

INSERT INTO "File_Info" VALUES
	(1, 'pine/english_name.txt', 1, 1),
	(2, 'pine/latin_name.txt', 1, 1),
	(3, 'oak/english_name.txt', 2, 1),
	(4, 'oak/latin_name.txt', 2, 1),
	(5, 'spruce/english_name.txt', 3, 1),
	(6, 'spruce/latin_name.txt', 3, 1),
	(7, 'black_alder/english_name.txt', 4, 1),
	(8, 'black_alder/latin_name.txt', 4, 1),
	(9, 'birch/english_name.txt', 5, 1),
	(10, 'birch/latin_name.txt', 5, 1)
;


.mode column
.headers on

SELECT * FROM "Item";
SELECT * FROM "File_Type";
SELECT * FROM "File_Info";
SELECT * FROM "File_Count";
