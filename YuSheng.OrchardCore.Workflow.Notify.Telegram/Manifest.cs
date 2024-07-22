using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "YuSheng OrchardCore Workflow Notify Telegram",
    Author = "spike",
    Website = "",
    Version = "0.0.1"
)]

[assembly: Feature(
    Id = "YuSheng OrchardCore Workflow Notify Telegram",
    Name = "YuSheng OrchardCore Workflow Notify Telegram",
    Description = "Provides Notify Telegram ",
    Dependencies = new[] { "OrchardCore.Workflows" },
    Category = "Workflows"
)]
