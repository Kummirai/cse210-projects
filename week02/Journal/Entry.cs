using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _weather;
    public string _mood;
    public string _location;

    public Entry(string promptText, string entryText, string weather, string mood, string location)
    {
        _date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        _promptText = promptText;
        _entryText = entryText;
        _weather = weather;
        _mood = mood;
        _location = location;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}\n");
        Console.WriteLine($"Weather: {_weather}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine($"Location: {_location}\n");
    }
}
