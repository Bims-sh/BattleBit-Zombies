using BattleBitAPI.Common;

namespace BattleBitApi.Helpers;

public class PlayerWearingHelper
{
    private static readonly Dictionary<string, string[]> WearingDictionary = new ()
    {
        { "HumanUniform", new[] { "ANY_NU_Uniform_Survivor_00", "ANY_NU_Uniform_Survivor_01", "ANY_NU_Uniform_Survivor_02", "ANY_NU_Uniform_Survivor_03", "ANY_NU_Uniform_Survivor_04" } },
        { "HumanHead", new[] { "ANV2_Survivor_All_Helmet_00_A_Z", "ANV2_Survivor_All_Helmet_00_B_Z", "ANV2_Survivor_All_Helmet_01_A_Z", "ANV2_Survivor_All_Helmet_02_A_Z", "ANV2_Survivor_All_Helmet_03_A_Z", "ANV2_Survivor_All_Helmet_04_A_Z", "ANV2_Survivor_All_Helmet_05_A_Z", "ANV2_Survivor_All_Helmet_05_B_Z" } },
        { "HumanBackpack", new[] { "ANV2_Survivor_All_Backpack_00_A_H", "ANV2_Survivor_All_Backpack_00_A_N", "ANV2_Survivor_All_Backpack_01_A_H", "ANV2_Survivor_All_Backpack_01_A_N", "ANV2_Survivor_All_Backpack_02_A_N" } },
        { "HumanChest", new[] { "ANV2_Survivor_All_Armor_00_A_L", "ANV2_Survivor_All_Armor_00_A_N", "ANV2_Survivor_All_Armor_01_A_L", "ANV2_Survivor_All_Armor_02_A_L" } },
        { "ZombieEyes", new[] { "Eye_Zombie_01" } },
        { "ZombieFace", new[] { "Face_Zombie_01" } },
        { "ZombieHair", new[] { "Hair_Zombie_01" } },
        { "ZombieSkin", new[] { "Zombie_01" } },
        { "ZombieUniform", new[] { "ANY_NU_Uniform_Zombie_01" } },
        { "ZombieHead", new[] { "ANV2_Universal_Zombie_Helmet_00_A_Z" } },
        { "ZombieChest", new[] { "ANV2_Universal_All_Armor_Null" } },
        { "ZombieBackpack", new[] { "ANV2_Universal_All_Backpack_Null" } },
        { "ZombieBelt", new[] { "ANV2_Universal_All_Belt_Null" } }
    };
    
    public static PlayerWearings GetUpdatedWearings(Team playerTeam, PlayerWearings currentWearings)
    {
        var updatedWearings = currentWearings;
        var playerRole = playerTeam == Team.TeamA ? "Human" : "Zombie";

        if (playerRole == "Human")
        {
            updatedWearings.Uniform = GetRandomWearing(playerRole, "Uniform");
            updatedWearings.Head = GetRandomWearing(playerRole, "Head");
            updatedWearings.Backbag = GetRandomWearing(playerRole, "Backpack");
            updatedWearings.Chest = GetRandomWearing(playerRole, "Armor");
        }
        else
        {
            updatedWearings.Eye = WearingDictionary["ZombieEyes"][0];
            updatedWearings.Face = WearingDictionary["ZombieFace"][0];
            updatedWearings.Hair = WearingDictionary["ZombieHair"][0];
            updatedWearings.Skin = WearingDictionary["ZombieSkin"][0];
            updatedWearings.Uniform = WearingDictionary["ZombieUniform"][0];
            updatedWearings.Head = WearingDictionary["ZombieHead"][0];
            updatedWearings.Chest = WearingDictionary["ZombieChest"][0];
            updatedWearings.Backbag = WearingDictionary["ZombieBackpack"][0];
            updatedWearings.Belt = WearingDictionary["ZombieBelt"][0];
        }
        
        return updatedWearings;
    }
    
    private static string GetRandomWearing(string playerRole, string wearingType)
    {
        var wearings = WearingDictionary[$"{playerRole}{wearingType}"];
        var randomIndex = new Random().Next(0, wearings.Length);
        
        return wearings[randomIndex];
    }
}