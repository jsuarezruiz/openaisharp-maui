using Microsoft.Extensions.Logging;
using OpenAISharp.Hosting;
using OpenAISharp.Maui.ViewModels;
using OpenAISharp.Maui.Views;
using OpenAISharp.Models;

namespace OpenAISharp.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseOpenAI(new OpenAIOptions
                {
                    ApiKey = "INSERT YOUR OPENAI API KEY HERE",
                    BaseUrl = "https://api.openai.com/v1/"
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<ChatViewModel>();
            builder.Services.AddSingleton<ChatView>();

            return builder.Build();
        }
    }
}