using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> prompts;

    public PromptGenerator()
    {
        prompts = new List<string>
        {
            "What was the best part of your day?",
            "What was the worst part of your day?",
            "What did you eat today?",
            "What did you do today?",
            "Did you have fun today?",
            "What did you learn today?",
            "Were you productive today?",
            "What are you grateful for today?",
            "Who was the most interesting person you interacted with today?",
            "Who was the least interesting person you interacted with today?",
            "Did you excited today?",
            "Did you play games today?",
            "Did you go outside today?",
        };
    }


    public string GetRandomPrompt()
    {
        var random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}