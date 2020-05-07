using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MVCLab
{
    class Utilities
    {
        public static void DisplayColoredByWord(string text, List<ConsoleColor> colors)
        {
            string[] splitText = text.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int currentColor = 0;
            foreach(string s in splitText)
            {
                Console.ForegroundColor = colors[currentColor];
                Console.Write(s + (s.EndsWith('\n') ? "" : " "));
                currentColor++;
                if (currentColor >= colors.Count)
                {
                    currentColor = 0;
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        public static int GetIntInputAdjusted(string prompt, int max = int.MaxValue)
        {
            while (true)
            {
                Console.Write(prompt);
                if (max != int.MaxValue)
                {
                    Console.Write($" (1-{max})");
                }
                Console.Write(": ");
                try
                {
                    int input = int.Parse(Console.ReadLine());
                    if (input > max || input < 1)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    return input - 1;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine($"That is not a valid number. Please enter a number 1-{max}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("That is not a number. Please try again.");
                }
            }
        }

        /// <summary>
        /// Get a string input from the user
        /// </summary>
        /// <param name="prompt">The prompt to display to the user</param>
        /// <returns>A non-empty string inputted by the user</returns>
        public static string GetUserInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine().Trim();
                if (input == string.Empty)
                {
                    Console.WriteLine("Input cannot be empty!");
                }
                else
                {
                    return input;
                }
            }
        }

        /// <summary>
        /// Get a yes or no from the user
        /// </summary>
        /// <param name="prompt">The prompt to display to the user</param>
        /// <returns>True if input was a partial match for "yes", or false if it was a partial match for 'no'.</returns>
        public static bool GetYesNoInput(string prompt)
        {
            while (true)
            {
                string input = GetUserInput(prompt).Trim();
                if (Regex.IsMatch(input, @"^[Yy][Ee]?[Ss]?$"))
                {
                    return true;
                }
                else if (Regex.IsMatch(input, @"^[Nn][Oo]?$"))
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please input either y(es) or n(o) (case insensitive).");
                }
            }
        }
    }
}
