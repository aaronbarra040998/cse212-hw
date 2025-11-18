using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var pairs = new List<string>();
        
        foreach (var word in words)
        {
            if (word[0] == word[1]) continue;
            
            var reversed = new string(new[] { word[1], word[0] });
            
            if (seen.Contains(reversed))
            {
                pairs.Add($"{word} & {reversed}");
            }
            
            seen.Add(word);
        }
        
        return pairs.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            var degree = fields[3];
            
            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
        }
        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        var w1 = word1.Replace(" ", "").ToLower();
        var w2 = word2.Replace(" ", "").ToLower();
        
        if (w1.Length != w2.Length) return false;
        
        var charCounts = new Dictionary<char, int>();
        
        foreach (var c in w1)
        {
            charCounts[c] = charCounts.GetValueOrDefault(c, 0) + 1;
        }
        
        foreach (var c in w2)
        {
            if (!charCounts.ContainsKey(c) || --charCounts[c] < 0)
            {
                return false;
            }
        }
        
        return true;
    }

    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);
        var result = new List<string>();
        
        foreach (var feature in featureCollection.Features)
        {
            if (feature.Properties?.Place != null && feature.Properties.Mag.HasValue)
            {
                result.Add($"{feature.Properties.Place} - Mag {feature.Properties.Mag.Value}");
            }
        }
        
        return result.ToArray();
    }
}