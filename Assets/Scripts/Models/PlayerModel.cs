using System;
using Assets.Scripts.Models;
using UnityEngine;

namespace GizmoExercises.Models
{
    public class PlayerModel : IPlayerModel
    {
        #region Events

        public event Action DataChanged;

        #endregion

        #region Fields

        private PlayerModelDto _modelData;

        #endregion


        #region Methods

        public PlayerModelDto GetDto()
        {
            return _modelData;
        }

        public void SetDto(PlayerModelDto dto)
        {
            _modelData = dto;
            DataChanged?.Invoke();
        }

        public void SetNickname(string nickname)
        {
            _modelData.Nickname = nickname;
        }

        public void SetPlayerId(string playerId)
        {
            _modelData.PlayerId = playerId;
        }

        public void SetAvatarId(int avatarId)
        {
            _modelData.AvatarId = avatarId;
        }

        public void SetCoinsBalance(long coinsBalance)
        {
            _modelData.CoinsBalance = coinsBalance;
        }

        public void SetGemsBalance(long gemsBalance)
        {
            _modelData.GemsBalance = gemsBalance;
        }

        #endregion

        #region Properties

        public string Nickname => _modelData.Nickname;

        public string PlayerId => _modelData.PlayerId;

        public int AvatarId => _modelData.AvatarId;

        public long CoinsBalance => _modelData.CoinsBalance;

        public long GemsBalance => _modelData.GemsBalance;

        #endregion
    }
}