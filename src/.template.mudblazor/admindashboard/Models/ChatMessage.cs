
//#if (IsHosted)
namespace MudBlazor.Template.Client.Shared
//#else
namespace MudBlazor.Template.Shared
//#endif
{
    public class ChatMessage
    {
        public string UserName { get; set; }
        public string Message { get; set; }
    }
}
