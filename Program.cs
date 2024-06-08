using Azure;
using System;
using Azure.AI.TextAnalytics;

namespace LanguageDetectionExample
{
    class Program
    {
        private static readonly AzureKeyCredential credentials = new AzureKeyCredential("INSERT_KEY_HERE");
        private static readonly Uri endpoint = new Uri("INSERT_ENDPOINT_HERE");

        // Example method for detecting the language of text
        static void LanguageDetectionMulti(TextAnalyticsClient client)
        {
            var documents = new List<string> {@"Ce document est rédigé en Français.",
                @"The hotel has some great staff but the location is not in a good neighborhood.",
                @"Selamat pagi. Mau makan untuk sarapan?",
                @"Hola, buenos dias. Me gustaria una tortilla de patata y dos cafes con leche."
            };

            // Printing key phrases

            foreach (string document in documents)
            {
                var response = client.DetectLanguage(document);

                Console.WriteLine($"Language: {response.Value.Name},\tISO-6391: {response.Value.Iso6391Name}");
            }

        }

        static void LanguageDetectionSingle(TextAnalyticsClient client)
        {
            var response = client.DetectLanguage(@"Ce document est rédigé en Français.
            The hotel has some great staff but the location is not in a good neighborhood.");
            Console.WriteLine($"Language: {response.Value.Name},\tISO-6391: {response.Value.Iso6391Name}");
        }

        static void Main(string[] args)
        {
            var client = new TextAnalyticsClient(endpoint, credentials);
            //LanguageDetectionMulti(client);

            LanguageDetectionSingle(client);

            Console.Write("Press any key to exit.");
            Console.ReadKey();
        }

    }
}