-- Foreign keys will only be enforced if "PRAGMA foreign_keys" is set to "ON". This has to be done each time a database connection is established.
-- To do so type: "PRAGMA foreign_keys = ON;" TODO: find out how to query whether foreign_keys is already turned on before doing so.

PRAGMA foreign_keys = ON;

-- In order to avoid conflicts with SQL keywords every user-defined name has to be enclosed in double quotes.
-- String literals should be enclosed in single quotes.

-- TODO: find a command for dropping all the tables at once
DROP VIEW IF EXISTS "Representation_Count";
DROP TABLE IF EXISTS "File_Info";
DROP TABLE IF EXISTS "Item";
DROP TABLE IF EXISTS "File_Type";

CREATE TABLE "Item"(
	"id" INTEGER PRIMARY KEY, -- AUTOINCREMENT should not be used if possible because it imposes a performance overhead and "the purpose of AUTOINCREMENT is to prevent the reuse of ROWIDs from previously deleted rows" [SQLite docs]. For further information see the SQLite documentation.
	"name" TEXT UNIQUE NOT NULL
);
CREATE INDEX "Item_name_index" ON "Item"("name");

CREATE TABLE "File_Info"(
	"id" INTEGER PRIMARY KEY,
	"path" TEXT NOT NULL,
	"id_Item" INTEGER REFERENCES "Item" ON DELETE RESTRICT,
	"id_File_Type" INTEGER REFERENCES "File_Type" ON DELETE RESTRICT
);
CREATE INDEX "File_Info_Item_index" ON "File_Info"("id_Item");
CREATE INDEX "File_Info_File_Type_index" ON "File_Info"("id_File_Type");

CREATE TABLE "File_Type"(
	"id" INTEGER PRIMARY KEY,
	"interpretation" TEXT UNIQUE NOT NULL
);

CREATE VIEW "Representation_Count" AS
SELECT
	"Item"."id" AS "id_item",
	COUNT (*) AS "count"
FROM "Item"
	JOIN "File_Info" ON "Item"."id" = "File_Info"."id_Item"
GROUP BY "Item"."id";