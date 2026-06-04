using DotNetEnv;
using Framework;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using OpenAI.Chat;
using Spectre.Console;
using ChatMessage = Microsoft.Extensions.AI.ChatMessage;

// ReSharper disable ClassNeverInstantiated.Global
#pragma warning disable OPENAI001


// using var timer = new CodeTimer("Agent1");
Env.TraversePath().Load();

var aiAgent = AI.OpenRouter.GetChatClient()
    .AsAIAgent
    (
        new ChatClientAgentOptions()
        {
            Name = "Agent1",
            ChatOptions = new ChatOptions()
            {
                Instructions = "You are super helpful",
                RawRepresentationFactory = _ => new ChatCompletionOptions()
                {
                    ReasoningEffortLevel = ChatReasoningEffortLevel.Minimal
                }
            }
        }
    );

await Measure.TimeAsync(async () =>
{
    var chatMessage = new ChatMessage(ChatRole.User,
        "what are the most populated cities in the world? Respond only with NAME and TOTAL POPULATION");

    var response = await aiAgent.RunAsync<IEnumerable<LargestCity>>(chatMessage);

    foreach (var city in response.Result)
    {
        AnsiConsole.MarkupLine($"[green][bold]{city.Name}[/]-[bold]{city.Population}[/].[/]");
    }

    AnsiConsole.WriteLine();
    AnsiConsole.WriteLine();
    if (response.Usage != null) PrintUsage(response.Usage);
});



return;

void PrintUsage(UsageDetails usage)
{
    AnsiConsole.MarkupLine($"[yellow]Total Tokens Used:[/] {usage.TotalTokenCount}");
    AnsiConsole.MarkupLine($"[blue]Input Tokens Used:[/] {usage.InputTokenCount}");
    AnsiConsole.MarkupLine($"[aqua]Output Tokens Used:[/] {usage.OutputTokenCount}");
    AnsiConsole.MarkupLine($"[red]Reasoning Tokens Used:[/] {usage.ReasoningTokenCount}");
}

internal record LargestCity(string Name, decimal Population);