using System.Text.RegularExpressions;

namespace Inlämningsuppgift_Hangman;

public static class ReadChar
{
    public static char Char()
    {
        string input_pattern = @"^[a-öA-Ö]$";
        string final_pattern = @"^([a-öA-Ö]){1}$";
        return Read(final_pattern, input_pattern);
    }
    public static char YesOrNo()
    {
        string input_pattern = @"^[yYnN]$";
        string final_pattern = @"^([yYnN]){1}$";
        return Read(final_pattern, input_pattern);
    }
    private static char Read(string final_pattern, string input_pattern)
    {
        string text = string.Empty;
        for (;;)
        {
            var k = Console.ReadKey(true);

            if (k.Key == ConsoleKey.Enter)
            {
                if (!Regex.IsMatch(text, final_pattern))
                {
                    Console.Beep();
                    continue;
                }
                else
                {
                    Console.WriteLine();
                    break;
                }
            }

            //If Backspace is pressed
            if (k.Key == ConsoleKey.Backspace)
            {
                if (text.Length == 0)
                {
                    Console.Beep();
                }
                else
                {
                    //Deletes 1 char from the inputted text and moves the cursor back 1 step to the left on the current row.
                    text = text.Substring(0, text.Length - 1);
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write($" {text}");
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                }

                continue;
            }

            //If non-character pressed.
            if (k.KeyChar == 0)
            {
                Console.Beep();
                continue;
            }

            //Only one character allowed.
            if (text.Length > 0)
            {
                Console.Beep();
                continue;
            }

            // Character pressed.
            string new_text = text + k.KeyChar;

            //Checks if input key matches allowed characters.
            if (!Regex.IsMatch(new_text, input_pattern))
            {
                Console.Beep();
            }
            else
            {
                Console.Write(k.KeyChar);
                text = new_text;
            }
        }

        return text[0];
    }
}