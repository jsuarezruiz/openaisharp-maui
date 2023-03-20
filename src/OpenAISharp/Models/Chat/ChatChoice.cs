using System.Text.Json.Serialization;

namespace OpenAISharp.Models.Chat
{
    public class ChatChoice
    {
        [JsonPropertyName("message")]
        public ChatMessage Message { get; set; }

        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("logprobs")]
        public object Logprobs { get; set; }

        [JsonPropertyName("finish_reason")]
        public string FinishReason { get; set; }
    }
}