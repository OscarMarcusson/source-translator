if (args.Length == 0 || args[0] == "-h" || args[0] == "--help")
{
    PrintHelp();
    return 0;
}

// TODO: Check errors
var arguments = ArgsNET.Deserialize.Arguments(args).To<Data.Arguments>(out var errors);
if (errors != null)
    return Error($"Argument error: {errors.arguments[errors.index]} gave the '{errors.error}' error code");

// Validate arguments
if (!File.Exists(arguments.translations))
    return Error($"Translations file not found: {arguments.translations}");

if (arguments.input.Length == 0)
{
    if (string.IsNullOrWhiteSpace(arguments.find))
        return Error("No input given");
}
else
{
    var notFoundFiles = arguments.input
        .Where(x => !File.Exists(x))
        .ToArray();
    if (notFoundFiles.Length > 0)
    {
        if (notFoundFiles.Length == 1) return Error($"Input file not found: {notFoundFiles[0]}");
        return Error($"Input files not found:\n{string.Join("\n  ", notFoundFiles)}");
    }
}

// TODO: Append any files found via the regex search in arguments.find

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Not implemented " + arguments.translations);
Console.ResetColor();
return 1;






static int Error(string error, int code = 1)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(error);
    Console.ResetColor();
    return code;
}


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