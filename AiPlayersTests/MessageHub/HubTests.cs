using AIPlayers.MessageHub;
using Contracts.AiPlayers;
using Contracts.Dto;
using MassTransit;
using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace AiPlayersTests.MessageHub;

public class HubTests
{
    // [Test]
    // [TestCase("")]
    // [TestCase(" ")]
    // [TestCase("Something")]
    // [TestCase(SignalRPlayer.TypeValue)]
    // public async Task IgnoresDifferentPlayers(string type)
    // {
    //     var harness = await BuildTestHarness();
    //     
    //     var board = GetBoardDto();
    //     var participant = new NotifiableParticipantDto {Id = "AI_1", Type = type, Color = ColorDto.Black};
    //
    //     await harness.Bus.Publish(new GameProgressChanged(board, participant));
    //
    //     var published = await harness.Published.Any(filter =>
    //     {
    //         filter.Excludes.Add<GameProgressChanged>();
    //     });
    //     
    //     Assert.That(await harness.Consumed.Any<GameProgressChanged>(), Is.True);
    //     Assert.That(published, Is.False);
    // }
    //
    // [Test]
    // public async Task Test()
    // {
    //     var harness = await BuildTestHarness();
    //
    //     var board = GetBoardDto();
    //     var participant = new NotifiableParticipantDto {Id = "AI_1", Type = AIDummyPlayer.TypeValue, Color = ColorDto.Black};
    //
    //     await harness.Bus.Publish(new GameProgressChanged(board, participant));
    //     
    //     Assert.That(await harness.Consumed.Any<GameProgressChanged>(), Is.True);
    //
    //     var result = await harness.Published.SelectAsync<DummyPlayerGameStateChanged>().FirstOrDefault();
    //     var message = result.Context.Message;
    //     Assert.Multiple(() =>
    //     {
    //         Assert.That(message.Participant.Id, Is.EqualTo("AI_1"));
    //         Assert.That(message.Participant.Color, Is.EqualTo(ColorDto.Black));
    //         Assert.That(message.Board.Columns, Is.EqualTo(board.Columns));
    //         Assert.That(message.Board.Rows, Is.EqualTo(board.Rows));
    //         Assert.That(message.Board.CurrentPlayer, Is.EqualTo(board.CurrentPlayer));
    //         Assert.That(message.Board.MoveLog, Is.EquivalentTo(board.MoveLog));
    //         Assert.That(message.Board.Participants, Is.EqualTo(board.Participants));
    //         Assert.That(message.Board.Squares, Is.EquivalentTo(board.Squares));
    //     });
    // }
    //
    // private static async Task<ITestHarness> BuildTestHarness()
    // {
    //     var provider = new ServiceCollection()
    //         .AddMassTransitTestHarness(x =>
    //         {
    //             x.AddConsumer<Hub>();
    //             x.SetTestTimeouts(testInactivityTimeout: TimeSpan.FromMilliseconds(250));
    //             
    //         })
    //         .BuildServiceProvider(true);
    //
    //     var harness = provider.GetRequiredService<ITestHarness>();
    //     await harness.Start();
    //     
    //     return harness;
    // }
    //
    // private static BoardDto GetBoardDto()
    // {
    //     return new BoardDto
    //     {
    //         Id = "ID", Columns = 8, Rows = 8, Participants = Enumerable.Empty<ParticipantDto>(), CurrentPlayer = ColorDto.Black,
    //         Squares = Enumerable.Empty<IEnumerable<SquareSnapshotDto>>(), MoveLog = Enumerable.Empty<MoveLogEntryDto>(),
    //     };
    // }
}