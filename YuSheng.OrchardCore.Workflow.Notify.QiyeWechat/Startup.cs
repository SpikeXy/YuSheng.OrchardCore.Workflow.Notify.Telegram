using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;
using OrchardCore.Workflows.Helpers;
using YuSheng.OrchardCore.Workflow.Notify.QiyeWechat.Activities;
using YuSheng.OrchardCore.Workflow.Notify.QiyeWechat.Drivers;

namespace YuSheng.OrchardCore.Workflow.Notify.QiyeWechat
{
    [Feature("OrchardCore.Workflows")]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {

            services.AddActivity<NotifyQiyeWechatTask, NotifyQiyeWechatTaskDisplayDriver>(); ;

        }
    }
}
