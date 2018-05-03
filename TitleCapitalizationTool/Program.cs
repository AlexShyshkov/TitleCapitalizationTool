using System;

namespace TitleCapitalizationTool
{
    internal class Program
    {
        private static void Main()
        {
            do
            {
                Console.Write("Enter title to capitalize: ");
                Console.ForegroundColor = ConsoleColor.Red;

                String title="";
                ConsoleKeyInfo key = Console.ReadKey(true);
                                
                if (key.Key!=ConsoleKey.Enter)
                {
                    Console.Write(key.KeyChar);
                    title = key.KeyChar + Console.ReadLine();
                    title = title.ToLower();
                    String[] transitionalTitle = title.Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    String[] wordsException = { "A", "An", "And", "At", "But", "By", "For", "In", "Nor", "Not", "Of", "On", "Or", "Out", "So", "The", "To", "Up", "Yet"};
                    Char[] signs = { ';', ':', ',', '.', '?', '!' };
                    for (UInt16 i = 0; i < transitionalTitle.Length; i++)
                    {
                        Char symbol = Char.ToUpper(transitionalTitle[i][0]);
                        transitionalTitle[i] = transitionalTitle[i].Remove(0, 1);
                        transitionalTitle[i] = transitionalTitle[i].Insert(0, new String(symbol, 1));

                        if (i != 0 && i != transitionalTitle.Length - 1)
                        {
                            for (UInt16 j = 0; j < wordsException.Length; j++)
                            {
                                if (transitionalTitle[i] == wordsException[j])
                                {
                                    transitionalTitle[i] = transitionalTitle[i].ToLower();
                                    break;
                                }
                            }
                        }
                    }
                    title = String.Join(" ", transitionalTitle);

                    for (UInt16 j = 0; j < signs.Length; j++)
                    {
                        for (UInt16 i = 1; i < title.Length; i++)
                        {
                            if ((title[i] == signs[j]) && title[i - 1] == ' ')
                            {
                                title = title.Remove(i - 1, 1);
                            }
                        }
                        for (UInt16 i = 0; i < title.Length - 1; i++)
                        {
                            if ((title[i] == signs[j]) && title[i + 1] != ' ')
                            {
                                title = title.Insert(i + 1, " ");
                            }
                        }
                    }
                    Console.ResetColor();
                    Console.Write("Capitalized title: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(title);
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("\r");
                }
                Console.ResetColor();
            } while (true); 
        }
    }
}