using OpenAISharp.Maui.ViewModels;

namespace OpenAISharp.Maui.Views;

public partial class ChatView : ContentPage
{
	public ChatView(ChatViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}