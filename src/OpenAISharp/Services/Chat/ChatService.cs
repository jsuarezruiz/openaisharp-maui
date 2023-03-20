using Microsoft.Extensions.Options;
using OpenAISharp.Models;
using OpenAISharp.Models.Chat;

namespace OpenAISharp.Services.Chat
{
    public class ChatService : OpenAIService, IChatService
    {
        public ChatService(IOptions<OpenAIOptions> options) : base(options)
        {

        }

        public async Task<ChatResponse> GetChatCompletionsAsync(ChatRequest chatRequest)
        {
            var response = await ExecuteRequest<ChatRequest, ChatResponse>(HttpMethod.Post, "chat/completions", chatRequest);
          
            return response;
        }
    }
}