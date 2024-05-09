using BattleBitApi.Api;
using BattleBitAPI.Common;
using BattleBitApi.Enums;

namespace BattleBitApi.Events;

public class RoundState : Event
{
    public override Task OnGameStateChanged(GameState oldState, GameState newState)
    {
        UpdateBasedOnGameState(newState, Server);
        UpdateZombieGameState(newState, Server);
        
        return base.OnGameStateChanged(oldState, newState);
    }

    public override Task OnConnected()
    {
        UpdateBasedOnGameState(Server.RoundSettings.State, Server);
        UpdateZombieGameState(Server.RoundSettings.State, Server);
        
        return base.OnConnected();
    }

    private static void UpdateBasedOnGameState(GameState state, BattleBitServer Server)
    {
        if (state == GameState.WaitingForPlayers)
            Server.ForceStartGame();
        else
        {
            Server.RoundSettings.SecondsLeft = state switch
            {
                GameState.CountingDown => 5,
                GameState.Playing => 60 * 60 * 1,
                _ => Server.RoundSettings.SecondsLeft
            };
        }
    }

    private static void UpdateZombieGameState(GameState state, BattleBitServer Server)
    {
        switch (state)
        {
            case GameState.WaitingForPlayers:
                Server.ServerZombieGameState = ZombieGameState.WaitingForPlayers;
                break;
            case GameState.CountingDown:
                break;
            case GameState.Playing:
                // TODO: Remove and add a cooldown for human preparation (1m - 2m)
                Server.ServerZombieGameState = ZombieGameState.ZombiesPlaying;
                break;
            case GameState.EndingGame:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }
}