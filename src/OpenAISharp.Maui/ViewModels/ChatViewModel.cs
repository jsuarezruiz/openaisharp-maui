using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OpenAISharp.Maui.Models;
using OpenAISharp.Models.Chat;
using OpenAISharp.Services.Chat;
using System.Collections.ObjectModel;

namespace OpenAISharp.Maui.ViewModels
{
    public partial class ChatViewModel : ObservableObject
    {
        const string ChatModel = "gpt-3.5-turbo";
        const string ChatRole = "user";

        readonly ChatService _chatService;

        public ChatViewModel(ChatService chatService)
        {
            _chatService = chatService;
        }

        public ObservableCollection<Message> Messages { get; } = new();

        [ObservableProperty]
        string message;

        [ObservableProperty]
        bool isBusy;

        [RelayCommand]
        void ClearMessages()
        {
            Messages.Clear();
        }

        [RelayCommand]
        async Task SendMessage()
        {
            if (string.IsNullOrEmpty(Message))
            {
                return;
            }

            try
            {
                AddMessage(ChatRole, Message);

                IsBusy = true;

                var message = Message;
                
                Message = string.Empty;

                var chatCompletionResult = await _chatService.GetChatCompletionsAsync(new ChatRequest
                {
                    Model = ChatModel,
                    Messages = new List<ChatMessage>
                    {
                        new ChatMessage{ Role = ChatRole, Content = message }
                    }
                });

                var chatChoices = chatCompletionResult.Choices;

                if (chatChoices is not null && chatChoices.Count > 0)
                {
                    var chatMessage = chatChoices[0].Message;

                    AddMessage(chatMessage.Role, chatMessage.Content);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        void AddMessage(string role, string text)
        {
            var time = DateTime.Now.ToShortTimeString();
            Messages.Add(new Message { Role = role, Text = text, Time = time });
        }
    }
}