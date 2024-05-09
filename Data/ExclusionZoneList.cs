using System.Numerics;
using BattleBitApi.Data.ExclusionZones;

namespace BattleBitApi.Data;

public static class ExclusionZoneList
{
    public static List<Vector2> GetMapSpawnExclusionZone(string mapName)
    {
        return mapName switch
        {
            "Lonovo" => LonovoExclusionZone.HumanSpawnCorners,
            _ => new List<Vector2>()
        };
    }
}