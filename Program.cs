using System.Runtime.ExceptionServices;

namespace hangman
{
    class Program
    {
        static void Main(string[] args)
        {

            bool reset = true;
            int? menuNumber;
            do
            {
                string[] word = { "apple", "school", "garage", "through", "storage", "github", "hungry", "watermelon" };
                Random random = new Random();
                int randomWord = random.Next(0, 8);
                string chosenWord = word[randomWord];
                string newWord = "";
                reset = true;

                char[] chosenWordArray = chosenWord.ToCharArray(0, chosenWord.Length);
                for (int x = 0; x < chosenWordArray.Length; x++)
                {
                    newWord += "*";
                }
                string[] answersArray = new string[5];
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("1. Play the game");
                Console.WriteLine("2. Quit");
                menuNumber = int.Parse(Console.ReadLine());
                
                string answer;
                int z = 0;
               
                do
                {
                    try
                    {


                        while (newWord.Contains('*') && z < 5)
                        {

                            Console.WriteLine("press any key to continue");
                            Console.ReadKey();
                            Console.Clear();
                            Console.ResetColor();
                            hangManVisual(z);
                            Console.WriteLine("here's a random word: {0}, guess a letter. The word is {1} characters long", newWord, newWord.Length);
                            Console.Write("incorrect guesses: ");
                            Console.WriteLine(string.Join(" ", answersArray));


                            answer = Console.ReadLine() ?? "";
                            string[] storedAnswer = new string[5];

                            
                            bool containsLetter = false;

                            
                            if (answer.Length == 1 && chosenWord.Contains(answer[0]))
                            {
                                char answerChar = char.Parse(answer);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("correct!");
                                for (int i = 0; i < chosenWord.Length; i++)
                                {
                                    if (chosenWord[i] == answerChar)
                                    {
                                        newWord = newWord.Remove(i, 1);
                                        newWord = newWord.Insert(i, "" + answer[0]);
                                        containsLetter = true;
                                    }
                                }

                            }
                            if (answer == chosenWord || !newWord.Contains('*'))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                newWord = newWord.Remove(0, newWord.Length);
                                newWord = newWord.Insert(0, "" + answer);
                                Console.WriteLine("congratulations! you won! the word was: {0}", chosenWord);
                                reset = false;
                            }
                            if (answer.Length > 1 && answer != chosenWord)
                            {
                                answersArray[z] = answer;

                                storedAnswer[z] = answersArray[z];
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("incorrect! You have {0} guess(es) left!", (4 - z));

                                z++;
                            }

                                if (answer.Length == 1 && !chosenWord.Contains(answer[0]))
                            {
                                answersArray[z] = answer;

                                storedAnswer[z] = answersArray[z];
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("incorrect! You have {0} guess(es) left!", (4 - z));

                                z++;
                            }

                        }

                        
                        if (z == 5)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("better luck next time!");
                            reset = false;
                        }
                    }



                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    Console.ReadKey();
                } while (reset == true);
            } while (menuNumber == 1);
                 
            static void hangManVisual(int extraLives)
            {
                switch (extraLives)
                {
                    case 0:
                        Console.WriteLine("       =======");
                        Console.WriteLine("       |     =");
                        Console.WriteLine("             =");
                        Console.WriteLine("             =");
                        Console.WriteLine("             =");
                        break;
                    case 1:
                        Console.WriteLine("       =======");
                        Console.WriteLine("       |     =");
                        Console.WriteLine("       O     =");
                        Console.WriteLine("       I     =");
                        Console.WriteLine("             =");
                        break;
                    case 2:
                        Console.WriteLine("       =======");
                        Console.WriteLine("       |     =");
                        Console.WriteLine("       O     =");
                        Console.WriteLine("       I\\    =");
                        Console.WriteLine("             =");
                        break;
                    case 3:
                        Console.WriteLine("       =======");
                        Console.WriteLine("       |     =");
                        Console.WriteLine("       O     =");
                        Console.WriteLine("      /I\\    =");
                        Console.WriteLine("             =");
                        break;
                    case 4:
                        Console.WriteLine("       =======");
                        Console.WriteLine("       |     =");
                        Console.WriteLine("       O     =");
                        Console.WriteLine("      /I\\    =");
                        Console.WriteLine("      /      =");
                        break;
                    case 5:
                        Console.WriteLine("       =======");
                        Console.WriteLine("       |     =");
                        Console.WriteLine("       O     =");
                        Console.WriteLine("      /I\\    =");
                        Console.WriteLine("      / \\    =");
                        break;

                }

            }
        }
    }
}

