# Smart Checkers

![screenshot](logo.png)

This open-source project focuses on developing a Checkers game application with two main objectives. The first is to enable human players to compete against each other on different devices seamlessly. The second objective is to design a versatile interface for various AI-driven players, including algorithms, pre-trained neural networks, and Large Language Models (LLMs), facilitating innovative gameplay and strategy development, despite LLMs traditionally not being tailored for such applications. We're excited about exploring the intersection of classic game strategy and cutting-edge AI, and we welcome contributors interested in pushing the boundaries of what's possible in game AI.
### Demo
Current version is available under: [https://thankful-bay-00e121503.5.azurestaticapps.net/](https://thankful-bay-00e121503.5.azurestaticapps.net/)

CI/CD process deploys latest version after each commit to main branch.

Preview version is hosted on free Azure App Service Plan. It needs some time to warmup. First request may be a bit slow.
### Requirements
- .NET8 SDK
- Node.js 20.9.0+

### How to start

There are two components that need to be started separately.

#### API

Start WebAPI project by the following commands:

```
cd WebAPI
dotnet run
```
By default, WebAPI binds to localhost:5125

LLM based AI players require access to the OpenAI API for GPT-4 based player and Antrophic API for Claude 3 based player. 
You need to provide your own API keys either by setting environment variables or by providing them in the appsettings.json file.

If you don't provide API keys, LLM based AI players will be unavailable.


#### UI

Start Angular development server by the following commands:

```
cd UserInterface
npm install
npm run start
```

By default, Angular development server binds to localhost:4200, and it's connected with API running on localhost:5125.

### Available AI players

#### Random player
Random player is a simple AI player that makes random moves. It's a good starting point for developing your own AI player.

#### GPT-4 player
GPT-4 player is an AI player based on the OpenAI GPT-4 model. It uses the OpenAI GP-4 model to generate the next move.
Results are not always optimal, but it's a good example of how to use LLMs in the game.

#### Claude 3 player

Claude 3 player is an AI player based on the Antrophic Claude 3 model. It uses the Antrophic Claude 3 model to generate the next move.
Works similar to GPT-4 player. Results are a bit worse than GPT-4 player.

#### GPT-4o player

GPT-4o player is an AI player based on the OpenAI GPT-4 model. It uses the OpenAI GP-4 model to generate the next move.
It's faster than GPT-4 player, but results are not so good as GPT-4 player.

### How to write your own AI player

To write your own AI player, you need to implement the AIAlgorithm interface.

Base for AI Player implementation is AIAlgorithm interface.
    
    public interface AIAlgorithm
    {
        public Task Move(ParticipantDto participant, BoardDto board, Services services);
    }

There is only one method (Move) that needs to be implemented. It takes three parameters:
- ParticipantDto - information about the player (bot) that is making the move
- BoardDto - current board state. It contains information about the board and provides access to game log.
- Services - services that can be used by the AI player. So far there are two services available:
    - MoveClient - service that can be used to make a move. 
    - StatusPublisher - service that can be used to publish status messages to the game AI debug window

Once you implement the AIAlgorithm interface, you need to register your AI player in DI container. You can do it using one of AddAIPlayer overloads in the Startup class. 

External dependencies can be injected into the AI player using the constructor and provided by the DI container.

For simple AI player registration use:

    builder.Services.AddAiPlayer<OpenAiGpt4o>();

For more complex AI player registration use overload with implementation factory:

    builder.Services.AddAiPlayer<OpenAiGpt4o>(x =>
        new OpenAiGpt4o(x.GetRequiredService<ILogger<OpenAiGpt4o>>(), x.GetRequiredService<IOpenAIService>()));
    



### Plan

- [X] CI process
- [X] CD process
- [X] basic board API implementation
- [X] basic implementation of Man piece moves
- [ ] basic implementation of King piece moves
- [X] board UI PoC
- [X] in-memory game state storage
- [X] game log
- [ ] persistent game state storage
- [X] use SignalR for Board UI <-> Board API communication
- [X] implementation of complex Man piece moves
- [ ] implementation of complex King piece moves
- [X] game flow control (player moves)
- [X] PvP using two different devices/browsers
- [X] game lobby
- [X] interface for AI driven players
- [ ] documentation how to write your own AI player
- [ ] LLM(s) driven AI player (it may be not the best option but might be funny)
- [X] visualize conversation between BOT and LLM
- [ ] algorithm driven AI player

### Future plans

- [ ] TBD 

This project is licensed under the [MIT License](LICENSE).