# C# and CSS Week 5 Team Week Code Review: Persona 5 Shadow Collector

#### A Simulation of the Persona 5 Shadow Collector Game Mechanic. 6/20/17

#### By **Isabella Abatgis, James Lannon, Pete Lazuran, Andrew Dalton, Epicodus**

## Description

This program is a recreation of the negotiation mechanic in the game Persona 5


## Example Play-Through



| Behavior | Input / User Action | Output / Program Action |
|:---------|:------|:-------|
| Displays first question for a randomly selected shadow when user clicks "Play" | "Play" |The program selects a random shadow and a random question with set answers |
| Keeps track of the random shadow for the duration of the "negotiation phase"| No input required | Various methods of sending the random shadow's id are used to send it through the sequential pages|
| User is prompted to answer a randomly selected question from the shadow | Click radio selection | The selected answer is stored once the user clicks the Reply button|
|Determine if the question was answered correctly| User clicks reply after selecting an answer | The "type" of the answer is compared to the "type" of the shadow to determine whether it is correct or not|
|Result page displays an outcome depending on whether the question was answered correctly or not|First question was answered|Webpage shows success result if correct and a link to the next question or failure result and a link to index|
|Keeps track of the randomly selected first question so that it is not asked as the second question|No input required|Various methods of sending the random question's id are used to send through the sequential pages|
|For the question/answer phase the process repeats the same as before, omitting the first question from the pool of possible second questions| n/a|n/a|
|When the second question is answered correctly the shadow is captured| User answers the second question correctly|Capture page is displayed with an image of a hand holding the captured shadow|


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

*{This software is licensed under the MIT license}*

Copyright (c) 2017 **_{Isabella Abatgis, James Lannon, Pete Lazuran, Andrew Dalton, Epicodus}_**
