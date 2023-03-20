using OpenAISharp.Models;
using OpenAISharp.Services.Chat;

namespace OpenAISharp.Hosting
{
    public static class AppHostBuilderExtensions
    {
        public static MauiAppBuilder UseOpenAI(this MauiAppBuilder builder, OpenAIOptions options)
        {
            builder.Services.AddSingleton<ChatService>();

            builder.Services.Configure<OpenAIOptions>(oaio =>
            {
                oaio.ApiKey = options.ApiKey;
                oaio.BaseUrl = options.BaseUrl;
            });

            return builder;
        }
    }
}