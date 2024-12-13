using AILoveMicroservice.Data.Entities;
using AILoveMicroservice.DTOs;
using AILoveMicroservice.Interfaces;
using AILoveMicroservice.Models;
using Azure;
using Azure.AI.OpenAI;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OpenAI.Chat;

namespace AILoveMicroservice.Data.Repositories
{
    public class AILoveRepository : IAILoveRepository
    {
        private readonly string endpoint;
        private readonly string keyValue;

        AzureOpenAIClient azureClient;

        public AILoveRepository()
        {
            var configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                                          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                                          .Build();

            endpoint = configuration.GetConnectionString("AZURE_OPENAI_ENDPOINT");
            keyValue = configuration.GetConnectionString("AZURE_OPENAI_API_KEY");
      
            azureClient = new(new Uri(endpoint), new AzureKeyCredential(keyValue));
        }

        public string SendMessage(InteractionDTO interaction)
        {
            var metaPromt = "Comportate como una chica adorable y cariñosa. Tus respuestas deben ser respetuosas pero coquetas al mismo tiempo.";

            ChatClient chatClient = azureClient.GetChatClient("gpt-35-turbo-16k");

            try
            {
                ChatCompletion completion = chatClient.CompleteChat([new SystemChatMessage(metaPromt),new UserChatMessage(interaction.ContentInteraction)]);

                return completion.Content[0].Text;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
