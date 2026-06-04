using System.Diagnostics;
using Spectre.Console;

namespace Framework;

public static class Measure
{
   
    public static async Task TimeAsync(Func<Task> action, string taskName = "Task..")
    {
        await AnsiConsole.Status().StartAsync($"Running [teal]{taskName.EscapeMarkup()}[/]...", async _ =>
        {
            var sw = Stopwatch.StartNew();
            await action();
            sw.Stop();
            AnsiConsole.MarkupLine($"[teal]\n{("[" + taskName + "]").EscapeMarkup()} completed in [olive]{sw.ElapsedMilliseconds} [/]ms.[/]");
        });
    }

    // // For functions that return a value
    //
    // public static T Time<T>(Func<Task<T>> func, bool showProgress = true, string taskName = "Working")
    // {
    //     if (showProgress)
    //     {
    //         Console.WriteLine("1a");
    //         return AnsiConsole.Status().StartAsync($"Running [teal]{taskName.EscapeMarkup()}[/]...", async _ =>
    //             {
    //                 var sw = Stopwatch.StartNew();
    //                 var result = await func();
    //                 sw.Stop();
    //                 AnsiConsole.MarkupLine(
    //                     $"[teal]\n{("[" + taskName + "]").EscapeMarkup()} completed in [olive]{sw.ElapsedMilliseconds} [/]ms.[/]");
    //                 return Task.FromResult(result);
    //             })
    //             .GetAwaiter().GetResult();
    //     }
    //     var sw = Stopwatch.StartNew();
    //     var result = func();
    //     sw.Stop();
    //     AnsiConsole.MarkupLine(
    //         $"[teal]\n{("[" + taskName + "]").EscapeMarkup()} completed in [olive]{sw.ElapsedMilliseconds} [/]ms.[/]");
    //     return result;
    // }
    //
    // // For asynchronous tasks
    //
    // public static async Task TimeAsync(Func<Task> action, bool showProgress = true, string taskName = "Working")
    // {
    //     if (showProgress)
    //     {
    //         Console.WriteLine("1a");
    //         AnsiConsole.Status().StartAsync($"Running [teal]{taskName.EscapeMarkup()}[/]...", _ =>
    //             {
    //                 var sw = Stopwatch.StartNew();
    //                 Console.WriteLine("1b");
    //                 return action().ContinueWith( _ =>
    //                 {
    //                     Console.WriteLine("1c");
    //                     sw.Stop();
    //                     AnsiConsole.MarkupLine(
    //                         $"[teal]\n{("[" + taskName + "]").EscapeMarkup()} completed in [olive]{sw.ElapsedMilliseconds} [/]ms.[/]");
    //                 });
    //             })
    //             .GetAwaiter().GetResult();
    //     }
    //     else
    //     {
    //         var sw = Stopwatch.StartNew();
    //         await action();
    //         sw.Stop();
    //         AnsiConsole.MarkupLine(
    //             $"[teal]\n{("[" + taskName + "]").EscapeMarkup()} completed in [olive]{sw.ElapsedMilliseconds} [/]ms.[/]");
    //     }
    //     
    // }
}