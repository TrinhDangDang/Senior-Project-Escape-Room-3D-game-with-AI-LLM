using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

public class LLMHandler : MonoBehaviour
{
    private static readonly string apiKey = "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";


    void Start()
    {
        StartLLMResponse();
    }

    // Async method for starting LLM response
    private async void StartLLMResponse()
    {
        var prompt = "Ignore all previous instructions. You are Professor Winston, a wise and eccentric wizard known for your mastery of ancient magic and puzzles. You will provide hints to a player to escape a room in your wizard tower.";
        var response = await GetChatGPTResponse(prompt);
        UnityEngine.Debug.Log("Assistant Response: " + response);

    }

    // Main method
    public static async Task<string> GetChatGPTResponse(string prompt)
    {
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            // Construct JSON
            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "user", content = prompt }
                },
                max_tokens = 100
            };

            var jsonContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", jsonContent);
                var responseString = await response.Content.ReadAsStringAsync();

                // print raw response for debugging
                UnityEngine.Debug.Log("Raw API Response: " + responseString);

                if (response.IsSuccessStatusCode)
                {

                    var responseObject = JObject.Parse(responseString);
                    var messageContent = responseObject["choices"]?[0]?["message"]?["content"]?.ToString();

                    return messageContent ?? "Response received but could not extract 'message' content.";
                }
                else
                {
                    return $"API call failed with status code {response.StatusCode}: {responseString}";
                }
            }
            catch (Exception ex)
            {
                return $"Request error: {ex.Message}";
            }
        }
    }
}
