using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    public static Dictionary<string, string> ReadCSV()
    {
        var dict = new Dictionary<string, string>();
        string path = Path.Combine(
            Application.streamingAssetsPath,
            "TextData.csv"
        );

        var lines = File.ReadAllLines(path);
        foreach (var line in lines)
        {
            var parts = line.Split(',');
            dict[parts[0]] = parts[1];
        }
        return dict;
    }

}
