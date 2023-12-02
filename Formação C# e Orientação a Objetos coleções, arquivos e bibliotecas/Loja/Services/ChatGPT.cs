using OpenAI_API;
using OpenAI_API.Chat;

namespace Services;

public class ChatGPT
{
    private static OpenAIAPI _OpenAIAPI { get; } = new OpenAIAPI("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");
    private static Conversation _Chat { get; } = _OpenAIAPI.Chat.CreateConversation();


    public static async Task<string> PerguntarChatGPT(string pergunta)
    {
        _Chat.AppendSystemMessage(pergunta);
        return await _Chat.GetResponseFromChatbotAsync();
    }
}
