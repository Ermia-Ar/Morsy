namespace Morsy.Common.Helper;

public static class JsonHelper
{
    public static T JsonDeserialize<T>(string json)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        
        var content = JsonSerializer.Deserialize<T>(json, options);
        return content!;
    }
}