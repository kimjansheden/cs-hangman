# cs-hangman
My first home assignment in C# at the start of my education. The task was to create a console application representing the Hangman game.

## ASSESSMENT
Assessment will take place according to these criteria

### For Godkänt (G) the following requirements must be met:
* The application must have a list of at least 10 words, from which one
random word will be used every time you play.
* The user must be able to see which letters he has already guessed.
* The user must be able to see how many attempts are left
* Letters’ cases don’t matter. This means, A and a are equivalent.

### For Väl Godkänt (VG) the following requirements must be met:
* All the requirements for Godkänt.
* The user must be able to play again if desired
* The “cool input” feature must be implemented

## PROJECT DESCRIPTION
The Hangman game consists of guessing a word in 6 attempts.
On every attempt the player guesses one letter and:

1. If the letter is in the word, all occurrences of the letter in the word are revealed to the player.
1. Otherwise, the player loses one attempt

In any case, the guessed letter is added to a list of used letters, for now on, usedLetters.

### The user interface
The word to be guessed is displayed to the user with underscores if a letter is not revealed yet, or the letter itself otherwise.
All positions must be separated by a space. For example, if the word is “foo” but only the “f” is revealed (guessed correctly
by the user), the output must be “f _ _”. See Example output section.

The usedLetters must be shown separated by a space to improve readability. E.g. “a b c” instead of “abc”
The attempts left must be displayed with a meaningful message. E.g “Attempts left: 3”

Every time a new move is made, the console must be cleared. This way the game looks more natural.

### The input
The user must be able to input his guess through the console, confirmed by pressing the “enter” key. If the user types more
than one character, only the first one must be considered. If the user types a blank line (hits enter without writing anything)
then the input should be ignored. This means, it never happened.

### The cool input (Requirement for VG)
When the user types a letter, two things can happen:
1. Confirm by pressing the key “enter”
2. Discarded by pressing the key “backspace”

When a letter is discarded it must be removed from the console and the user must be allowed to type again a letter.

### Messages
When the user wins, a freely chosen message must be displayed. E.g. “Congrats, you rock”

When the user loses, a freely chosen message is displayed indicating that he ran out of attempts. In addition, the word
must be revealed. See Example output section.

### Playing again (Requirement for VG)
When the user finishes a game (regardless of whether he won or not), he should be allowed to play a new game. E.g.
“Would you like to play again? y/n”. If the user says yes/ja then another game starts. If the user says no/nej then the
application terminates. Otherwise (neither yes nor no) the input must be ignored until a valid answer is provided by the
user.
