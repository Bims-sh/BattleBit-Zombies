using System.Numerics;
using BattleBitApi.Api;
using BattleBitApi.Data;

namespace BattleBitApi.Helpers;

public static class ZoneHelper
{
    public static bool GetIsPlayerInExclusionZone(List<Vector2> zone, BattleBitPlayer player)
    {
        return IsPointInPolygon(new Vector2(player.Position.X, player.Position.Z), zone);
    }
    
    private static bool IsPointInPolygon(Vector2 point, List<Vector2> zone)
    {
        var result = false;
        var j = zone.Count - 1;

        for (var i = 0; i < zone.Count; i++)
        {
            if (zone[i].Y < point.Y && zone[j].Y >= point.Y || zone[j].Y < point.Y && zone[i].Y >= point.Y)
            {
                if (zone[i].X + (point.Y - zone[i].Y) / (zone[j].Y - zone[i].Y) * (zone[j].X - zone[i].X) < point.X)
                {
                    result = !result;
                }
            }

            j = i;
        }

        return result;
    }
}