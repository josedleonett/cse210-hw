public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void WriteEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (Entry entry in _entries)
        {
            entry.DisplayEntry();
        }
    }

    public void SaveJournal(string filename)
    {
        using (var writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry._date},{entry._prompt},{entry._response}");
            }
        }
    }

    public void LoadJournal(string filename)
    {
        if
        (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        using (var reader = new StreamReader(filename))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(',');

                Entry entry = new Entry();
                entry._date = DateTime.Parse(values[0]);
                entry._prompt = values[1];
                entry._response = values[2];

                _entries.Add(entry);
            }
        }
    }
}