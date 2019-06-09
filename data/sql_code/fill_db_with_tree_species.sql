.mode column
.headers on

PRAGMA foreign_keys = ON;

DELETE FROM "File_Path";
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

INSERT INTO "File_Path" VALUES
	(1, '../../../../data/tree_species_data/pine/english_name.txt', 1, 1),
	(2, '../../../../data/tree_species_data/pine/latin_name.txt', 1, 1),
	(3, '../../../../data/tree_species_data/oak/english_name.txt', 2, 1),
	(4, '../../../../data/tree_species_data/oak/latin_name.txt', 2, 1),
	(5, '../../../../data/tree_species_data/spruce/english_name.txt', 3, 1),
	(6, '../../../../data/tree_species_data/spruce/latin_name.txt', 3, 1),
	(7, '../../../../data/tree_species_data/black_alder/english_name.txt', 4, 1),
	(8, '../../../../data/tree_species_data/black_alder/latin_name.txt', 4, 1),
	(9, '../../../../data/tree_species_data/birch/english_name.txt', 5, 1),
	(10, '../../../../data/tree_species_data/birch/latin_name.txt', 5, 1)
;


SELECT * FROM "Item";
SELECT * FROM "File_Type";
SELECT * FROM "File_Path";
SELECT * FROM "Items";