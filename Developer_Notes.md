# Developer Notes

## General Philosophy
* Readability
* Documentation
* Single Responsibility
* Interface over Inheritance

## Project Structure
### Code
* Game model
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