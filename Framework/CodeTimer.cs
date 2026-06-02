using System.Diagnostics;
using Spectre.Console;

namespace Framework;

public class CodeTimer(string taskName = "Task") : IDisposable
{
    private readonly Stopwatch _stopwatch = Stopwatch.StartNew();

    public void Dispose()
    {
        _stopwatch.Stop();

        AnsiConsole.MarkupLine(
            $"[teal]\n{("[" + taskName + "]").EscapeMarkup()} completed in [olive]{_stopwatch.ElapsedMilliseconds} [/]ms.[/]");
    }
}