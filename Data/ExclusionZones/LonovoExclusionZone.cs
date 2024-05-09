using System.Numerics;

namespace BattleBitApi.Data.ExclusionZones;

public static class LonovoExclusionZone
{
    public static List<Vector2> HumanSpawnCorners = new List<Vector2>
    {
        new Vector2(-475, -242),
        new Vector2(-130f, -204),
        new Vector2(135, -204),
        new Vector2(475, -272),
        new Vector2(475, -475),
        new Vector2(-475, -475)
    };
}