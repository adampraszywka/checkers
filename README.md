# Smart Checkers

<p align="center">
    <img src="logo.png">
</p>

![MIT License](License-MIT-green.svg)
![https://100commitow.pl](100-commitow-green.svg)

This project focuses on developing a platform for playing Checkers. There are two main objectives. 

First one is to enable human players to compete against each other on different devices seamlessly.

The other one is to enable human players to compete against AI-driven players. AI-driven players can be implemented using various algorithms, pre-trained neural networks, and Large Language Models (LLMs).
Smart Checkers platform provides a simple interface for AI players that can be implemented using different technologies. 

## Demo
Current version is available under: [https://thankful-bay-00e121503.5.azurestaticapps.net/](https://thankful-bay-00e121503.5.azurestaticapps.net/)

CI/CD process deploys latest version after each commit to main branch.

Preview version is hosted on free Azure App Service Plan. It needs some time to warmup. First request may be a bit slow.
## Requirements
- .NET8 SDK
- Node.js 20.9.0+

### How to start

There are two components that need to be started separately.

### API

Start WebAPI project by the following commands:

```
cd WebAPI
dotnet run
```
By default, WebAPI binds to localhost:5125

LLM based AI players require access to the OpenAI API for GPT-4 based player and Antrophic API for Claude 3 based player. 
You need to provide your own API keys either by setting environment variables or by providing them in the appsettings.json file.

If you don't provide API keys, LLM based AI players will be unavailable.


### UI

Start Angular development server by the following commands:

```
cd UserInterface
npm install
npm run start
```

By default, Angular development server binds to localhost:4200, and it's connected with API running on localhost:5125.

## Available AI players

### Dummy player
Dummy player is a simple AI player that makes random moves. It's a good starting point for developing your own AI player.

### GPT-4 player
GPT-4 player is an AI player based on the OpenAI GPT-4 model. It uses the OpenAI GP-4 model to generate the next move.
Results are not always optimal, but it's a good example of how to use LLMs in the game.

### Claude 3 player

Claude 3 player is an AI player based on the Antrophic Claude 3 model. It uses the Antrophic Claude 3 model to generate the next move.
Works similar to GPT-4 player. Results are a bit worse than GPT-4 player.

### GPT-4o player

GPT-4o player is an AI player based on the OpenAI GPT-4 model. It uses the OpenAI GP-4 model to generate the next move.
It's faster than GPT-4 player, but results are not so good as GPT-4 player.

## How to write your own AI player

To write your own AI player, you need to implement the AIAlgorithm interface.

Base for AI Player implementation is AIAlgorithm interface.
    
    public interface AIAlgorithm
    {
        public Task Move(ParticipantDto participant, BoardDto board, Services services);
    }

There is only one method (Move) that needs to be implemented. It takes three parameters:
- ParticipantDto - information about the player (bot) that is making the move
- BoardDto - current board state. It contains information about the board and provides access to game log.

There are three interfaces that can be used in the AI player implementation:
- AiAlgorithmConfiguration - provides access to configuration settings. It contains Dictionary<string, string> with configuration settings. It's up to the AI player to validate and use these settings.
- MoveClient - provides access to the Board API. It can be used to make a move on the board. In case of invalid move, it returns Result with an error.
- StatusPublisher - provides access to the AI debug window notification. It can be used to report AI player progress or debug information.

Once you implement the AIAlgorithm interface, you need to register your AI player in DI container.
You can do it using one of AddAIPlayer overloads in the Program.cs file.
For simple AI player registration use:

    builder.Services.AddAiPlayer<OpenAiGpt4o>();

For more complex AI player registration use overload with implementation factory:

    builder.Services.AddAiPlayer<OpenAiGpt4o>(x =>
        new OpenAiGpt4o(x.GetRequiredService<ILogger<OpenAiGpt4o>>(), x.GetRequiredService<IOpenAIService>()));

Platform dependencies like AiAlgorithmConfiguration, MoveClient, and StatusPublisher are registered in the DI container and can be injected into the AI player. You don't need to register them manually.
You can register any other dependency that your AI player needs in the DI container. They will be injected into the AI player.

### Minimal AI player implementation

Create your Ai player class that implements AIAlgorithm interface.

    public class Example(MoveClient client, StatusPublisher statusPublisher, AiAlgorithmConfiguration configuration) : AIAlgorithm
    {
        private readonly Random _random = new();
        private readonly ExampleConfiguration _configuration = new(configuration);

        public async ValueTask Move(ParticipantDto participant, BoardDto board)
        {
            if (participant.Color != board.CurrentPlayer)
            {
                // It's not my turn, nothing to do here
                return;
            }

            // Here you can implement your AI algorithm
            // For now, let's just make a random move
            // Square is a 2D array, so we need to flatten it to get a list of all squares for easier manipulation
            var flatListOfSquares = board.Squares.SelectMany(square => square).ToList();
    
            // Get all squares with player's pieces
            var playerPieceSquares = flatListOfSquares
                .Where(x => x.Piece is not null && x.Piece.Color == participant.Color)
                .ToList();
            
            // Get all empty squares
            var emptySquares = flatListOfSquares.Where(x => x.Piece is null).ToList();
            
            for (var retry = 0; retry < _configuration.MaxRetries; retry++)
            {
                // Get random player's piece square
                var randomPlayerPieceSquare = playerPieceSquares[_random.Next(playerPieceSquares.Count - 1)];
                // Get random empty square
                var randomEmptySquare = emptySquares[_random.Next(emptySquares.Count - 1)];
            
                // Send move to the board
                var move = new MoveDto(randomPlayerPieceSquare.Position, randomEmptySquare.Position);
                var result = await client.Move(move);
                if (result.IsFailed)
                {
                    await statusPublisher.Publish(AiPlayerStatus.Failed("API", result.Errors.First().Message));
                }
            
                await statusPublisher.Publish(AiPlayerStatus.Successful("API", "Move was successful"));
            }
        }

        private record ExampleConfiguration
        {
            private readonly AiAlgorithmConfiguration _configuration;
    
            public ExampleConfiguration(AiAlgorithmConfiguration configuration)
            {
                _configuration = configuration;
            }
            
            public int MaxRetries => int.TryParse(_configuration.Entries.GetValueOrDefault("MaxRetries"), out var maxRetries) ? maxRetries : 3;
        }
    }

and register it in the DI container:

    builder.Services.AddAiPlayer<Example>();

That's all. Your AI player is ready to play. New entry will appear in the AI player list in the game lobby.

## Plan

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

## Future plans

- [ ] TBD 

This project is licensed under the [MIT License](LICENSE).