using System.Text.Json.Serialization;

namespace DomainLayer.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Role
    {
        
        VIEWER, AUTHOR
    }
}
