using System.ComponentModel.DataAnnotations;

namespace YuSheng.OrchardCore.Workflow.Notify.Telegram.ViewModels
{
    public class NotifyTelegramTaskViewModel
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public string GroupId { get; set; }

        [Required]
        public string HtmlMessage { get; set; }
    }
}
