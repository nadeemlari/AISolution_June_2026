using System.ClientModel;
using DotNetEnv;
using OpenAI;
using OpenAI.Audio;
using OpenAI.Chat;

namespace Framework;
// ReSharper disable once InconsistentNaming
public abstract class AI
{
    // ReSharper disable once InconsistentNaming
    public abstract class OpenAI
    {
        
        public static OpenAIClient GetClient()
        {
            var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY") ?? "";
            return new OpenAIClient(apiKey);
        }

        public static ChatClient GetChatClient(string model)
        {
            var client = GetClient();
            return client.GetChatClient(model);
        }
    }
    public abstract class OpenRouter
    {
        
        private const string Endpoint = "https://openrouter.ai/api/v1";
        public static OpenAIClient GetClient()
        {
            var apiKey = Env.GetString("OPENROUTER_API_KEY");
            return new OpenAIClient(new ApiKeyCredential(apiKey), new OpenAIClientOptions
            {
                Endpoint = new Uri(Endpoint)
            });
        }
        public static ChatClient GetChatClient(string model="inclusionai/ling-2.6-flash")
        {
            var client = GetClient();
            return client.GetChatClient(model);
        }

        public static AudioClient GetAudioClient(string model)
        {
            var client = GetClient();
            return client.GetAudioClient(model);
        }
    }
    
    public abstract class Nvidia {
        
        private const string Endpoint = "https://integrate.api.nvidia.com/v1";
        public static OpenAIClient GetClient()
        {
            var apiKey = Env.GetString("NVIDIA_API_KEY") ?? "";
            return new OpenAIClient(new ApiKeyCredential(apiKey), new OpenAIClientOptions
            {
                Endpoint = new Uri(Endpoint)
            });
        }
        public static ChatClient GetChatClient(string model)
        {
            var client = GetClient();
            return client.GetChatClient(model);
        }
        public static AudioClient GetAudioClient(string model)
        {
            var client = GetClient();
            return client.GetAudioClient(model);
        }
    }
    
    public abstract class HuggingFace {
        
        private const string Endpoint = "https://router.huggingface.co/v1";
        public static OpenAIClient GetClient()
        {
            var apiKey = Env.GetString("HUGGINGFACE_API_KEY") ?? "";
            return new OpenAIClient(new ApiKeyCredential(apiKey), new OpenAIClientOptions
            {
                Endpoint = new Uri(Endpoint)
            });
        }
        public static ChatClient GetChatClient(string model="inclusionAI/Ling-2.6-1T:novita")
        {
            var client = GetClient();
            return client.GetChatClient(model);
        }
    }
}