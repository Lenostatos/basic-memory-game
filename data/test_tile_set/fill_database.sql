PRAGMA foreign_keys = ON;

DELETE FROM "File_Info";
DELETE FROM "File_Type";
DELETE FROM "Item";

INSERT INTO "Item" VALUES 
	(1, 'Pine'),
	(2, 'Oak'),
	(3, 'Spruce'),
	(4, 'Black Alder'),
	(5, 'Birch'),
	(6, 'Beech')
;

INSERT INTO "File_Type" VALUES
	(1, 'text'),
	(2, 'png'),
	(3, 'jpeg'),
	(4, 'mp3')
;

INSERT INTO "File_Info" ("path", "id_Item", "id_File_Type") VALUES
	('pine/english_name.txt', 1, 1),
	('pine/latin_name.txt', 1, 1),
	('pine/whole_tree.jpg', 1, 3),
	('pine/leaves_and_cones.jpg', 1, 3),
	('oak/english_name.txt', 2, 1),
	('oak/latin_name.txt', 2, 1),
	('oak/whole_tree.jpg', 2, 3),
	('oak/leaves_and_acorns.jpg', 2, 3),
	('spruce/english_name.txt', 3, 1),
	('spruce/whole_tree.jpg', 3, 3),
	('black_alder/english_name.txt', 4, 1),
	('black_alder/latin_name.txt', 4, 1),
	('black_alder/leaves_and_fruits.jpg', 4, 3),
	('birch/latin_name.txt', 5, 1)
;


.mode column
.headers on

SELECT * FROM "Item";
SELECT * FROM "File_Type";
SELECT * FROM "File_Info";
SELECT * FROM "File_Count";
