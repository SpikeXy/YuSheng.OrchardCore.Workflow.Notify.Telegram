using System.ComponentModel.DataAnnotations;

namespace YuSheng.OrchardCore.Workflow.Notify.QiyeWechat.ViewModels
{
    public class NotifyQiyeWechatTaskViewModel
    {
        [Required]
        public string Webhook { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
