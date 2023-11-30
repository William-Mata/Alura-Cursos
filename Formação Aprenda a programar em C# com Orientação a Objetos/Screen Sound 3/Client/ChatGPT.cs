using OpenAI_API;
using OpenAI_API.Chat;

namespace Screen_Sound_3.Client
{
    public class ChatGPT
    {
        private static OpenAIAPI OpenAIChatGPT { get; } = new OpenAIAPI("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");
        private static Conversation chatGPT { get; } = OpenAIChatGPT.Chat.CreateConversation();


        public static async Task<string> PerguntarChatGPTAsync(string pergunta)
        {
            chatGPT.AppendSystemMessage(pergunta);
            return await chatGPT.GetResponseFromChatbotAsync();
        }

    }
}
