# A Memory Game

## Summary
The purpose of this project is to create a simple memory game with tiles featuring different tree species and their properties. However the software will be designed in such a way that changing to other sets of tiles won't be a problem.

## Current State
There is no working version of the application yet. Currently the game logic is being implemented.

## Key Features
+ Matching tiles will not simply show the same content, but anything related to a common entity, e.g. a picture of a tree and a description of site requirements related to the same tree species.
+ A set of matching tiles will not be limited to two tiles, but can contain more than that. However within one game all sets will consist of the same number of tiles.

## Key Limitations
+ Playing with others will only be possible using the same instance of the application.

## Contribute
Contributions in any way, shape or form are always welcome. If you want to learn more about the underlying code and possibly contribute to it, please read the developer notes (they are in the same folder as this document).

## Glossary
+ Tile: A rectangular chip with a blank back and a front side showing either a picture or text. The tile is covered when it is showing it's back side.
+ Tile Set: Consists of at least two tiles. The content on the front side of tiles of the same set refers to the same entity but can differ between the tiles.
+ Board: The place where covered tiles are arranged in rows and columns and can be uncovered, covered and taken away by players during a game.
+ Game: One or more players are trying to collect all tiles on the board by uncovering all tiles of one set one by one. Uncovering tiles of other sets results in all tiles being covered again.