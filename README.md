SQL view all

USE persona_five
SELECT * FROM shadows
SELECT * FROM shadows_answers
SELECT * FROM answers
SELECT * FROM questions
SELECT * FROM questions_answers

CREATE persona_five_test
USE persona_five_test
CREATE TABLE player(id INT IDENTITY(1,1) name VARCHAR(255), select bit, image VARCHAR(255))
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


//questions from the game
name: lamia
type: Gloomy
quesiton: why are you taking so much anger out on me? what is irritating you so much?
answers: gloomy - Slow-ass cashiers,
n/a - egotistical women,
n/a - I'm not irritated
question2: it frustrates me to think my impending death here would be meaningless. And yet that might be because my life may be meaningless. All I known is the way of life here
answers: n/a - It's not meaningless,
 gloomy - there are other ways to live,
  n/a - you had a good run

name: anubis
type: gloomy
question: you know up til now I did whatever I wanted. I knew it was going to catch up to me some day. If you're going to kill me do me a solid and make it quick.
answers: gloomy - aren't you scared,
 not gloomy -  I'll have more fun first,
  n/a - stop trying to act cool
question2: hey you're kinda skinny ain't ya. These days I hear even men go on diets too. What do you usually eat?
answers: gloomy - curry,
 n/a - vegetables,
  n/a - protein
question3: I've got this girl waiting for me. You know what I'm getting at right? You think you could let me go see my girl.
answers: n/a - nope,
n/a - she probably left,
gloomy - what kind of girl is she?
question 4: Maybe it's the generation gap sonny but I just can't get what your deal is sonny. In the very end what the hell are you trying to tell me.
answers: irritable - I'm telling you to die,
 n/a -  why do we fight?,
 gloomy - I don't really know

name: isis
type: Timid
question: Allow me to ask you something, would you do to anyone else what you're doing to me now.
answers: timid - I sure would,
 n/a - no I wouldn't,
  serious - this is a special exception
quesiton: You have teammates who would mourne you were something to happen to you do you not? I also have loved one's who would miss me. You do catch my meaning yes?
answers: timid - I just realized that,
 n/a - none of your business,
  n/a - I'm always alone

name: black ooze
type: Irritable
question: Hey don't you got anything better to do? Seriously, cos-playing in a place like this. Are you just really freaking bored?
answer: n/a - I am,
 irritable - I'm actually very busy,
  n/a - shut up!
question: Yo look at me, I know I'm getting all sweaty. I'm glistening ain't I?
answers: gloomy - like a disco ball,
 n/a - not at all,
 not irritable - why does that matter?
question: So is this the end? I could've been a star.
answers: n/a -  A star?,
 gloomy - that's never happening,
 irritable - are you giving up?
question: So can I ask you something? I'm not sure I get what's happening here. Did I lose?
answers: n/a - I suppose so,
 irritable - what don't you get?,
 n/a - naw, you totally won

name: moth man
type: timid
question: After me look closer me can see you really young human. You not even alive that many years. Why do you fight and put yourself in harm's way?
answers: timid - I want to get stronger,
 n/a -  because i see an enemy,
  n/a - I dont actually know.
question: me know human's take joy in raising decendants, your future generation. So me have to ask you given much thought what if you go to place where you could die at any moment?
answers: timid - I've thought about it,
 n/a - I dont' want kids,
 n/a - I'm not cofortable with this.

name: decarabia
type: gloomy
question: I was just passing by and you roughed me up real bad. Hey what's your deal? Something bad happen in your life or something sonny?
answers: gloomy - It's not like that,
 not gloomy - nothing but bad things,
 n/a - you're getting on my nerves
question: Geez looks like I ran into one crazy brat. Hey so what do you think when you think about the future?
answers: gloomy - An average level of happiness,
 n/a - live fast die young,
 n/a - I just want to enjoy the now.

name: bellphegor
type: irritable
question: I gotta say you've been a pretty inconsiderate host. You oughtta show more hospitality. Couldn't you at least make me a cup of tea or something? Hell, that'd be real polite.
ansers: irritable - I don't have any,
n/a - brew your own,
n/a - I'm not hospitable.

name: kaiwan
type: timid
question: ain't you kinda old to be playin' dress up? So who are you trying to impress with that mask?
answers: timid - nobody,
 n/a - shut up,
 not timid - I'm actually still young.
question: you know if you think about it I'm basically your sempai. Just thinking about heirarchy you should be showing me a little more respect, shouldn't you?
answers: timid - you're right senpai,
 n/a - I've never though about it,
 n/a - I perfer mutual respect.

name: scathach
type: Upbeat
question: I must ask, was there something you desired of me? I'm inclined to turn you down but if you wish to speak perhaps I will consider it.
answers: you have nothing I want,
 upbeat - are you bored,
 not upbeat - that's a horrible bored?
question: things look rather bleak for us at the moment but do you understand that I"m here because people like you exist, right?
answers: upbeat - I never though of that,
 n/a - eh, it doesn't matter,
 n/a - what do you mean

name: mithras
type: gloomy
question: ah, I wonder if this is it for me. If I had known things would turn out like this I wish I would've found the courage to ask that girl out
answers:n/a - too late for regrets,
 gloomy - you never had a chance,
 n/a - I'll make "that girl" happy.
question: hold on it seems like you may have gotten the wrong idea. I don't hate you, no I dont' feel that way at all
answers: n/a - is that so?,
 gloomy - too late,
 n/a - well, I hate you
question: you just waltz into our territory acting like you belong here. Who in the blazes do you thing you are?
answers: gloomy - I feel bad about that,
 n/a - I'm me!,
  n/a - I don't have to answer to you
question: what did you want coming all the way to a place like this?
answers: n/a - a thrilling adventure,
 n/a - a treasure hunt,
 gloomy - slaughter

name: sui-ki
type: gloomy
question: this has been bugging me for a while but is it me or does something stink?
answers: n/a - it's just you, gloomy - it's coming from you, n/a - I smell a lie
question: hey you, what would you do if I told you I knew I could win? You'd have no idea I was about to use my ultimate move
anwers: n/a - for real!?, n/a - that's worrying, gloomy - try me

name: tak-minakata
type: gloomy
question: why are you going for me? aint there worse people out there? what kinda guys piss you off?
answers: gloomy - slow walkers,
n/a - loud talkers,
upbeat - nobody

name: fuu-ki
type: gloomy
question: you did a hell of a job cornering me like this, I gotta ask how do you train?
answers: gloomy - I don't really train,
n/a - I just have a knack for it,
n/a - luck's usually on my side.
questnion: everyone says I'm young but I've lived much longer than you have sonny. You know how they say be kind to your elders? Has no one ever taught you that?
anwe4rs: n/a - someone did once,
n/a - I don't care,
gloomy - I don't want to grow old.
question: Ah, well, it looks like the last moment of my life's finally snuck up on me. You know if I'm going to be killed, I'd reather be offed by some beautiful classy woman
answers: gloomy - sorry,
n/a - you don't get to be picky,
n/a - it's all the same

name: kin-ki
type: irritable
question: Human, you dumb. This territory is ours. Why do you keep trampling here? What you humans thinking?
answers: n/a - sorry about that,
irritable - I haven't thought about it,
n/a - ugh, you talk too loud
question: Me am going to haunt you for the rest of your life. Me always right behind you
anwers: n/a - that would be troublesome,
n/a - I could carry that weight,
irritable - I wouldn't like that.
question: Hey human, you look really young. You still at age where you depend on others, huh? you go back to your mother's arms. You need to take nap now.
ansers: n/a - I'm not that young,
irritable - I'm not sleepy yet,
n/a - mom will wait till I'm done.
