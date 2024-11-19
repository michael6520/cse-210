using System;

public class Journal {
    public List<Entry> Entries { get; set; }

    public Journal() {
        Entries = new List<Entry>();
    }

    public void AddEntry(Entry entry) {
        Entries.Add(entry);
    }

    public void DisplayEntries() {
        foreach (var entry in Entries) {
            entry.DisplayEntry();
        }
    }

    static string EscapeCsvField(string field) {
        if (field.Contains(",") || field.Contains("\"") || field.Contains("\n")) {
            field = field.Replace("\"", "\"\"");
            field = $"\"{field}\"";
        }
        return field;
    }

    public void SaveJournalToCsv(string filename) {
        using (var writer = new StreamWriter(filename)) {
            foreach (var entry in Entries) {
                writer.WriteLine($"{EscapeCsvField(entry.Date.ToString("MM/dd/yyyy"))}," +
                                 $"{EscapeCsvField(entry.Prompt)}," + 
                                 $"{EscapeCsvField(entry.Content)}");
            }
        }
    }

    static string[] ParseCsvLine(string line) {
        var fields = new List<string>();
        bool inside_quotes = false;
        string current_field = "";
        
        foreach (char c in line) {
            if (c == '"' && !inside_quotes) {
                inside_quotes = true;
            }
            else if (c == '"' && inside_quotes) {
                inside_quotes = !inside_quotes;
            }
            else if (c == ',' && !inside_quotes) {
                fields.Add(current_field);
                current_field = "";
            }
            else {
                current_field += c;
            }
        }
        fields.Add(current_field);
        return fields.ToArray();
    }

    public void LoadJournalFromCsv(string filename) {
        Entries.Clear();
        using (var reader = new StreamReader(filename)) {
            while (!reader.EndOfStream) {
                string line = reader.ReadLine();
                string[] fields = ParseCsvLine(line);
                var entry = new Entry {
                    Date = DateTime.Parse(fields[0]),
                    Prompt = fields[1],
                    Content = fields[2]
                };
                Entries.Add(entry);
            }
        }
    }
}