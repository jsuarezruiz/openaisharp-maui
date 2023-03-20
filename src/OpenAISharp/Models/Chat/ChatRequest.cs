using System.Text.Json.Serialization;

namespace OpenAISharp.Models.Chat
{
    public class ChatRequest
    {
        [JsonPropertyName("model")]
        public string Model { get; set; }


        [JsonPropertyName("messages")]
        public List<ChatMessage> Messages { get; set; }


        [JsonPropertyName("temperature")]
        public double? Temperatue { get; set; }


        [JsonPropertyName("top_p")]
        public double? TopP { get; set; }


        [JsonPropertyName("n")]
        public int? N { get; set; }


        [JsonPropertyName("stream")]
        public bool? Stream { get; set; }


        [JsonPropertyName("stop")]
        public string Stop { get; set; }


        [JsonPropertyName("max_tokens")]
        public int? MaxTokens { get; set; }


        [JsonPropertyName("presence_penalty")]
        public double? PresencePenalty { get; set; }


        [JsonPropertyName("frequency_penalty")]
        public double? FrequencyPenalty { get; set; }


        [JsonPropertyName("logit_bias")]
        public Dictionary<string, float> LogitBias { get; set; }


        [JsonPropertyName("user")]
        public string User { get; set; }
    }
}