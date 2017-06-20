SQL view all

USE persona_five
SELECT * FROM shadows
SELECT * FROM shadows_answers
SELECT * FROM answers
SELECT * FROM questions
SELECT * FROM questions_answers


USE persona_five
CREATE TABLE shadows(id INT IDENTITY(1,1), name VARCHAR(255), type VARCHAR(255), intro VARCHAR(255), img VARCHAR(255))
CREATE TABLE answers(id INT IDENTITY(1,1), answer VARCHAR(255), type VARCHAR(255))
CREATE TABLE questions(id INT IDENTITY(1,1), question VARCHAR(255), type VARCHAR(255))
CREATE TABLE shadows_answers(id INT IDENTITY(1,1), shadow_id INT, answer_id INT)
CREATE TABLE questions_answers(id INT IDENTITY(1,1), question_id INT, answer_id INT)
