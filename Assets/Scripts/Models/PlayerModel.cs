using System;
using Assets.Scripts.Api;
using Assets.Scripts.Models;
using UnityEngine;

namespace GizmoExercises.Models
{
    [CreateAssetMenu(fileName = "Player Model", menuName = "Models/Player Model")]
    public class PlayerModel : ScriptableObject, IPlayerModel
    {
        #region Events

        public event Action DataChanged;

        #endregion

        #region Fields

        private PlayerModelDto _modelData;

        #endregion

        #region Serializables

        //[SerializeField]
        public string _nickname;

        //[SerializeField]
        public string _playerId;

        //[SerializeField]
        public int _avatarId;

        //[SerializeField]
        public long _coinsBalance;

        //[SerializeField]
        public long _gemsBalance;

        #endregion

        #region Methods

        public PlayerModelDto GetDto()
        {
            return _modelData;
        }

        public void SetDto(PlayerModelDto dto)
        {
            _modelData = dto;
            SetNickname(_nickname);
            SetPlayerId(_playerId);
            SetAvatarId(_avatarId);
            SetCoinsBalance(_coinsBalance);
            SetGemsBalance(_gemsBalance);
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

        /*public string Nickname { get { return _nickname; } set { _nickname = value; SetNickname(value); } }

        public string PlayerId { get { return _playerId; } set { _playerId = value; SetPlayerId(value); } }

        public int AvatarId { get { return _avatarId; } set { _avatarId = value; SetAvatarId(value); } }

        public long CoinsBalance { get { return _coinsBalance; } set { _coinsBalance = value; SetCoinsBalance(value); DataChanged?.Invoke(); } }

        public long GemsBalance { get { return _gemsBalance; } set { _gemsBalance = value; SetGemsBalance(value); DataChanged?.Invoke(); } }*/

        #endregion
    }
}