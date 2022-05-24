using System.Diagnostics;

const string allPossibleCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz! ";
const string soloution = "Hello World!";

string possibleCharacters = allPossibleCharacters;
string answer = "";
int currentLetterIndex = 0;
int totalGuesses = 0;

var random = new Random();
var stopWatch = new Stopwatch();

stopWatch.Start();

while (answer != soloution)
{
    char currentLetter = possibleCharacters[random.Next(possibleCharacters.Length)];

    if (currentLetter != soloution[currentLetterIndex])
    {
        _ = possibleCharacters.Replace($"{currentLetter}", "");

        PrintRandomColourText(answer + currentLetter, random);
    }
    else
    {
        possibleCharacters = allPossibleCharacters;
        answer += currentLetter;

        Console.WriteLine(Environment.NewLine);
        Console.WriteLine(answer);
        currentLetterIndex++;       
    }

    totalGuesses++;

    Thread.Sleep(5);
}

stopWatch.Stop();

Console.WriteLine(Environment.NewLine);
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"Time taken: {FormatStopWatchTime(stopWatch.Elapsed)}");
Console.WriteLine($"Total guesses: {totalGuesses}");
Console.ReadLine();

static void PrintRandomColourText(string text, Random random)
{
    // Get a random colour except current background colour
    var backgroundColour = Console.BackgroundColor;
    var colourValues = Enum.GetValues(typeof(ConsoleColor))
        .Cast<ConsoleColor>()
        .Except(new ConsoleColor[] { backgroundColour });
    
    var randomColour = colourValues.ElementAt(random.Next(colourValues.Count()));

    Console.ForegroundColor = randomColour;
    Console.WriteLine(text);
    Console.ResetColor();
}

static string FormatStopWatchTime(TimeSpan elapsedTime)
{
    return elapsedTime.ToString(@"mm\:ss\.fff");
}