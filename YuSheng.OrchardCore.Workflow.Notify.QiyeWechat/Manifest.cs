using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "YuSheng OrchardCore Workflow QiyeWechat Notify ",
    Author = "spike",
    Website = "",
    Version = "0.0.1"
)]

[assembly: Feature(
    Id = "YuSheng OrchardCore Workflow QiyeWechat Notify",
    Name = "YuSheng OrchardCore Workflow QiyeWechat Notify",
    Description = "Provides qiyewechat notify ",
    Dependencies = new[] { "OrchardCore.Workflows" },
    Category = "Workflows"
)]
