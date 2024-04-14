if (args.Length == 0 || args[0] == "-h" || args[0] == "--help")
{
    PrintHelp();
    return 0;
}

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Not implemented");
Console.ResetColor();
return 1;






static void PrintHelp()
{
    Console.WriteLine("Source Translator");
    Console.WriteLine();
    PrintArg("h", "help", "Prints this dialog");
    PrintArg("t", "translations", "The translation file");
    PrintArg("i", "input", "The comma separated input files");



    static void PrintArg(string shortArg, string longArg, string description)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"-{shortArg} ");

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("/");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($" --{longArg}");

        var remainingWhitespace = 24 - Console.CursorLeft;
        if (remainingWhitespace > 0)
            Console.Write(new string(' ', remainingWhitespace));

        Console.ResetColor();
        Console.WriteLine(description);
    }
}