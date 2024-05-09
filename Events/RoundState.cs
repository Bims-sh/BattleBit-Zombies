using BattleBitApi.Api;
using BattleBitAPI.Common;

namespace BattleBitApi.Events;

public class RoundState : Event
{
    public override Task OnGameStateChanged(GameState oldState, GameState newState)
    {
        UpdateBasedOnGameState(newState, Server);
        
        return base.OnGameStateChanged(oldState, newState);
    }

    public override Task OnConnected()
    {
        UpdateBasedOnGameState(Server.RoundSettings.State, Server);
        
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
}