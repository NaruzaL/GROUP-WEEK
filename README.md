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



//// Questions /////

Gloomy Questions

Q. If you were to take me on a date, where would we go?!
* Gloomy/Vague: Somewhere I can cry...
Irritable/Serious: A 5-Star restaurant
Upbeat/Funny: Your mom's house! Amirite?!


Q. If you were to give me a present, what would it be?
* Gloomy/Vague: I don't deserve anything...
Irritable/Serious: An alarm clock, I hate being late!
Upbeat/Funny: The Hangover Part II


Q. What kind of food is my favorite?
* Gloomy/Vague: Good food.
Irritable/Serious: Salad, it's good for me.
Upbeat/Funny: Pop Rocks!


Q. Are you a good person?
* Gloomy/Vague: Perhaps...
Irritable/Serious: Nobody is.
Upbeat/Funny: Girl pls...

Q. If I were a shape what would I be?
Gloomy/Vague: one with sides
Irritable/Serious: A square



Irritable questions

Q. If you were to take me on a date, where would we go?!
Gloomy/Vague: Somewhere I can cry...
* Irritable/Serious: A 5-Star restaurant
Timid/Kind: A field of flowers

Q. If you were to give me a present, what would it be?
Gloomy/Vague: I don't deserve anything...
* Irritable/Serious: An alarm clock, I hate being late!
Timid/Kind: A teddy bear!

Q. What kind of food is my favorite?
Gloomy/Vague: Good food.
* Irritable/Serious: Salad, it's good for me.
Timid/Kind: Cruelty free locally sourced macaroons.

Q. Are you a good person?
Gloomy/Vague: Perhaps...
* Irritable/Serious: Nobody is.
Timid/Kind: Of course, I'm an upstanding citizen!



Upbeat questions

Q. If you were to take me on a date, where would we go?!
Gloomy/Vague: Somewhere I can cry...
Irritable/Serious: A 5-Star restaurant
* Upbeat/Funny: Your mom's house! Amirite?!

Q. If you were to give me a present, what would it be?
Gloomy/Vague: I don't deserve anything...
Irritable/Serious: An alarm clock, I hate being late!
* Upbeat/Funny: The Hangover Part II

Q. What kind of food is my favorite?
Gloomy/Vague: Good food.
Irritable/Serious: Salad, it's good for me.
* Upbeat/Funny: Pop Rocks!

Q. Are you a good person?
Gloomy/Vague: Perhaps...
Irritable/Serious: Nobody is.
* Upbeat/Funny: Girl pls...


Timid questions

Q. If you were to take me on a date, where would we go?!
Gloomy/Vague: Somewhere I can cry...
Upbeat/Funny: Your mom's house! Amirite?!
* Timid/Kind: A field of flowers

Q. If you were to give me a present, what would it be?
Gloomy/Vague: I don't deserve anything...
Upbeat/Funny: The Hangover Part II
* Timid/Kind: A teddy bear!

Q. What kind of food is my favorite?
Gloomy/Vague: Good food.
Upbeat/Funny: Pop Rocks!
* Timid/Kind: Cruelty free locally sourced macaroons.

Q. Are you a good person?
Gloomy/Vague: Perhaps...
Upbeat/Funny: Girl pls...
* Timid/Kind: Of course, I'm an upstanding citizen!



Shadows:

Name: Arsene
Type: Upbeat
Intro: Hey there lil feller! Isn't it a beautiful day for being alive?!  You look like someone I could be a best friend with.

Name: Captain Kidd
Type: Upbeat
Intro: Ahoy there matey! Don't you just love the smell of the ocean breeze?!  You should join my crew as long as you're not a salty landlubber.
