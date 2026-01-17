using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public static class CSVReader
{
    public static Dictionary<string, string> ReadCSV()
    {
        var dict = new Dictionary<string, string>();

        string path = Path.Combine(
            Application.streamingAssetsPath,
            "TextData.csv"
        );

        if (!File.Exists(path))
        {
            Debug.LogError("CSV not found: " + path);
            return dict;
        }

        string content = File.ReadAllText(path, Encoding.UTF8);

        var rows = SplitRows(content);

        // Skip header
        for (int i = 1; i < rows.Count; i++)
        {
            var row = rows[i];

            int commaIndex = row.IndexOf(',');

            if (commaIndex < 0)
                continue;

            string key = row.Substring(0, commaIndex).Trim();
            string value = row.Substring(commaIndex + 1).Trim();

            // Remove surrounding quotes
            if (value.StartsWith("\"") && value.EndsWith("\""))
                value = value.Substring(1, value.Length - 2);

            dict[key] = value;
        }

        return dict;
    }

    // Handles multiline quoted rows
    private static List<string> SplitRows(string text)
    {
        var rows = new List<string>();
        var sb = new StringBuilder();

        bool inQuotes = false;

        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];

            if (c == '"')
                inQuotes = !inQuotes;

            if (c == '\n' && !inQuotes)
            {
                rows.Add(sb.ToString());
                sb.Clear();
            }
            else
            {
                sb.Append(c);
            }
        }

        if (sb.Length > 0)
            rows.Add(sb.ToString());

        return rows;
    }
}
