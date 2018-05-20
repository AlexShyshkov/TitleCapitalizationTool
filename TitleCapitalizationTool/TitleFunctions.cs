using System;

namespace TitleCapitalizationTool
{
    internal class TitleFunctions
    {
        private String[] wordsException = { "A", "An", "And", "At", "But", "By", "For", "In", "Nor", "Not", "Of", "On", "Or", "Out", "So", "The", "To", "Up", "Yet" };
        private Char[] signs = { ';', ':', ',', '.', '?', '!', '-' };

        private Boolean IsWordsException(String title)
        {
            Boolean IsWordsException = false;
            for(UInt16 i = 0; i < wordsException.Length; i++)
            {
                if(title == wordsException[i])
                {
                    IsWordsException = true;
                    break;
                }
            }
            return IsWordsException;
        }

        private Boolean IsSigns(Char sign)
        {
            Boolean IsSigns = false;
            for(UInt16 i = 0; i < signs.Length; i++)
            {
                if(sign == signs[i])
                {
                    IsSigns = true;
                    break;
                }
            }
            return IsSigns;
        }

        public void Capitalization()
        {
            do
            {
                Console.Write("Enter title to capitalize: ");
                Console.ForegroundColor = ConsoleColor.Red;

                String title = "";
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Enter)
                {
                    Console.Write(key.KeyChar);
                    title = key.KeyChar + Console.ReadLine();
                    title = title.ToLower();

                    for (Int16 i = 0; i < title.Length; i++)
                    {
                        if (IsSigns(title[i]))
                        {
                            --i;
                            const UInt16 ShiftIndexBeforeSign = (int)Enumeration.SymbolShiftPosition.One;
                            const UInt16 ShiftIndexAfterSign = (int)Enumeration.SymbolShiftPosition.Three;
                            const Int16 ShiftIndexAfterSpacebar = (int)Enumeration.SymbolShiftPosition.Four;
                            if (i >= -1)
                            {
                                title = title.Insert(i + ShiftIndexBeforeSign, " ");
                            }
                            title = title.Insert(i + ShiftIndexAfterSign, " ");
                            i += ShiftIndexAfterSpacebar;
                        }
                    }

                    String[] transitionalTitle = title.Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    for (UInt16 i = 0; i < transitionalTitle.Length; i++)
                    {
                        Char symbol = Char.ToUpper(transitionalTitle[i][0]);
                        transitionalTitle[i] = transitionalTitle[i].Remove(0, 1);
                        transitionalTitle[i] = transitionalTitle[i].Insert(0, new String(symbol, 1));

                        if (i != 0 && i != transitionalTitle.Length - 1 && IsWordsException(transitionalTitle[i]))
                        {
                            transitionalTitle[i] = transitionalTitle[i].ToLower();
                        }
                    }

                    if(transitionalTitle.Length > 1 && IsSigns(transitionalTitle[transitionalTitle.Length-1][0]))
                    {
                        Char symbol = Char.ToUpper(transitionalTitle[transitionalTitle.Length - 1][0]);
                        transitionalTitle[transitionalTitle.Length - 1] = transitionalTitle[transitionalTitle.Length - 1].Remove(0, 1);
                        transitionalTitle[transitionalTitle.Length - 1] = transitionalTitle[transitionalTitle.Length - 1].Insert(0, new string(symbol, 1));
                    }

                    title = String.Join(" ", transitionalTitle);

                    for (UInt16 i = 0; i < title.Length; i++)
                    {
                        if(IsSigns(title[i]) && title[i-1] == ' ' && title[i] != '-')
                        {
                            title = title.Remove(i - 1, 1);
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