using Newtonsoft.Json;

namespace NickelbackLIGenerator.Models;

public class SongsList
{
    [JsonProperty(PropertyName = "songs")]
    public Song[] Songs { get; set; }
}

public class Song
{
    [JsonProperty(PropertyName = "title")]
    public string title { get; set; }
    [JsonProperty(PropertyName = "lyrics")]
    public string[] lyrics { get; set; }
}