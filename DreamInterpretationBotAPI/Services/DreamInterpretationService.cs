#pragma warning disable OPENAI001

using OpenAI;
using OpenAI.Assistants;
using OpenAI.Files;
using System.ClientModel;
using System.IO;

namespace DreamInterpretationBotAPI.Services
{
    public class DreamInterpretationService
    {
        public async Task<List<string>> InterpretDreamAsync(string userDream, string apiKey, string filePath)
        {
            if (string.IsNullOrWhiteSpace(userDream))
            {
                throw new ArgumentException("Rüya metni boş olamaz.");
            }

            if (string.IsNullOrEmpty(apiKey))
            {
                throw new InvalidOperationException("API key bulunamadı.");
            }

            // OpenAI istemcilerini başlat
            OpenAIClient openAIClient = new(apiKey);
            AssistantClient assistantClient = openAIClient.GetAssistantClient();

            // Dosyayı yükle
            using Stream document = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            OpenAIFile dreamFile = await openAIClient.GetOpenAIFileClient().UploadFileAsync(
                document,
                "dreamdata.json",
                FileUploadPurpose.Assistants);

            // Yardımcı oluşturma seçenekleri
            AssistantCreationOptions assistantOptions = new()
            {
                Name = "Rüya Tabiri Yardımcısı",
                Instructions = @"
        Sen, kullanıcılara rüyalarının anlamlarını açıklayan bir yardımcısın. 
        Rüya verileri dışında bir soru sorulursa sadece rüyalarla ilgili yanıt vereceğini belirt ve soruya yanıt verme.
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


            // Asistanı oluştur
            Assistant assistant = assistantClient.CreateAssistant("gpt-4o", assistantOptions);

            // Kullanıcı sorusunu assistant ile işleme alalım
            ThreadCreationOptions threadOptions = new()
            {
                InitialMessages = { userDream }
            };

            ThreadRun threadRun = assistantClient.CreateThreadAndRun(assistant.Id, threadOptions);

            // Yardımcı tamamlanana kadar bekle
            while (!threadRun.Status.IsTerminal)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                threadRun = await assistantClient.GetRunAsync(threadRun.ThreadId, threadRun.Id);
            }

            // Mesajları al
            CollectionResult<ThreadMessage> messages = assistantClient.GetMessages(threadRun.ThreadId, new MessageCollectionOptions() { Order = MessageCollectionOrder.Ascending });

            // Yanıtları HTML formatında döndür (her cümleyi <p> içinde gönderelim)
            var formattedMessages = messages
               .SelectMany(message => message.Content.Select(content =>
                   $"<p>{content.Text.Replace("\n", "</p><p>")}"))
               .ToList();



            return formattedMessages;
        }
    }
}

#pragma warning restore OPENAI001
