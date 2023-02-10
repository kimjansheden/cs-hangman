namespace Inlämningsuppgift_Hangman;

public class Play
{
    /// <summary>
    /// Starts the game and runs it as long as the player wants to play a new game.
    /// </summary>
    public static void Start()
    {
        var continuePlaying = Game();
        while (continuePlaying)
        {
            continuePlaying = Game();
        }
    }
    /// <summary>
    /// Runs the game and returns whether the player wants to play a new game or quit.
    /// </summary>
    /// <returns>The state of continuePlaying.</returns>
    private static bool Game()
    {
        //Creates the initial settings and variables.
        var words = new Words();
        var randomWord = words.RandomWord;
        var randomWordHidden = new char[randomWord.Length];
        var winner = false;
        CreateRandomWordHidden(randomWord, randomWordHidden);
        var attemptsLeft = 6;
        var usedLetters = "";
        var correctLetters = "";
        
        //The game.
        do
        {
            {
                //Restores the correctly guessed state to false for each round.
                var correct = false;

                //Prints game instructions.
                GameInstructions();

                //Prints what's left of the word(s) to guess.
                LeftToGuess(randomWordHidden);

                //Prints the used letters and the number of attempts left.
                Console.WriteLine($"Used letters:{usedLetters}");
                Console.WriteLine($"Attempts left: {attemptsLeft}");
                
                //Takes the input from the user and clears the console for each round.
                Console.Write($"Your guess: ");
                var input = ReadChar.Char();
                Console.Clear();
                
                //Checks if the user's inputted guess is correct.
                correct = Correct(randomWord, input, correct);
                
                //If letter is not already guessed, add it to the used letters.
                usedLetters = AddUsedLetters(usedLetters, input, correct, ref correctLetters, ref attemptsLeft);
                
                //Insert correctly guessed letter to its corresponding place(s) in the word(s).
                InsertLetter(randomWord, correctLetters, randomWordHidden);
                
                //If all letters are correctly guessed
                if (ArrayToString(randomWordHidden) == randomWord)
                {
                    winner = true;
                }
            }
        } while (!winner && attemptsLeft > 0);
        
        //Displays the end message and returns whether the player wants to continue playing or not.
        var continuePlaying = Finished(winner, randomWord);
        return continuePlaying;
    }

    private static void InsertLetter(string randomWord, string correctLetters, char[] randomWordHidden)
    {
        for (int i = 0; i < randomWord.Length; i++)
        {
            for (int j = 0; j < correctLetters.Length; j++)
            {
                if (char.ToLower(correctLetters[j]) == char.ToLower(randomWord[i]))
                {
                    //Checks if the correct letter is uppercase. If true, make the inputted letter into uppercase as well.
                    if (char.IsUpper((randomWord[i])))
                    {
                        randomWordHidden[i] = char.ToUpper(correctLetters[j]);
                    }
                    else
                    {
                        randomWordHidden[i] = correctLetters[j];
                    }
                }
            }
        }
    }

    private static string AddUsedLetters(string usedLetters, char input, bool correct, ref string correctLetters,
        ref int attemptsLeft)
    {
        //If letter is not already used.
        Console.SetCursorPosition(0, 1); //Print in the second top.
        if (!usedLetters.Contains(input, StringComparison.InvariantCultureIgnoreCase))
        {
            usedLetters += " " + char.ToLower(input);
            //If guessed correctly
            if (correct)
            {
                Console.WriteLine($"{input} is correctly guessed!");
                correctLetters += input;
            }
            else
            {
                Console.WriteLine($"{input} is unfortunately incorrectly guessed!");
                attemptsLeft--;
            }
        }
        else
        {
            Console.WriteLine("You have already guessed that letter. Try again.");
        }

        return usedLetters;
    }

    private static void LeftToGuess(char[] randomWordHidden)
    {
        for (int i = 0; i < randomWordHidden.Length; i++)
        {
            Console.Write($"{randomWordHidden[i]} ");
        }

        Console.WriteLine();
    }

    private static void GameInstructions()
    {
        Console.SetCursorPosition(0, 0); //Prints always at the top.
        Console.WriteLine("Write a letter and guess the word!");
        Console.WriteLine(Environment.NewLine);
    }

    private static bool Correct(string randomWord, char input, bool correct)
    {
        foreach (var letter in randomWord)
        {
            if (char.ToLower(input) == char.ToLower(letter))
            {
                correct = true;
            }
        }

        return correct;
    }

    private static void CreateRandomWordHidden(string randomWord, char[] randomWordHidden)
    {
        for (int i = 0; i < randomWord.Length; i++)
        {
            var letter = randomWord[i];
            if (letter == ' ')
            {
                randomWordHidden[i] = letter;
            }
            else
            {
                randomWordHidden[i] = '_';
            }
        }
    }


    private static string ArrayToString<T>(T[] array)
    {
        var theString = "";

        foreach (var item in array)
        {
            theString += item;
        }
        
        return theString;
    }

    private static bool Finished(bool winner, string correctWord)
    {
        Console.Clear();
        if (winner)
        {
            var message = "You rock!!!";
            var symbol1 = "*";
            var symbol2 = "o";
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(symbol1);
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(0,Console.CursorTop-5);
            Console.Write(symbol2);

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i == 2)
                    {
                        Console.Write(message[j]);
                        if (j == 8)
                        {
                            Console.Write(message[j+1]);
                        }
                        Thread.Sleep(100);
                        continue;
                    }
                    Console.SetCursorPosition(j,Console.CursorTop);
                    Console.Write(symbol1);
                    Console.SetCursorPosition(j+1,Console.CursorTop);
                    Console.Write(symbol2);
                    Thread.Sleep(100);
                }
                if (i != 2)
                {
                    Console.SetCursorPosition(Console.CursorLeft - 1,Console.CursorTop);
                    Console.Write(symbol1);
                }
                Console.SetCursorPosition(0,Console.CursorTop+1);
                if (i != 1)
                {
                    Console.Write(symbol2);
                }
            }
        }
        Console.Clear();
        if (!winner)
        {
            Console.WriteLine("You ran out of attempts.");
            Console.WriteLine($"The correct word was: {correctWord}");
        }
        
        Console.WriteLine("Play again? Y/N");
        bool continuePlaying = false;
        if (char.ToLower(ReadChar.YesOrNo()) == 'y')
        {
            Console.Clear();
            continuePlaying = true;
        }
        else 
        {
            Console.Clear();
            Console.WriteLine("Thank you for playing!");
        }
        return continuePlaying;
    }
}