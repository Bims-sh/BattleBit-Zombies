using System.Numerics;
using BattleBitApi.Api;
using BattleBitApi.Data;
using BattleBitApi.Data.ExclusionZones;
using BattleBitApi.Helpers;

namespace BattleBitApi.Events;

public class ExclusionZoneHandler : Event
{
    public override Task OnConnected()
    {
        Task.Run(async () =>
        {
            while (true)
            {
                foreach (var player in Server.AllPlayers.Where(player => player.PlayerTeamRole == PlayerTeamRoles.Human && player.IsAlive && player.Position != Vector3.Zero))
                {
                    if (ZoneHelper.GetIsPlayerInExclusionZone(ExclusionZoneList.GetMapSpawnExclusionZone(Server.Map), player))
                    {
                        player.Message("You are in the exclusion zone! Please move back to the map!", 1);
                    }
                }

                await Task.Delay(1000);
            }
        });
        
        return base.OnConnected();
    }
}