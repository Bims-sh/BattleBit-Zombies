using BattleBitApi.Api;
using BattleBitAPI.Common;
using BattleBitApi.Helpers;

namespace BattleBitApi.Events;

public class PlayerWearings : Event
{
    public override Task<OnPlayerSpawnArguments?> OnPlayerSpawning(BattleBitPlayer player, OnPlayerSpawnArguments request)
    {
        request.Wearings = PlayerWearingHelper.GetUpdatedWearings(player.PlayerTeamRole, request.Wearings);
        
        player.Modifications.RunningSpeedMultiplier = 2.5f;
        
        return base.OnPlayerSpawning(player, request);
    }
}