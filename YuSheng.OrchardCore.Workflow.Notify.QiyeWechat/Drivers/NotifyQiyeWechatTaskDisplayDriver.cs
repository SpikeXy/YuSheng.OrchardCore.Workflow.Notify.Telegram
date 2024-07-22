using OrchardCore.Workflows.Display;
using OrchardCore.Workflows.Models;
using YuSheng.OrchardCore.Workflow.Notify.QiyeWechat.Activities;
using YuSheng.OrchardCore.Workflow.Notify.QiyeWechat.ViewModels;

namespace YuSheng.OrchardCore.Workflow.Notify.QiyeWechat.Drivers
{
    public class NotifyQiyeWechatTaskDisplayDriver : ActivityDisplayDriver<NotifyQiyeWechatTask, NotifyQiyeWechatTaskViewModel>
    {
        protected override void EditActivity(NotifyQiyeWechatTask source, NotifyQiyeWechatTaskViewModel model)
        {
            model.Webhook = source.Webhook.ToString();
            model.Message = source.Message.Expression;
        }

        protected override void UpdateActivity(NotifyQiyeWechatTaskViewModel model, NotifyQiyeWechatTask activity)
        {
            activity.Webhook = new WorkflowExpression<string>(model.Webhook);
            activity.Message = new WorkflowExpression<object>(model.Message);
        }
    }
}
