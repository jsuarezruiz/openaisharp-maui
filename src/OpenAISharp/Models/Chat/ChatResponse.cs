using System.Text.Json.Serialization;

namespace OpenAISharp.Models.Chat
{
    public class ChatResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("object")]
        public string Object { get; set; }

        [JsonPropertyName("created")]
        public long Created { get; set; }

        [JsonPropertyName("choices")]
        public List<ChatChoice> Choices { get; set; }

        [JsonPropertyName("usage")]
        public ModelUsage Usage { get; set; }
    }
}