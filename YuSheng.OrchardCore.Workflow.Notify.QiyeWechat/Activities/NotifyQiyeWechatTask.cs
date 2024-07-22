using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using OrchardCore.Workflows.Abstractions.Models;
using OrchardCore.Workflows.Activities;
using OrchardCore.Workflows.Models;
using OrchardCore.Workflows.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace YuSheng.OrchardCore.Workflow.Notify.QiyeWechat.Activities
{
    public class NotifyQiyeWechatTask : TaskActivity
    {
        private readonly IWorkflowScriptEvaluator _scriptEvaluator;
        private readonly IStringLocalizer S;
        private readonly IHtmlHelper _htmlHelper;
        private readonly IWorkflowExpressionEvaluator _expressionEvaluator;
        public NotifyQiyeWechatTask(IWorkflowScriptEvaluator scriptEvaluator,
            IWorkflowExpressionEvaluator expressionEvaluator,
            IHtmlHelper htmlHelper,
            IStringLocalizer<NotifyQiyeWechatTask> localizer)
        {
            _scriptEvaluator = scriptEvaluator;
            _expressionEvaluator = expressionEvaluator;
            S = localizer;
            _htmlHelper = htmlHelper;
        }

        public override string Name => nameof(NotifyQiyeWechatTask);

        public override LocalizedString DisplayText => S["Notify QiyeWechat Task"];

        public override LocalizedString Category => S["Notify"];

        public WorkflowExpression<string> Webhook
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }


        public WorkflowExpression<object> Message
        {
            get => GetProperty(() => new WorkflowExpression<object>());
            set => SetProperty(value);
        }

        public override IEnumerable<Outcome> GetPossibleOutcomes(WorkflowExecutionContext workflowContext, ActivityContext activityContext)
        {
            return Outcomes(S["Done"]);
        }

        public override async Task<ActivityExecutionResult> ExecuteAsync(WorkflowExecutionContext workflowContext, ActivityContext activityContext)
        {
            var webhook = Webhook.Expression;
            string message_json = Message.Expression;
            var message = new StringContent(
                message_json,
                Encoding.UTF8,
                "application/json"
            );
            var code = "";
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.PostAsync(webhook, message);
                    response.EnsureSuccessStatusCode();
                    code = "Response status code: " + response.StatusCode;
                }
                catch (HttpRequestException e)
                {
                    code = e.Message;
                }
                workflowContext.Output["MessageResult"] = _htmlHelper.Raw(_htmlHelper.Encode(code));
            }

            return Outcomes("Done");
        }
    }
}
