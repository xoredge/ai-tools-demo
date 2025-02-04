# ai-tools-demo
Experiment with different tools model

# Model Testing Results

## Tested Models

| Name                   | ID            | Size  | Owner          | Tool Result                               |
|------------------------|---------------|-------|----------------|------------------------------------------|
| phi3:latest            | 4f2222927938  | 2.2 GB| Microsoft      | no support                               |
| deepseek-r1:1.5b       | a42b25d8c10a  | 1.1 GB| Deepseek       | no support                               |
| nemotron-mini:latest   | ed76ab18784f  | 2.7 GB| Nvidia         | poor                                     |
| hermes3:3b             | a8851c5041d4  | 2.0 GB| Nous Research  | poor                                     |
| smollm2:latest         | cef4a1e09247  | 1.8 GB| Hugging        | poor                                     |
| granite3.1-dense:2b    | fba1ad01113e  | 2.4 GB| IBM            | normal-                                  |
| mistral:latest         | f974a74358d6  | 4.1 GB| Mistral AI     | normal-                                  |
| llama3.2:1b            | baf6a787fdff  | 1.3 GB| Meta           | normal                                   |
| llama3.2:3b            | a80c4f17acd5  | 2.0 GB| Meta           | normal                                   |
| qwen2.5:0.5b           | a8b0c5157701  | 397 MB| Alibaba        | normal                                   |
| qwen2.5:3b             | 357c53fb659c  | 1.9 GB| Alibaba        | good                                     |
| qwen2.5:7b             | 845dbda0ea48  | 4.7 GB| Alibaba        | good+ but repetition in function call    |

## To Be Tested

- [Command-r7b](https://ollama.com/library/command-r7b)

# Setup Instructions

## Install .NET Core
To install .NET Core, follow the instructions provided [here](https://dotnet.microsoft.com/en-us/download).

## Install Rider
To install JetBrains Rider, follow the installation guide available [here](https://www.jetbrains.com/help/rider/Installation_guide.html).

## Install Ollama
To install Ollama, visit the download page [here](https://ollama.com/download).
