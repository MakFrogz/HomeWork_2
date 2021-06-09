using Assets.Scripts.Models;
using System;

namespace GizmoExercises.Models
{
    public interface IPlayerModel
    {
        int AvatarId { get; }
        long CoinsBalance { get; }
        long GemsBalance { get; }
        string Nickname { get; }
        string PlayerId { get; }

        event Action DataChanged;

        PlayerModelDto GetDto();
        void SetAvatarId(int avatarId);
        void SetCoinsBalance(long coinsBalance);
        void SetDto(PlayerModelDto dto);
        void SetGemsBalance(long gemsBalance);
        void SetNickname(string nickname);
        void SetPlayerId(string playerId);
    }
}