using System.Numerics;
using BattleBitApi.Api;
using BattleBitApi.Data;
using BattleBitApi.Enums;
using BattleBitApi.Helpers;

namespace BattleBitApi.Events;

public class ExclusionZoneHandler : Event
{
    public override Task OnConnected()
    {
        Task.Run(async () =>
        {
            while (Server.IsConnected)
            {
                if (Server.ServerZombieGameState != ZombieGameState.HumanPreparation)
                {
                    foreach (var player in Server.AllPlayers.Where(player => player.PlayerTeamRole == PlayerTeamRoles.Human && player.IsAlive && player.Position != Vector3.Zero))
                    {
                        if (ZoneHelper.GetIsPlayerInExclusionZone(ExclusionZoneList.GetMapSpawnExclusionZone(Server.Map), player))
                        {
                            // TODO: Remove in prod
                            Server.UILogOnServer($"Player {player.Name} is in the exclusion zone!", 5);
                            // TODO: Spawn task to kill player after X amount of time, make message prettier.
                        }
                    }
                }

                await Task.Delay(1000);
            }
        });
        
        return base.OnConnected();
    }
}