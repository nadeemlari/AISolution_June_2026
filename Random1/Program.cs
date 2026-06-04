using DotNetEnv;
using Framework;
using Microsoft.Agents.AI;
using OpenAI;

using var timer = new CodeTimer("Load Env");
Env.TraversePath().Load();

var audioClient = AI.OpenRouter.GetAudioClient("google/lyria-3-pro-preview");
// await audioClient.CreateVoiceAsync(new BinaryCo)

// OpenAIClient client = new OpenAIClient()

// Console.WriteLine(Env.GetString("MODEL"));