# Developer Notes

## General Philosophy
* Readability
* Documentation
* Single responsibility
* Interface over 

## Project Structure
### Code
* Game logic
* Database
	* An Entity Framework (EF)
	* A register for SQL statements
	* Data Transfer Objects (DTO) that represent records of tables or queries
	* A service that uses the register and the EF to distribute and receive DTOs to/from the other parts of the code.
* UI
	* Controllers
* GUI
	* Controllers

### Database
* SQLite