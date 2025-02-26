using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aurelius
{
    public class AIAssistantService
    {
        private Queue<ChatMessage> _chatHistory;

        public AIAssistantService()
        {
            _chatHistory = new Queue<ChatMessage>();
            // Add welcome message
            _chatHistory.Enqueue(new ChatMessage
            {
                Id = Guid.NewGuid().ToString(),
                Content = "Hello! I'm your Aurelius AI assistant. I can help you with market research, stock analysis, and investment insights. What would you like to know today?",
                IsUser = false,
                Timestamp = DateTime.Now
            });
        }

        public List<ChatMessage> GetChatHistory()
        {
            return new List<ChatMessage>(_chatHistory);
        }

        public async Task<ChatMessage> SendMessage(string message)
        {
            // Add user message to history
            var userMessage = new ChatMessage
            {
                Id = Guid.NewGuid().ToString(),
                Content = message,
                IsUser = true,
                Timestamp = DateTime.Now
            };
            _chatHistory.Enqueue(userMessage);

            // In a real app, this would call the AI service API
            await Task.Delay(1000); // Simulate network delay

            // Generate AI response
            var aiResponse = GenerateAIResponse(message);
            var aiMessage = new ChatMessage
            {
                Id = Guid.NewGuid().ToString(),
                Content = aiResponse,
                IsUser = false,
                Timestamp = DateTime.Now
            };
            _chatHistory.Enqueue(aiMessage);

            return aiMessage;
        }

        private string GenerateAIResponse(string query)
        {
            // Mock AI responses
            var responses = new[]
            {
                "Based on current market trends, tech stocks are showing strong momentum this quarter.",
                "The latest Fed announcement could impact financial sectors. Keep an eye on banking stocks in the coming weeks.",
                $"Recent earnings reports for {query.Replace("what do you think about ", "").ToUpper()} are above analyst expectations, showing 12% YoY growth.",
                $"From a technical analysis perspective, {query.Replace("how is ", "").ToUpper()} appears to be approaching a resistance level at $342.",
                "Market sentiment for renewable energy is currently bullish according to our analysis of recent news articles.",
                "Analyzing the last 5 years of data, similar market conditions have led to a sector rotation toward defensive stocks."
            };

            var random = new Random();
            return responses[random.Next(responses.Length)];
        }

        public void ClearChat()
        {
            _chatHistory.Clear();
            // Add welcome message again
            _chatHistory.Enqueue(new ChatMessage
            {
                Id = Guid.NewGuid().ToString(),
                Content = "Hello! I'm your Aurelius AI assistant. I can help you with market research, stock analysis, and investment insights. What would you like to know today?",
                IsUser = false,
                Timestamp = DateTime.Now
            });
        }
    }
}