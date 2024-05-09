﻿using System.Text;
using BattleBitApi.Api;
using BattleBitApi.Enums;

namespace BattleBitApi.Helpers;

public class DebugHelper
{
    public static void StartPlayerDebug(BattleBitPlayer player, BattleBitServer server)
    {
        Task.Run(() =>
        {
            while (player.Debug)
            {
                var message = new StringBuilder();
                
                message.AppendLine($"Player: {player.Name}");
                message.AppendLine($"Highest Player Role: {player.GetHighestRole()}");
                message.AppendLine($"Position: {player.Position}");
                message.AppendLine($"Health: {player.HP}");
                message.AppendLine($"PlayerTeamRole: {player.PlayerTeamRole}");
                message.AppendLine($"Map: {server.Map}");
                message.AppendLine($"ZombieGameState: {server.ServerZombieGameState}");
                message.AppendLine($"PlayerCount: {server.AllPlayers.Count()}");

                player.Message(message.ToString());
                
                Thread.Sleep(1000);
            }
        });
    }
}