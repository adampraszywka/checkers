# Smart Checkers

![screenshot](logo.png)

This open-source project focuses on developing a Checkers game application with two main objectives. The first is to enable human players to compete against each other on different devices seamlessly. The second objective is to design a versatile interface for various AI-driven players, including algorithms, pre-trained neural networks, and Large Language Models (LLMs), facilitating innovative gameplay and strategy development, despite LLMs traditionally not being tailored for such applications. We're excited about exploring the intersection of classic game strategy and cutting-edge AI, and we welcome contributors interested in pushing the boundaries of what's possible in game AI.
### Demo
Current version is available under: [https://thankful-bay-00e121503.5.azurestaticapps.net/](https://thankful-bay-00e121503.5.azurestaticapps.net/)
CI/CD process deploys latest version after each commit to main branch.

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
By default WebAPI binds to localhost:5125

#### UI

Start Angular development server by the following commands:

```
cd UserInterface
npm install
npm run start
```

By default Angular development server binds to localhost:4200 and its connected with API running on localhost:5125.

### Plan

- [X] CI process
- [X] CD process
- [X] basic board API implementation
- [X] basic implementation of Man piece moves
- [ ] basic implementation of King piece moves
- [X] board UI PoC
- [ ] in-memory game state storage
- [ ] game log
- [ ] persistent game state storage
- [ ] use SignalR for Board UI <-> Board API communication
- [ ] implementation of complex Man piece moves
- [ ] implementation of complex King piece moves
- [ ] game flow control (player moves, )
- [ ] PvP using two different devices/browsers
- [ ] game lobby
- [ ] interface for AI driven players
- [ ] algorithm driven AI player
- [ ] LLM(s) driven AI player (it may be not the best option but might be funny)

### Future plans

- [ ] TBD 

This project is licensed under the [MIT License](LICENSE).