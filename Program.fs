module AiToolsFsharp.Main

open Microsoft.SemanticKernel
open System
open Microsoft.SemanticKernel.ChatCompletion
open Microsoft.SemanticKernel.Connectors.OpenAI
open AiToolsFsharp.Plugins

let modelId = "qwen2.5:3b"

let kernel =
    Kernel
        .CreateBuilder()
        .AddOpenAIChatCompletion(modelId = modelId, endpoint = Uri("http://localhost:11434/v1"), apiKey = null)
        .Build()

kernel.Plugins.AddFromType<LightsPlugin>("Lights") |> ignore
kernel.Plugins.AddFromType<UtilsPlugin>("Utils") |> ignore

let chatCompletionService = kernel.GetRequiredService<IChatCompletionService>()
let chatOptions = OpenAIPromptExecutionSettings()
chatOptions.FunctionChoiceBehavior <- FunctionChoiceBehavior.Auto()

printfn "Ask your question from AI or give some instructions"
let history = ChatHistory()
let mutable userInput = String.Empty
userInput <- Console.ReadLine()

while (userInput <> "exit") do
    if not (String.IsNullOrEmpty(userInput)) then
        history.AddUserMessage(userInput)
        
        let result =
            chatCompletionService.GetChatMessageContentAsync(history, chatOptions, kernel)
            |> Async.AwaitTask
            |> Async.RunSynchronously

        history.AddMessage(
            result.Role,
            if isNull result.Content then
                String.Empty
            else
                result.Content
        )

        printfn $"AI: {result.Content}"
        userInput <- Console.ReadLine()
