﻿using System.Diagnostics;

const string allPossibleCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz! ";

string possibleCharacters = allPossibleCharacters;
string soloution = "Hello World!";
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
        possibleCharacters.Replace($"{currentLetter}", "");

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
    var colourValues = Enum.GetValues(typeof(ConsoleColor));

    ConsoleColor randomColour = (ConsoleColor)colourValues.GetValue(random.Next(colourValues.Length));

    while (randomColour == Console.BackgroundColor)
    {
        randomColour = (ConsoleColor)colourValues.GetValue(random.Next(colourValues.Length));
    }

    Console.ForegroundColor = randomColour;
    Console.WriteLine(text);
    Console.ResetColor();
}

static string FormatStopWatchTime(TimeSpan elapsedTime)
{
    return elapsedTime.ToString(@"mm\:ss\.fff");
}