using OpenAISharp.Models.Chat;

namespace OpenAISharp.Services.Chat
{
    public interface IChatService
    {
        Task<ChatResponse> GetChatCompletionsAsync(ChatRequest chatRequest);
    }
}