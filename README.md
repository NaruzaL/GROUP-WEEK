# C# and CSS Week 5 Team Week Code Review: Persona 5 Shadow Collector

#### A Simulation of the Persona 5 Shadow Collector Game Mechanic. 6/20/17

#### By **Isabella Abatgis, James Lannon, Pete Lazuran, Andrew Dalton, Epicodus**

## Description



## Setup/Installation Requirements

1. To run this program, you must have a C# compiler (try [Mono](http://www.mono-project.com)).
2. Install the [Nancy](http://nancyfx.org/) framework to use the view engine. Follow the link for installation instructions.
3. Clone this repository.
4. Open SSMS (SQL Server Management Studio which you can Download here [https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms])
5. Select File > Open > File and select your .sql file.
6. If the database does not already exist, add Database Script below to your compiler window in SSMS
7. Save the file.
8. Click ! Execute.
9. Verify that the database has been created and the schema and/or data imported.
10. Open the command line (try using the Windows Powershell [https://msdn.microsoft.com/en-us/powershell/mt173057.aspx]) and navigate into the repository. Use the command "dnx kestrel" to start the server.
11. On your browser, navigate to "localhost:5004" and enjoy!

##Database and Tables

CREATE persona_five;
GO
USE persona_five;
GO
CREATE TABLE shadows(id INT IDENTITY(1,1), name VARCHAR(255), type VARCHAR(255), intro VARCHAR(255), img VARCHAR(255));
GO
CREATE TABLE answers(id INT IDENTITY(1,1), answer VARCHAR(255), type VARCHAR(255)):
GO
CREATE TABLE questions(id INT IDENTITY(1,1), question VARCHAR(255), type VARCHAR(255)):
GO
CREATE TABLE shadows_answers(id INT IDENTITY(1,1), shadow_id INT, answer_id INT);
GO
CREATE TABLE questions_answers(id INT IDENTITY(1,1), question_id INT, answer_id INT);
GO
CREATE TABLE player(id INT IDENTITY(1,1) name VARCHAR(255), select bit, image VARCHAR(255));
GO

## Known Bugs
* Clicking the reply button without selecting an answer yields a 500 error.

## Technologies Used
* C#
  * Nancy Framework
  * Razor View Engine
  * ASP.NET Kestrel HTTP server
  * xUnit
  * SQL and SSMS Database Software
  * SASS
  * CSS
  * HTML

## Support and contact details

_If you notice any issues regarding my page or my code, please contact me at abatgis@gmail.com, jamesmlannon1990@live.com, pdlazuran@gmail.com, expandrew@gmail.com._

### License

*{This software is licensed under the GPL license}*

Copyright (c) 2017 **_{Isabella Abatgis, James Lannon, Pete Lazuran, Andrew Dalton, Epicodus}_**
