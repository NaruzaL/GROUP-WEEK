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

Name: Ar<span class="inverse">S</span>Ene
Type: Upbeat
Intro: Hey there lil feller! Isn't it a beautiful day for being alive?!  You look like someone I could be a best friend with.

Name: Ca<span class="inverse">p</span>TAi<span class="inverse">n</span> KiDd
Type: Upbeat
Intro: Ahoy there matey! Don't you just love the smell of the ocean breeze?!  You should join my crew as long as you're not a salty landlubber.

Name: J<span class="inverse">o</span>h<span class="inverse">A</span>nNa
Type: Upbeat
Intro: Hey there easy rider!  There's nothing like the thrill of cruising down a windy road all to yourself, don't you agree? Hop on and let's go for a ride!

Name: C<span class="inverse">e</span>RberuS
Type: Timid
Intro: Hi... you smell like fish... I like fish... do you like me?

Name: NEcr<span class="inverse">O</span>noM<span class="inverse">i</span>con
Type: Timid
Intro: Beep Bloop... I'm shy... beep. Wanna be friends? ...bleep.

Name: miL<span class="inverse">A</span>dy
Type: Timid
Intro:  Hello darling...  I see you looking at me.  Aren't you going to ask me to dance?

Name: G<span class="inverse">O</span>emoN
Type: Irritable
Intro: Ugh, what do you want? You're standing in the way of my fans.  Do you really think I wore these shoes for YOUR sake?!

Name: CA<span class="inverse">r</span>me<span class="inverse">n</span>
Type: Irritable
Intro: Oh great, another pitiful loser has come to worship me.  I don't have time for this.  Get in line.  

Name: ZO<span class="inverse">R</span>ro
Type: Irritable
Intro: You actually think that YOU can challenge ME to a duel?  Don't waste my time.

Name: O<span class="inverse">n</span>gyo-Ki
Type: Gloomy
Intro: What? Oh.. Hi.  Sorry I didn't see you.  I'll move, I'm always in the way.  *sigh*

Name: T<span class="inverse">S</span>U<span class="inverse">k</span>uYomi
Type: Gloomy
Intro: *Tsukuyomi looks at you with a forlorn face and remains silent*

Name: <span class="inverse">C</span>hron<span class="inverse">o</span>s
Type: Gloomy
Intro:  What are you trying to do?  Battle me?  I see how this all ends... there's no point.  
