using System;

namespace Assets.Scripts.Models
{
    public interface IPlayerStatsModel
    {
        int PlayerAttack { get; }
        int PlayerHP { get; }
        int PlayerIntelligence { get; }
        int PlayerLevel { get; }
        int PlayerMP { get; }
        int PlayerStrength { get; }
        int PlayerVitality { get; }

        event Action DataChanged;

        PlayerStatsModelDto ToDto();

        void FromDto(PlayerStatsModelDto playerStatsDto);


    }
}