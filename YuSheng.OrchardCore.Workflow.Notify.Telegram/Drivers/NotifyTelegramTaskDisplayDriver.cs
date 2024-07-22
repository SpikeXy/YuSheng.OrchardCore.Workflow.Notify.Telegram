using OrchardCore.Workflows.Display;
using OrchardCore.Workflows.Models;
using YuSheng.OrchardCore.Workflow.Notify.Telegram.Activities;
using YuSheng.OrchardCore.Workflow.Notify.Telegram.ViewModels;

namespace YuSheng.OrchardCore.Workflow.Notify.Telegram.Drivers
{
    public class NotifyTelegramTaskDisplayDriver : ActivityDisplayDriver<NotifyTelegramTask, NotifyTelegramTaskViewModel>
    {
        protected override void EditActivity(NotifyTelegramTask source, NotifyTelegramTaskViewModel model)
        {
            model.Token = source.Token.ToString();
            model.GroupId = source.GroupId.ToString();
            model.HtmlMessage = source.HtmlMessage.Expression;
        }

        protected override void UpdateActivity(NotifyTelegramTaskViewModel model, NotifyTelegramTask activity)
        {
            activity.Token = new WorkflowExpression<string>(model.Token);
            activity.GroupId = new WorkflowExpression<string>(model.GroupId);
            activity.HtmlMessage = new WorkflowExpression<object>(model.HtmlMessage);
        }
    }
}
