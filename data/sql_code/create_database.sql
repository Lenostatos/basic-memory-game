-- Foreign keys will only be enforced if "PRAGMA foreign_keys" is set to "ON". This has to be done each time a database connection is established.
-- To do so type: "PRAGMA foreign_keys = ON;" TODO: find out how to query whether foreign_keys is already turned on before doing so.

PRAGMA foreign_keys = ON;

-- In order to avoid conflicts with SQL keywords every user-defined name has to be enclosed in double quotes.
-- String literals should be enclosed in single quotes.

-- TODO: find a command for dropping all the tables at once
DROP TABLE IF EXISTS "Item";
DROP TABLE IF EXISTS "File_Path";
DROP TABLE IF EXISTS "File_Type";
DROP VIEW IF EXISTS "Items";

CREATE TABLE "Item"(
	"id" INTEGER PRIMARY KEY, -- AUTOINCREMENT should not be used if possible because it imposes a performance overhead and "the purpose of AUTOINCREMENT is to prevent the reuse of ROWIDs from previously deleted rows" [SQLite docs]. For further information see the documentation.
	"name" TEXT UNIQUE NOT NULL
);

CREATE TABLE "File_Path"(
	"id" INTEGER PRIMARY KEY,
	"content" TEXT NOT NULL,
	"id_Item" INTEGER REFERENCES "Item" ON DELETE RESTRICT,
	"id_File_Type" INTEGER REFERENCES "File_Type" ON DELETE RESTRICT
);
CREATE INDEX "File_Path_Item_index" ON "File_Path"("id_Item");
CREATE INDEX "File_Path_File_Type_index" ON "File_Path"("id_File_Type");

CREATE TABLE "File_Type"(
	"id" INTEGER PRIMARY KEY,
	"interpretation" TEXT UNIQUE NOT NULL
);

CREATE VIEW "Items" AS
SELECT
	"Item"."id" AS "item_id",
	"Item"."name" AS "item_name",
	"File_Path"."content" AS "file_path",
	"File_Type"."interpretation" AS "file_type"
FROM "Item"
	JOIN "File_Path" ON "Item"."id" = "File_Path"."id_Item"
	JOIN "File_Type" ON "File_Path"."id_File_Type" = "File_Type"."id";