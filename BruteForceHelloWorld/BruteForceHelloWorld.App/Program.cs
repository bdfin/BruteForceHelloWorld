using System.Diagnostics;

const string allPossibleCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz! ";

string possibleCharacters = allPossibleCharacters;
string soloution = "Hello World!";
string answer = "";
int currentLetterIndex = 0;

var random = new Random();
var stopWatch = new Stopwatch();

stopWatch.Start();

while (answer != soloution)
{
    char currentLetter = possibleCharacters[random.Next(possibleCharacters.Length)];

    if (currentLetter != soloution[currentLetterIndex])
    {
        possibleCharacters.Replace($"{currentLetter}", "");

        Console.WriteLine(answer + currentLetter);
    }
    else
    {
        var upperCaseVariant = char.ToUpperInvariant(soloution[currentLetterIndex]);

        if (currentLetter == upperCaseVariant)
        {
            currentLetter = upperCaseVariant;
        }

        possibleCharacters = allPossibleCharacters;
        answer += currentLetter;

        Console.WriteLine(Environment.NewLine);
        Console.WriteLine(answer);
        currentLetterIndex++;       
    }

    Thread.Sleep(5);
}

stopWatch.Stop();

Console.WriteLine(Environment.NewLine);
Console.WriteLine($"Time taken: {FormatStopWatchTime(stopWatch.Elapsed)}");

static string FormatStopWatchTime(TimeSpan elapsedTime)
{
    return elapsedTime.ToString(@"mm\:ss\.fff");
}