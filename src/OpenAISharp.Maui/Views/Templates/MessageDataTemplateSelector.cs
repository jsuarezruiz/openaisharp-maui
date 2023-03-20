using OpenAISharp.Maui.Models;

namespace OpenAISharp.Maui.Views.Templates
{
    internal class MessageDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SenderMessageTemplate { get; set; }
        public DataTemplate ReceiverMessageTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var message = (Message)item;

            if (message.Role.Equals("user", StringComparison.CurrentCultureIgnoreCase))
                return SenderMessageTemplate;

            return ReceiverMessageTemplate;
        }
    }
}