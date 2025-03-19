using System;

public class Journal
{
    public List<Entry> _entries;
    public PromptGenerator _promptGenerator;

    public Journal()
    {
        _entries = new List<Entry>();
        _promptGenerator = new PromptGenerator();
    }

    public void AddEntry()
    {
        string todayDate = DateTime.Now.ToString("yyyy-MM-dd");

        string prompt = _promptGenerator.GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Console.Write("How's the weather? (e.g., Sunny, Rainy, Cloudy): ");
        string weather = Console.ReadLine();

        Console.Write("How are you feeling? (e.g., Happy, Sad, Excited): ");
        string mood = Console.ReadLine();

        Console.Write("Where are you? (Leave blank if private): ");
        string location = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(response))
        {
            Console.WriteLine("Entry cannot be empty!");
            return;
        }

        _entries.Add(new Entry(prompt, response, weather, mood, location));
        Console.WriteLine("Entry added!\n");
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries found.\n");
            return;
        }

        Console.WriteLine("Journal Entries:\n");
        foreach (var entry in _entries)
        {
            Console.WriteLine($"Date: {entry._date} - Prompt: {entry._promptText}");
            Console.WriteLine($"Entry: {entry._entryText}");
            Console.WriteLine($"Weather: {entry._weather}");
            Console.WriteLine($"Mood: {entry._mood}");
            Console.WriteLine($"Location: {entry._location}\n");
        }
    }

    public void SaveToFile(string file)
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine(entry._date);
                writer.WriteLine(entry._promptText);
                writer.WriteLine(entry._entryText);
                writer.WriteLine(entry._weather);
                writer.WriteLine(entry._mood);
                writer.WriteLine(entry._location);
                writer.WriteLine("-----");
            }
        }
        Console.WriteLine("Journal saved successfully!\n");
    }

    public void LoadFromFile(string file)
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("⚠️ File not found!\n");
            return;
        }

        _entries.Clear();

        using (StreamReader reader = new StreamReader(filename))
        {
            string date,
                prompt,
                response,
                weather;
            Console.WriteLine("\nFile Contents:\n----------------------");

            while ((date = reader.ReadLine()) != null)
            {
                prompt = reader.ReadLine();
                response = reader.ReadLine();
                weather = reader.ReadLine();
                reader.ReadLine();

                Entry newEntry = new Entry(prompt, response, weather, date, "defaultTag");
                _entries.Add(newEntry);

                Console.WriteLine($"Date: {date}");
                Console.WriteLine($"Prompt: {prompt}");
                Console.WriteLine($"Entry: {response}");
                Console.WriteLine($"Weather: {weather}");
                Console.WriteLine($"Mood: {reader.ReadLine()}");
                Console.WriteLine("----------------------");
            }
        }
        Console.WriteLine("\nJournal loaded successfully!\n");
    }
}
