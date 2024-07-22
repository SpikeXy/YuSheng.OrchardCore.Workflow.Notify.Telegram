using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using OrchardCore.Workflows.Abstractions.Models;
using OrchardCore.Workflows.Activities;
using OrchardCore.Workflows.Models;
using OrchardCore.Workflows.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using System.Text.Json;

namespace YuSheng.OrchardCore.Workflow.Notify.Telegram.Activities
{
    public class NotifyTelegramTask : TaskActivity
    {
        private readonly IWorkflowScriptEvaluator _scriptEvaluator;
        private readonly IStringLocalizer S;
        private readonly IHtmlHelper _htmlHelper;
        private readonly IWorkflowExpressionEvaluator _expressionEvaluator;
        public NotifyTelegramTask(IWorkflowScriptEvaluator scriptEvaluator,
            IWorkflowExpressionEvaluator expressionEvaluator,
            IHtmlHelper htmlHelper,
            IStringLocalizer<NotifyTelegramTask> localizer)
        {
            _scriptEvaluator = scriptEvaluator;
            _expressionEvaluator = expressionEvaluator;
            S = localizer;
            _htmlHelper = htmlHelper;

        }

        public override string Name => nameof(NotifyTelegramTask);

        public override LocalizedString DisplayText => S["Notify TelegramTask Task"];

        public override LocalizedString Category => S["Notify"];

        public WorkflowExpression<string> Token
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<string> GroupId
        {
            get => GetProperty(() => new WorkflowExpression<string>());
            set => SetProperty(value);
        }

        public WorkflowExpression<object> HtmlMessage
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

            var token = Token.Expression;
            var groupId = GroupId.Expression.ToString();
            var message = HtmlMessage.Expression;

            string code = "";
            try
            {
                var bot = new TelegramBotClient(token);
                var result = await bot.SendTextMessageAsync(groupId,                  message,
                                parseMode: ParseMode.Html,
                                protectContent: true);
                code = JsonSerializer.Serialize(result);
            }
            catch (Exception ex)
            {
                code = ex.Message;
            }

            workflowContext.Output["MessageResult"] = _htmlHelper.Raw(_htmlHelper.Encode(code)) ;

            return Outcomes("Done");
        }
    }
}
