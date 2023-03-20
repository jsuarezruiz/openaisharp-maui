using Android.App;
using Android.Runtime;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;

namespace OpenAISharp.Maui
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp()
        { 
            // Remove Entry control underline
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("RemoveEntryUnderline", (h, v) =>
            {
                h.PlatformView.BackgroundTintList =
                    Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
            });

            return MauiProgram.CreateMauiApp();
        }
    }
}