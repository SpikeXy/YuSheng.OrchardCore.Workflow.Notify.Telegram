using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;
using OrchardCore.Workflows.Helpers;
using YuSheng.OrchardCore.Workflow.Notify.Telegram.Activities;
using YuSheng.OrchardCore.Workflow.Notify.Telegram.Drivers;

namespace YuSheng.OrchardCore.Workflow.Notify.Telegram
{
    [Feature("OrchardCore.Workflows")]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {

            services.AddActivity<NotifyTelegramTask, NotifyTelegramTaskDisplayDriver>(); ;


        }
    }
}
