using System;

namespace Connectfour
{
    public class Util
    {
        public static string getStringInput(string prompt, int  min, int max)
        {
            do
            {
                Console.WriteLine(prompt);
                string? input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
                    if (input.Length >= min || input.Length <= max)
                    {
                        if (input.All(Char.IsLetter))
                        {
                            return input;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Input is not with in expected length");
                    }
                }
                else
                {
                    Util.emptyInputPrompt();
                }
                continue;
            } while (true);
        }


        public static int getNumericInput(string prompt, int min, int max)
        {
            do
            {
                Console.WriteLine(prompt);

                string? input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
                    try
                    {
                        int res = int.Parse(input);
                        if (res >= min && res <= max)
                        {
                            return res;
                        }
                        else
                        {
                            Console.WriteLine("Number is not with in expected range should be from {0} to {1}", min, max);
                        }
                    } 
                    catch
                    {
                        Console.WriteLine("Please enter a valid number. ");
                    }
                }
                else
                {
                    Util.emptyInputPrompt();
                }
                continue;
            } while (true);
        }


        public static char getCharInput(string prompt, char[] expectedChars)
        {
            string charString = string.Join(", ", expectedChars);
            do
            {
                Console.WriteLine("{0}, choose from {1}", prompt, charString);

                string? input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
                    try
                    {
                        char res = char.Parse(input);
                        if (expectedChars.Contains(res))
                        {
                            return res;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid char. Expecting {0}", charString);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a valid Character.");
                    }
                }
                else
                {
                    Util.emptyInputPrompt();
                }
            } while(true);
        }

        private static void emptyInputPrompt()
        {
            Console.WriteLine("Input is empty.");
        }
    }
}