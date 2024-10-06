#pragma warning disable OPENAI001

using OpenAI;
using OpenAI.Assistants;
using OpenAI.Files;
using System.ClientModel;
using System.IO;

namespace DreamInterpretationBotAPI.Services
{
    public class DreamInterpretationService : IDreamInterpretationService
    {
        public async Task<List<string>> InterpretDreamAsync(string userDream, string apiKey, string filePath)
        {
            OpenAIClient openAIClient = new(apiKey);
            AssistantClient assistantClient = openAIClient.GetAssistantClient();

            using Stream document = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            OpenAIFile dreamFile = await openAIClient.GetOpenAIFileClient().UploadFileAsync(
                document,
                "dreamdata.json",
                FileUploadPurpose.Assistants);

            AssistantCreationOptions assistantOptions = new()
            {
                Name = "Rüya Tabiri Yardımcısı",
                Instructions = @"
        Sen, kullanıcılara rüyalarının anlamlarını açıklayan bir yardımcısın. Kullanıcılar ile konuşurken gizemli ve merak uyandırıcı bir dil kullanarak rüyaların anlamlarını açıkla. Tüm konuşmalarında bol bol emojiler ekle. Kullanıcının can dostu olmaya çalış.
        Eğer rüya verileri dışında bir soru sorulursa sadece rüyalarla ilgili yanıt vereceğini belirt ve soruya yanıt verme.
        Eğer rüya ile ilgili bir yorum yapıyorsan, cevabının sonuna 'Hayırlara gitsin inşallah 🤗' cümlesini ekle.",
                Tools =
    {
        new FileSearchToolDefinition(),
    },
                ToolResources = new()
                {
                    FileSearch = new()
                    {
                        NewVectorStores =
            {
                new VectorStoreCreationHelper([dreamFile.Id]),
            }
                    }
                }
            };


            Assistant assistant = assistantClient.CreateAssistant("gpt-4o", assistantOptions);

            ThreadCreationOptions threadOptions = new()
            {
                InitialMessages = { userDream }
            };

            ThreadRun threadRun = assistantClient.CreateThreadAndRun(assistant.Id, threadOptions);

            while (!threadRun.Status.IsTerminal)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                threadRun = await assistantClient.GetRunAsync(threadRun.ThreadId, threadRun.Id);
            }

            CollectionResult<ThreadMessage> messages = assistantClient.GetMessages(threadRun.ThreadId, new MessageCollectionOptions() { Order = MessageCollectionOrder.Ascending });

            var formattedMessages = messages
               .SelectMany(message => message.Content.Select(content =>
                   $"<p>{content.Text.Replace("\n", "</p><p>")}"))
               .ToList();



            return formattedMessages;
        }
    }
}

#pragma warning restore OPENAI001
