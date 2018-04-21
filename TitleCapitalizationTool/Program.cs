using System;

namespace TitleCapitalizationTool
{
    class Program
    {
        static void Main()
        {
            do
            {
                Console.Write("Enter title to capitalize: ");
                Console.ForegroundColor = ConsoleColor.Red;
                String title;

                if (Console.ReadKey(true).Key != ConsoleKey.Enter)
                {
                    title = Console.ReadLine();
                    title = title.ToLower();
                    String[] title1 = title.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    String[] wordsException = { "a", "an", "at", "and", "by", "but", "for", "in", "nor", "of", "on", "or", "out", "so", "to", "the", "up", "yet" };
                    for (UInt16 i = 0; i < title1.Length; i++)
                    {
                        Char ch = Char.ToUpper(title1[i][0]);
                        title1[i] = title1[i].Remove(0, 1);
                        title1[i] = title1[i].Insert(0, new string(ch, 1));

                        if (i != 0 && i != title1.Length - 1)
                        {
                            for (UInt16 j = 0; j < wordsException.Length; j++)
                            {
                                if (title1[i] == wordsException[j])
                                {
                                    title1[i] = title1[i].ToLower();
                                    break;
                                }
                            }
                        }
                    }
                    title = String.Join(" ", title1);

                    for (UInt16 i = 1; i < title.Length; i++)
                    {
                        if ((title[i] == ';' || title[i] == '.' || title[i] == ',' || title[i] == '!' || title[i] == '?' || title[i] == ':') && title[i - 1] == ' ')
                        {
                            title = title.Remove(i - 1, 1);
                        }
                    }
                    for (UInt16 i = 0; i < title.Length - 1; i++)
                    {
                        if ((title[i] == ';' || title[i] == '.' || title[i] == ',' || title[i] == '!' || title[i] == '?' || title[i] == ':') && title[i + 1] != ' ')
                        {
                            title = title.Insert(i + 1, " ");
                        }
                    }
                    Console.ResetColor();
                    Console.Write("Capitalized title: ");
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine(title);
                    Console.WriteLine();
                }
                Console.ResetColor();

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
